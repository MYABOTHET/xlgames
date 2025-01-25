<script>
  import SecondaryPreset from "$lib/components/presets/SecondaryPreset.svelte";
  
  let {value = $bindable(), title, ...props} = $props();
</script>

<SecondaryPreset {...props} {title}>
  <input autocomplete="off" bind:checked={value} class="accent-(--color-ternary)" name={value} spellcheck="false"
         type="checkbox"/>
</SecondaryPreset>

<style>
  @reference "tailwindcss/theme";
  
  input[type="checkbox"] {
    @apply size-5;
  }
</style>