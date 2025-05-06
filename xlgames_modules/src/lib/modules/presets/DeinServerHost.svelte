<script>
  import SharedSkelet from "../shared/SharedSkelet.svelte";
  import {process} from "../../index.js";

  let information = $state(information_PHP);
  let loading_control = $state(false);
  let os = $state(information.available_os[0] ?? "...");

  async function reboot() {
    loading_control = true;
    await process("reboot", {
      method: "POST"
    });
    loading_control = false;
  }

  async function reinstall_os() {
    loading_control = true;
    let result = await process("reinstall", {
      method: "POST",
      body: JSON.stringify({
        os
      })
    });
    if (result !== false) {
      location.reload();
    } else {
      loading_control = false;
    }
  }
</script>

<SharedSkelet bind:os {information} {loading_control} {reboot} {reinstall_os}/>