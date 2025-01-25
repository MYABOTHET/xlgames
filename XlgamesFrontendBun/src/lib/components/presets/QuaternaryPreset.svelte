<script>
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import OctalPreset from "$lib/components/presets/OctalPreset.svelte";
  
  let {object = $bindable(), index, up, down, deleteItem, length, ...props} = $props();
</script>

<OctalPreset {index} {up} {down} {deleteItem} {length}>
  <PrimaryTextarea bind:value={object.Name} title="Заголовок"/>
  <PrimaryTextarea bind:value={object.Description} title="Описание"/>
</OctalPreset>