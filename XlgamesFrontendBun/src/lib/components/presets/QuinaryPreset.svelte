<script>
  import QuaternaryPreset from "$lib/components/presets/QuaternaryPreset.svelte";
  import NinePreset from "$lib/components/presets/NinePreset.svelte";
  
  let {list = $bindable(), title, ...props} = $props();
</script>

<NinePreset Component={QuaternaryPreset} length={list.length} {title} {list}
onclick={() => {list.push({Name: "...", Description: "..."})}}/>