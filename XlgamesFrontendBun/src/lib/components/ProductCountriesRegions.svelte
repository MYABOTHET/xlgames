<script>
  import DecimalPreset from "$lib/components/presets/DecimalPreset.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryCheckbox from "$lib/components/checkbox/PrimaryCheckbox.svelte";
  
  let {product = $bindable(), ...props} = $props();
</script>

<QuaternarySection childrenProps="gap-y-8" title="Страны и регионы">
  <DecimalPreset bind:value={product.Germany} title="Германия" off={() => {
      product.Falkenstein = false;
      product.Frankfurt = false;
      product.Nuremberg = false;
    }}>
    <PrimaryCheckbox bind:value={product.Falkenstein} title="Фалькенштайн"/>
    <PrimaryCheckbox bind:value={product.Frankfurt} title="Франкфурт"/>
    <PrimaryCheckbox bind:value={product.Nuremberg} title="Нюрнберг"/>
  </DecimalPreset>
  <DecimalPreset bind:value={product.Finland} title="Финляндия" off={() => {
      product.Helsinki = false;
    }}>
    <PrimaryCheckbox bind:value={product.Helsinki} title="Хельсинки"/>
  </DecimalPreset>
  <DecimalPreset bind:value={product.Russia} title="Россия" off={() => {
      product.Moscow = false;
      product.SaintPetersburg = false;
    }}>
    <PrimaryCheckbox bind:value={product.Moscow} title="Москва"/>
    <PrimaryCheckbox bind:value={product.SaintPetersburg} title="Санкт-Петербург"/>
  </DecimalPreset>
  <DecimalPreset bind:value={product.USA} title="США" off={() => {
      product.NewYork = false;
      product.Miami = false;
      product.LosAngeles = false;
      product.Hillsboro = false;
      product.Ashburn = false;
    }}>
    <PrimaryCheckbox bind:value={product.NewYork} title="Нью-Йорк"/>
    <PrimaryCheckbox bind:value={product.Miami} title="Майами"/>
    <PrimaryCheckbox bind:value={product.LosAngeles} title="Лос-Анджелес"/>
    <PrimaryCheckbox bind:value={product.Hillsboro} title="Хилсборо"/>
    <PrimaryCheckbox bind:value={product.Ashburn} title="Ашберн"/>
  </DecimalPreset>
  <PrimaryCheckbox bind:value={product.Singapore} title="Сингапур"/>
</QuaternarySection>