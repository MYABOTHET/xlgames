<script>
  import {onMount} from "svelte";
  import default_language from "../information/language.js";
  import default_network_statistics from "../information/network-statistics.js";
  import ServerPanelClientReliable from "../skeletons/ServerPanelClientReliable.svelte";
  
  let url = `/store/index.php?m=rspanel&sid=${new URLSearchParams(window.location.href).get("id")}`;
  let have_error = $state(false);
  let error_message = $state("");
  let success_message = $state("");
  let loading = $state(false);
  let loading_message = $state("");
  let language = $state(Object.assign({}, default_language));
  let network_statistics = $state(default_network_statistics);
  let key = $state("");
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
  let props = $props();
  
  let current_os = $state('-');
  let list_os = $state(['-']);
  let current_time = $state('');
  let list_time = $state([]);
  let network = $state({});
  
  async function select_time(new_time) {
    current_time = new_time;
    loading_message = language.on_loading;
    network_statistics = {
      item_count: 0,
      result: []
    };
    Object.entries(network[current_time].data.bandwidthLogs).forEach(([key, value]) => {
      network_statistics.item_count += 1;
      network_statistics.result.push([new Date(key).getTime(), value[2] * 1000 * 1000, value[3] * 1000 * 1000]);
    });
  }
  
  onMount(async () => {
    try {
      PHP_language = PHP_language.replaceAll(/\r?\n|\r/g, '');
      language = JSON.parse(PHP_language);
      loading_message = language.data;
      PHP_serverdetails = PHP_serverdetails.replaceAll(/\r?\n|\r/g, '');
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
      network_statistics = {
        item_count: 0,
        result: []
      };
      PHP_network = PHP_network.replaceAll(/\r?\n|\r/g, '');
      network = JSON.parse(PHP_network);
      let network_elements = [];
      Object.entries(network).forEach(([key, value]) => {
        if (value.data.bandwidthLogs && value.data.bandwidthLogs.length !== 0) {
          network_elements.push({
            key,
            value
          });
          list_time.push(key);
        }
      });
      if (network_elements.length > 0) {
        current_time = network_elements[0].key;
        Object.entries(network_elements[0].value.data.bandwidthLogs).forEach(([key, value]) => {
          network_statistics.item_count += 1;
          network_statistics.result.push([new Date(key).getTime(), value[2] * 1000 * 1000, value[3] * 1000 * 1000]);
        });
      }
      list_os = [];
      PHP_list_os = PHP_list_os.replaceAll(/\r?\n|\r/g, '');
      JSON.parse(PHP_list_os).data.forEach(item => {
        info.list_os.push({
          id: item.operatingSystemId,
          partId: item.defaultPartitioningSchemeId,
          name: item.osLabel
        });
        list_os.push(item.osLabel);
      });
      current_os = list_os[0];
    } catch (error) {
      have_error = true;
      error_message = language.unknown;
    }
  });
  
  function select_os(new_os) {
    current_os = new_os;
  }
  
  async function on() {
    loading = true;
    loading_message = language.on_loading;
    await fetch(`${url}&action=dopoweron`, {
      method: 'POST',
    });
    info.status = true;
    loading = false;
  }
  
  async function off() {
    loading = true;
    loading_message = language.off_loading;
    await fetch(`${url}&action=dopoweroff`, {
      method: 'POST',
    });
    info.status = false;
    loading = false;
  }
  
  async function reinstall() {
    loading = true;
    loading_message = language.reinstall_loading;
    close();
    let new_system = info.list_os[0];
    info.list_os.forEach(item => {
      if (current_os === item.name) {
        new_system = item;
      }
    });
    let formData = new FormData();
    formData.append("serverIP", info.ip);
    formData.append("licenseKey", key);
    formData.append("operatingSystemId", new_system.id);
    formData.append("partitioningSchemeId", new_system.partId);
    const result = await (await fetch(`${url}&action=installos`, {
      method: 'POST',
      body: formData
    })).json();
    if (result.errors.length) {
      alert(result.errors.join("\n"));
    } else {
      info.os = new_system.name;
    }
    loading = false;
  }
  
  function close() {
    have_confirm = false;
  }
  
  function open() {
    have_confirm = true;
  }

</script>

<ServerPanelClientReliable {language} {info} {have_error} {error_message} {loading_message} {loading}
                           {on} {off} {network_statistics}
                           {current_os} {reinstall} {list_os} {select_os} {have_confirm}
                           {close} bind:key {list_time} {current_time} {select_time}
                           {open} {success_message} {...props}
/>