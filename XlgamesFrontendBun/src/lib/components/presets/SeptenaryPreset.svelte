<script>
  import OctalPreset from "$lib/components/presets/OctalPreset.svelte";
  import SecondaryTextarea from "$lib/components/textarea/SecondaryTextarea.svelte";
  
  let {object = $bindable(), index, ...props} = $props();
</script>

<OctalPreset {...props} {index}>
  <SecondaryTextarea bind:value={object} title={object + " " + index}/>
</OctalPreset>