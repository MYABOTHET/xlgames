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
    let sure = confirm(`${language.are_you_sure_you_want_to_reinstall_the_os ?? "..."}\n\n* ${language.after_reinstalling_the_os_all_data_will_be_deleted_permanently_without_the_possibility_of_recovery ?? "..."}`);
    if (!sure) return;
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