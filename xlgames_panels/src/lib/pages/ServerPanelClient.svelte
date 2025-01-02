<script>
  import ServerPanelClient from "../skeletons/ServerPanelClient.svelte";
  import {onMount} from "svelte";
  import default_language from "../information/language.js";
  import default_network_statistics from "../information/network-statistics.js";
  
  let url = window.location.href;
  let have_error = $state(false);
  let error_message = $state("");
  let success_message = $state("");
  let loading = $state(false);
  let loading_message = $state("");
  let language = $state(Object.assign({}, default_language));
  let network_statistics = $state(Object.assign({}, default_network_statistics));
  let current_date = $state(new Date());
  let can_next = $derived(!(current_date.getDate() === new Date().getDate() &&
      current_date.getMonth() === new Date().getMonth()));
  let can_back = $derived(!(current_date.getDate() === info.system.created.getDate() &&
      current_date.getMonth() === info.system.created.getMonth()));
  let info = $state({
    system: {
      state: false,
      os: 'Raspberry Pi OS bullseye x64 aarch64_pi4',
      ip: '91.39.137.130',
      login: 'I dont know',
      password: 'I see you',
      created: (() => {
        let date = new Date();
        date.setDate(date.getDate() - 3);
        return date;
      })()
    },
    reinstall: [
      {
        os_value: "ubuntu",
        os_name: "Ubuntu",
        arch: "x86_64",
        version_value: "2404",
        version_name: "24.04 LTS",
      },
      {
        os_value: "ubuntu",
        os_name: "Ubuntu",
        arch: "x86_64",
        version_value: "2204",
        version_name: "22.04 LTS",
      },
      {
        os_value: "ubuntu",
        os_name: "Ubuntu",
        arch: "x86_64",
        version_value: "2004",
        version_name: "20.04 LTS",
      },
      {
        os_value: "ubuntu",
        os_name: "Ubuntu",
        arch: "x86_32",
        version_value: "2204",
        version_name: "22.04 LTS",
      },
      {
        os_value: "ubuntu",
        os_name: "Ubuntu",
        arch: "x86_32",
        version_value: "2004",
        version_name: "20.04 LTS",
      },
      {
        os_value: "windows 10",
        os_name: "Windows 10",
        arch: "x86_64",
        version_value: "2019",
        version_name: "Windows Server 2019",
      },
      {
        os_value: "windows 10",
        os_name: "Windows 10",
        arch: "x86_64",
        version_value: "2022",
        version_name: "Windows Server 2022",
      },
      {
        os_value: "windows 11",
        os_name: "Windows 11",
        arch: "x86_64",
        version_value: "2019",
        version_name: "Windows Server 2019",
      },
      {
        os_value: "windows 11",
        os_name: "Windows 11",
        arch: "x86_64",
        version_value: "2022",
        version_name: "Windows Server 2022",
      },
      {
        os_value: "windows 11",
        os_name: "Windows 11",
        arch: "x86_32",
        version_value: "2019",
        version_name: "Windows Server 2019",
      },
      {
        os_value: "windows 10",
        os_name: "Windows 10",
        arch: "x86_32",
        version_value: "2019",
        version_name: "Windows Server 2019",
      },
    ]
  });
  let have_confirm = $state(false);
  let props = $props();
  
  let current_os = $state('-');
  let current_arch = $state('-');
  let current_version = $state('-');
  let list_os = $state(['-']);
  let list_arch = $state(['-']);
  let list_version = $state(['-']);
  
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
    await is_reinstall();
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
  
  async function is_reinstall() {
    let reinstall = (await get_reinstall()).reinstall;
    if (reinstall) {
      loading_message = language.reinstall_loading;
      let time = setInterval(async () => {
        let reinstall = (await get_reinstall()).reinstall;
        if (!reinstall) {
          await init();
          loading = false;
          clearInterval(time);
        }
      }, 1000 * 30);
    } else {
      await init();
      loading = false;
    }
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
    list_arch = [];
    current_os = new_os;
    info.reinstall.forEach((item) => {
      if (current_os === item.os_name) {
        if (!list_arch.includes(item.arch)) {
          list_arch.push(item.arch);
        }
      }
    });
    select_arch(list_arch[0]);
  }
  
  function select_arch(new_arch) {
    list_version = [];
    current_arch = new_arch;
    info.reinstall.forEach((item) => {
      if (current_os === item.os_name && current_arch === item.arch) {
        if (!list_version.includes(item.version_name)) {
          list_version.push(item.version_name);
        }
      }
    });
    select_version(list_version[0]);
  }
  
  function select_version(new_version) {
    current_version = new_version;
  }
  
  async function check_error() {
    return await fetch(`${url}&operation=error`);
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
  
  async function get_reinstall() {
    return await (await fetch(`${url}&operation=reinstall`)).json();
  }
  
  async function get_language() {
    return await (await fetch(`${url}&operation=language`)).json();
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
      if (current_os === item.os_name && current_arch === item.arch && current_version === item.version_name) {
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

<ServerPanelClient {language} {info} {have_error} {error_message} {loading_message} {loading} {success_message}
                   {on} {off} {reboot} {network_statistics} current_date={parse_date()} {date_next} {date_back}
                   {can_back} {can_next} {current_os} {current_arch} {current_version} {reinstall} {list_os}
                   {list_arch} {list_version} {select_os} {select_arch} {select_version} {have_confirm} {close}
                   {open} {...props}
/>