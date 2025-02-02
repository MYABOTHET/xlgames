<script>
  import SecondaryPreset from "$lib/components/presets/SecondaryPreset.svelte";
  let {product = $bindable(), ...props} = $props();
  
  function setGB() {
    product.GB = true;
    product.TB = false;
  }
  
  function setTB() {
    product.GB = false;
    product.TB = true;
  }
</script>

{#snippet radio(title, value, onclick)}
  <SecondaryPreset {title}>
    <button aria-label="radio" {onclick} class="{value ? 'bg-(--color-ternary) border-none' : 'border-(--color-hexadecimal)'} rounded-full size-5 border-2 bg-(--color-octal) my-auto"></button>
  </SecondaryPreset>
{/snippet}

{@render radio("ГБ", product.GB, setGB)}
{@render radio("ТБ", product.TB, setTB)}