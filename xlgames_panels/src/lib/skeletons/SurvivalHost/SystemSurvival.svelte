<script>
  import Section from "../../components/Section.svelte";
  import SystemInfoSurvival from "./SystemInfoSurvival.svelte";
  import ControlPanel from "../../components/ControlPanel.svelte";
  
  let {
    language,
    on,
    off,
    reboot,
    system,
  } = $props();
</script>

<Section title={language.system_info_title}>
  <div class="flex justify-between gap-2 max-sm:flex-col">
    <SystemInfoSurvival class="truncate" {system} {language}/>
    <ControlPanel class="min-w-44 max-sm:w-full" {on} {off} {reboot} {language} state={system.status}/>
  </div>
</Section>