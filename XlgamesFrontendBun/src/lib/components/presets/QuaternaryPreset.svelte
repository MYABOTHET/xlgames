<script>
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import OctalPreset from "$lib/components/presets/OctalPreset.svelte";
  
  let {object = $bindable(), ...props} = $props();
</script>

<OctalPreset {...props}>
  <PrimaryTextarea bind:value={object.Name} title="Заголовок"/>
  <PrimaryTextarea bind:value={object.Description} title="Описание"/>
</OctalPreset>