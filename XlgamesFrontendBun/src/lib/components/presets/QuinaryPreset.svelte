<script>
  import QuaternaryPreset from "$lib/components/presets/QuaternaryPreset.svelte";
  import NinePreset from "$lib/components/presets/NinePreset.svelte";
  
  let {list = $bindable(), ...props} = $props();
</script>

<NinePreset {...props} Component={QuaternaryPreset} bind:list length={list.length}
            onclick={() => {list.push({Name: "...", Description: "..."})}}/>