<script>
  import {onMount} from "svelte";
  import default_language from "../information/language.js";
  import default_network_statistics from "../information/network-statistics.js";
  import ServerPanelClientReliable from "../skeletons/ServerPanelClientReliable.svelte";
  
  let url = window.location.href;
  let have_error = $state(false);
  let error_message = $state("");
  let success_message = $state("");
  let loading = $state(false);
  let loading_message = $state("");
  let language = $state(Object.assign({}, default_language));
  let network_statistics = $state(default_network_statistics);
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
      language = JSON.parse(PHP_language);
      loading_message = language.data;
      const serverdetails = JSON.parse(PHP_serverdetails);
      const server = serverdetails.data.server;
      info = {
        status: server.status === "Active",
        os: `${server.operatingSystem} (${server.cpuName})`,
        ip: serverdetails.data.ipAddressList[0].ipDescription,
        login: server.username,
        password: server.password,
        list_os: []
      }
    } catch {
      have_error = true;
      error_message = language.unknown;
    }
  });
  
  function get_start() {
    let clone_date = new Date(current_date.getTime());
    clone_date.setHours(0);
    clone_date.setMinutes(0);
    clone_date.setMilliseconds(0);
    return clone_date.getTime();
  }
  
  function get_end() {
    let clone_date = new Date(current_date.getTime());
    clone_date.setHours(23);
    clone_date.setMinutes(59);
    clone_date.setMilliseconds(59);
    return clone_date.getTime();
  }
  
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
    let information = await get_system();
    information.system.created = new Date(information.system.created);
    info = information;
    loading_message = language.network_statistics;
    network_statistics = await get_network_statistics(get_start(), get_end());
    init_reinstall();
  }
  
  function init_reinstall() {
    if (info.reinstall.length > 0) {
      list_os = [];
      info.reinstall.forEach((item) => {
        if (!list_os.includes(item.os_name)) {
          list_os.push(item.os_name);
        }
      });
      select_os(list_os[0]);
    }
  }
  
  function select_os(new_os) {
    current_os = new_os;
    info.reinstall.forEach((item) => {
      if (current_os === item.os_name) {
        if (!list_arch.includes(item.arch)) {
          list_arch.push(item.arch);
        }
      }
    });
  }
  
  async function get_system() {
    return await (await fetch(`${url}&operation=system`)).json();
  }
  
  async function on() {
    loading = true;
    loading_message = language.on_loading;
    await (await fetch(`${url}&operation=on`, {
      method: 'POST',
    })).json();
    info.system.state = true;
    loading = false;
  }
  
  async function off() {
    loading = true;
    loading_message = language.off_loading;
    await (await fetch(`${url}&operation=off`, {
      method: 'POST',
    })).json();
    info.system.state = false;
    loading = false;
  }
  
  async function reboot() {
    loading = true;
    loading_message = language.reboot_loading;
    await (await fetch(`${url}&operation=reboot`, {
      method: 'POST',
    })).json();
    loading = false;
  }
  
  async function date_next() {
    loading = true;
    loading_message = language.network_statistics;
    current_date.setDate(current_date.getDate() + 1);
    current_date = new Date(current_date.getTime());
    network_statistics = await get_network_statistics(get_start(), get_end());
    loading = false;
  }
  
  async function date_back() {
    loading = true;
    loading_message = language.network_statistics;
    current_date.setDate(current_date.getDate() - 1);
    current_date = new Date(current_date.getTime());
    network_statistics = await get_network_statistics(get_start(), get_end());
    loading = false;
  }
  
  async function get_network_statistics(start, end) {
    return await (await fetch(`${url}&operation=network_statistics`, {
      method: 'POST',
      body: JSON.stringify({
        start: start,
        end: end
      })
    })).json();
  }
  
  async function reinstall() {
    loading = true;
    loading_message = language.reinstall_loading;
    close();
    let new_system = info.reinstall[0];
    info.reinstall.forEach((item) => {
      if (current_os === item.os_name) {
        new_system = item;
      }
    });
    await fetch(`${url}&operation=reinstall`, {
      method: 'POST',
      body: JSON.stringify(new_system)
    });
    await is_reinstall();
  }
  
  function close() {
    have_confirm = false;
  }
  
  function open() {
    have_confirm = true;
  }

</script>

<ServerPanelClientReliable {language} {info} {have_error} {error_message} {loading_message} {loading}
                           {on} {off} {reboot} {network_statistics} current_date={parse_date()} {date_next}
                           {date_back}
                           {can_back} {can_next} {current_os} {reinstall} {list_os} {select_os} {have_confirm}
                           {close}
                           {open} {success_message} {...props}
/>