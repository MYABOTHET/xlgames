<script>
  import SecondaryPreset from "$lib/components/presets/SecondaryPreset.svelte";
  import SecondaryTextarea from "$lib/components/textarea/SecondaryTextarea.svelte";
  
  let {value = $bindable(), title, ...props} = $props();
</script>

<SecondaryPreset {...props} {title}>
  <SecondaryTextarea bind:value {title}/>
</SecondaryPreset>