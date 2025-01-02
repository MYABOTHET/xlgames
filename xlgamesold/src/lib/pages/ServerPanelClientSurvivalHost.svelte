<script>
  import {onMount} from "svelte";
  import default_language from "../information/language.js";
  import ServerPanelClientSurvivalHost from "../skeletons/ServerPanelClientSurvivalHost.svelte";
  
  let url = window.location.href;
  let have_error = $state(false);
  let error_message = $state("");
  let success_message = $state("");
  let loading = $state(false);
  let loading_message = $state("");
  let language = $state(Object.assign({}, default_language));
  let network_statistics = $state('');
  let current_date = $state(new Date(new Date().getTime() - 1000 * 60 * 60 * 24));
  let can_next = $derived(date < 0);
  let can_back = $derived(date > -89);
  let info = $state({
    status: false,
    os: 'Windows 10',
    ip: '11.23.157.119',
    login: 'I dont know',
    password: 'I see you',
    list_os: [
      {
        id: 1,
        name: "Windows 10"
      }
    ]
  });
  let have_confirm = $state(false);
  let date = $state(0);
  let props = $props();
  
  let current_os = $state('-');
  let list_os = $state(['-']);
  
  onMount(async () => {
    try {
      document.getElementsByClassName('module-client-area')[0].className = "";
    } catch (err) {}
    loading = true;
    loading_message = "≽^•⩊•^≼";
    language = await get_language();
    loading_message = language.data;
    let error = await check_error();
    let body = await error.json();
    if (error.status !== 200) {
      have_error = true;
      error_message = language[body.error_message];
      loading = false;
      return;
    }
    await init();
    loading = false;
  });
  
  function parse_date() {
    let day = current_date.getDate();
    let month = current_date.getMonth() + 1;
    if (day < 10) {
      day = "0" + day;
    }
    if (month < 10) {
      month = "0" + month;
    }
    return `${day}.${month}.${current_date.getFullYear()}`;
  }
  
  async function init() {
    info = await get_system();
    loading_message = language.network_statistics;
    network_statistics = await get_network_statistics(date);
    init_reinstall();
  }
  
  function init_reinstall() {
    if (info.list_os.length > 0) {
      list_os = [];
      info.list_os.forEach((item) => {
        if (!list_os.includes(item.name)) {
          list_os.push(item.name);
        }
      });
      select_os(list_os[0]);
    }
  }
  
  function select_os(new_os) {
    current_os = new_os;
  }
  
  function check_error() {
    let href = new URL(url);
    href.searchParams.append("method", "error");
    return fetch(href.href);
  }
  
  async function get_system() {
    let href = new URL(url);
    href.searchParams.append("method", "machine");
    return await (await fetch(href.href)).json();
  }
  
  async function on() {
    loading = true;
    loading_message = language.on_loading;
    let href = new URL(url);
    href.searchParams.append("method", "machine");
    href.searchParams.append("operation", "start");
    await fetch(href.href, {method: 'POST'});
    info.status = true;
    loading = false;
  }
  
  async function off() {
    loading = true;
    loading_message = language.off_loading;
    let href = new URL(url);
    href.searchParams.append("method", "machine");
    href.searchParams.append("operation", "stop");
    await fetch(href.href, {method: 'POST'});
    info.status = false;
    loading = false;
  }
  
  async function reboot() {
    loading = true;
    loading_message = language.reboot_loading;
    let href = new URL(url);
    href.searchParams.append("method", "machine");
    href.searchParams.append("operation", "restart");
    await fetch(href.href, {method: 'POST'});
    loading = false;
  }
  
  async function get_language() {
    let href = new URL(url);
    href.searchParams.append("method", "language");
    return await (await fetch(href.href)).json();
  }
  
  async function date_next() {
    loading = true;
    loading_message = language.network_statistics;
    current_date.setDate(current_date.getDate() + 1);
    current_date = new Date(current_date.getTime());
    date = date + 1;
    network_statistics = await get_network_statistics(date);
    loading = false;
  }
  
  async function date_back() {
    loading = true;
    loading_message = language.network_statistics;
    current_date.setDate(current_date.getDate() - 1);
    current_date = new Date(current_date.getTime());
    date = date - 1;
    network_statistics = await get_network_statistics(date);
    loading = false;
  }
  
  async function get_network_statistics(date) {
    let href = new URL(url);
    href.searchParams.append("method", "network");
    href.searchParams.append("date", date);
    return await (await fetch(href.href)).text();
  }
  
  async function reinstall() {
    loading = true;
    loading_message = language.reinstall_loading;
    close();
    let new_system = info.list_os[0];
    info.list_os.forEach((item) => {
      if (current_os === item.name) {
        new_system = item;
      }
    });
    let href = new URL(url);
    href.searchParams.append("method", "os");
    href.searchParams.append("os_id", new_system.id);
    let body = await (await fetch(href.href, {method: 'POST'})).json();
    info.login = body.login;
    info.password = body.password;
    info.os = new_system.name;
    loading = false;
  }
  
  function close() {
    have_confirm = false;
  }
  
  function open() {
    have_confirm = true;
  }
  
</script>

<ServerPanelClientSurvivalHost {language} {info} {have_error} {error_message} {loading_message} {loading}
                   {on} {off} {reboot} {network_statistics} current_date={parse_date()} {date_next} {date_back}
                   {can_back} {can_next} {current_os} {reinstall} {list_os} {select_os} {have_confirm} {close}
                   {open} {success_message} {...props}
/>