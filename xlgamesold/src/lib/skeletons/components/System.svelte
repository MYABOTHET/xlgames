<script>
  import ControlPanel from "../../components/ControlPanel.svelte";
  import SystemInfo from "../../components/SystemInfo.svelte";
  import Section from "../../components/Section.svelte";
  
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
    <SystemInfo class="truncate" {system} {language}/>
    <ControlPanel class="min-w-44 max-sm:w-full" {on} {off} {reboot} {language} state={system.state}/>
  </div>
</Section>