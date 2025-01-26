<script>
  import NinePreset from "$lib/components/presets/NinePreset.svelte";
  import SeptenaryPreset from "$lib/components/presets/SeptenaryPreset.svelte";
  
  let {list = $bindable(), ...props} = $props();
</script>

<NinePreset Component={SeptenaryPreset} length={list.length} {...props} {list} onclick={() => {list.push("...")}}/>