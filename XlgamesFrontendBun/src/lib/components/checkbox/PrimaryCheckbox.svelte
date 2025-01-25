<script>
  import SecondaryPreset from "$lib/components/presets/SecondaryPreset.svelte";
  
  let {value = $bindable(), title, ...props} = $props();
</script>

<SecondaryPreset {title} {...props}>
  <input name={value} bind:checked={value} spellcheck="false" autocomplete="off" type="checkbox"
         class="accent-(--color-ternary)"/>
</SecondaryPreset>

<style>
  @reference "tailwindcss/theme";
  
  input[type="checkbox"] {
    @apply size-5;
  }
</style>