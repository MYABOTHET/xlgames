<script>
  import NinePreset from "$lib/components/presets/NinePreset.svelte";
  import SeptenaryPreset from "$lib/components/presets/SeptenaryPreset.svelte";
  
  let {list = $bindable(), ...props} = $props();
</script>

<NinePreset {...props} Component={SeptenaryPreset} bind:list length={list.length} onclick={() => {list.push("...")}}/>