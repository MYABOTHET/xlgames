<script>
  import Information from "../../presets/shared/Information.svelte";
  import AvailableOS from "../../components/shared/AvailableOS.svelte";
  import VerticalLine from "../../components/shared/VerticalLine.svelte";
  import HorizontalLine from "../../components/shared/HorizontalLine.svelte";
  import Controls from "../../presets/shared/Controls.svelte";
  import {process} from "../../index.js";
  // import ScheduleModule from "./ScheduleModule.svelte";

  let status = $state(information.status);
  let loading_control = $state(false);
  let os = $state(information.available_os[0] ?? "...");
  let gap = "gap-6";

  function execute_action(action, complete = () => {
  }) {
    execute_loading(async () => {
      const result = await process(action, {
        method: "POST"
      });
      if (result !== false) complete();
    });
  }

  async function execute_loading(callback) {
    loading_control = true;
    await callback();
    loading_control = false;
  }

  function reinstall_os() {
    let sure = confirm(`${language.are_you_sure_you_want_to_reinstall_the_os ?? "..."}\n\n* ${language.after_reinstalling_the_os_all_data_will_be_deleted_permanently_without_the_possibility_of_recovery ?? "..."}`);
    if (!sure) return;
    execute_loading(async () => {
      const result = await process("reinstall", {
        method: "POST",
        body: JSON.stringify({os})
      });
      if (result !== false) location.reload();
    });
  }
</script>

<section class="flex flex-col p-2 {gap}">
  <section class="flex items-stretch {gap}">
    <Controls {loading_control}
              on={information.on ? () => {execute_action("on", () => {status = true})} : null}
              off={information.off ? () => {execute_action("off", () => {status = false})} : null}
              reboot={information.reboot ? () => {execute_action("reboot")} : null} {status}/>
    <VerticalLine/>
    <Information ip={information.ip} login={information.login} os={information.os}
                 password={information.password}/>
    {#if information.available_os.length}
      <div class="flex {gap} ml-auto">
        <VerticalLine/>
        <AvailableOS {loading_control} available_os={information.available_os} {reinstall_os} bind:os/>
      </div>
    {/if}
  </section>
  {#if information.schedule}
    <HorizontalLine/>
    <schedule-module class="flex flex-col" style="gap: inherit"></schedule-module>
<!--    <ScheduleModule/>-->
  {/if}
</section>