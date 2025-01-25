<script>
  import OctalPreset from "$lib/components/presets/OctalPreset.svelte";
  import SecondaryTextarea from "$lib/components/textarea/SecondaryTextarea.svelte";
  
  let {object = $bindable(), index, up, down, deleteItem, length, ...props} = $props();
</script>

<OctalPreset {index} {up} {down} {deleteItem} {length}>
  <SecondaryTextarea bind:value={object} title={object + " " + index}/>
</OctalPreset>