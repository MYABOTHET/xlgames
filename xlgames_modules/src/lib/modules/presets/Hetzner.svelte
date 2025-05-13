<script>
  import SharedSkelet from "../shared/SharedSkelet.svelte";
  import {process} from "../../index.js";
  import Schedule from "../../components/shared/Schedule.svelte";
  import ButtonActive from "../../components/buttons/ButtonActive.svelte";

  let information = $state(information_PHP);
  let loading_control = $state(false);
  let os = $state(information.available_os[0] ?? "...");

  let period = $state("day");
  let points = $derived(information.network[period]);

  async function power() {
    loading_control = true;
    let result = await process("power", {
      method: "POST"
    });
    if (result !== false) {
      information.status = !information.status;
    }
    loading_control = false;
  }

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

<SharedSkelet bind:os {information} {loading_control} off={power} on={power} {reboot} {reinstall_os}>
  <section class="text-[15px] flex" style="gap: inherit">
    <ButtonActive active={period === "day"} onclick={() => {period = "day"}} title={language.day}/>
    <ButtonActive active={period === "month"} onclick={() => {period = "month"}} title={language.month}/>
    <ButtonActive active={period === "year"} onclick={() => {period = "year"}} title={language.year}/>
  </section>
  <Schedule {points}/>
</SharedSkelet>