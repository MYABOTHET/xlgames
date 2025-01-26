<script>
  import QuaternaryPreset from "$lib/components/presets/QuaternaryPreset.svelte";
  import NinePreset from "$lib/components/presets/NinePreset.svelte";
  
  let {list = $bindable(), ...props} = $props();
</script>

<NinePreset Component={QuaternaryPreset} length={list.length} {...props} bind:list
onclick={() => {list.push({Name: "...", Description: "..."})}}/>