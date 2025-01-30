<script>
  import DecimalPreset from "$lib/components/presets/DecimalPreset.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryCheckbox from "$lib/components/checkbox/PrimaryCheckbox.svelte";
  
  let {product = $bindable(), ...props} = $props();
</script>

<QuaternarySection childrenProps="gap-y-8" title="Страны и регионы">
  <DecimalPreset bind:value={product.Germany} off={() => {
      product.Falkenstein = false;
      product.Frankfurt = false;
      product.Nuremberg = false;
    }} title="Германия">
    <PrimaryCheckbox bind:value={product.Falkenstein} title="Фалькенштайн"/>
    <PrimaryCheckbox bind:value={product.Frankfurt} title="Франкфурт"/>
    <PrimaryCheckbox bind:value={product.Nuremberg} title="Нюрнберг"/>
  </DecimalPreset>
  <DecimalPreset bind:value={product.Finland} off={() => {
      product.Helsinki = false;
    }} title="Финляндия">
    <PrimaryCheckbox bind:value={product.Helsinki} title="Хельсинки"/>
  </DecimalPreset>
  <DecimalPreset bind:value={product.Russia} off={() => {
      product.Moscow = false;
      product.SaintPetersburg = false;
      product.Orenburg = false;
      product.Ekaterenburg = false;
      product.Vladivastok = false;
    }} title="Россия">
    <PrimaryCheckbox bind:value={product.Moscow} title="Москва"/>
    <PrimaryCheckbox bind:value={product.SaintPetersburg} title="Санкт-Петербург"/>
    <PrimaryCheckbox bind:value={product.Orenburg} title="Оренбург"/>
    <PrimaryCheckbox bind:value={product.Ekaterenburg} title="Екатеринбург"/>
    <PrimaryCheckbox bind:value={product.Vladivastok} title="Владивосток"/>
  </DecimalPreset>
  <DecimalPreset bind:value={product.USA} off={() => {
      product.NewYork = false;
      product.Miami = false;
      product.LosAngeles = false;
      product.Hillsboro = false;
      product.Ashburn = false;
    }} title="США">
    <PrimaryCheckbox bind:value={product.NewYork} title="Нью-Йорк"/>
    <PrimaryCheckbox bind:value={product.Miami} title="Майами"/>
    <PrimaryCheckbox bind:value={product.LosAngeles} title="Лос-Анджелес"/>
    <PrimaryCheckbox bind:value={product.Hillsboro} title="Хилсборо"/>
    <PrimaryCheckbox bind:value={product.Ashburn} title="Ашберн"/>
  </DecimalPreset>
  <PrimaryCheckbox bind:value={product.Singapore} title="Сингапур"/>
  <DecimalPreset bind:value={product.France} off={() => {
      product.Gravelines = false;
    }} title="Франция">
    <PrimaryCheckbox bind:value={product.Gravelines} title="Гравлин"/>
  </DecimalPreset>
</QuaternarySection>