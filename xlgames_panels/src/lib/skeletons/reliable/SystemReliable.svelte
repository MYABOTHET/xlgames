<script>
  import Section from "../../components/Section.svelte";
  import ControlPanelReliable from "./ControlPanelReliable.svelte";
  import SystemInfoReliable from "./SystemInfoReliable.svelte";
  
  let {
    language,
    on,
    off,
    system,
  } = $props();
</script>

<Section title={language.system_info_title}>
  <div class="flex justify-between gap-2 max-sm:flex-col">
    <SystemInfoReliable class="truncate" {system} {language}/>
    <ControlPanelReliable class="min-w-44 max-sm:w-full" {on} {off} {language}/>
  </div>
</Section>