<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";
  import QuinaryPreset from "$lib/components/presets/QuinaryPreset.svelte";
  import PrimaryCheckbox from "$lib/components/checkbox/PrimaryCheckbox.svelte";
  import HexadecimalPreset from "$lib/components/presets/HexadecimalPreset.svelte";
  
  let language = getContext("language")();
</script>

<SecondaryPage title="VPN">
  <QuaternarySection title="Важное">
    <PrimaryTextarea bind:value={language.VPN.Title} title="Название страницы"/>
    <PrimaryTextarea bind:value={language.VPN.Head} title="Метаданные"/>
  </QuaternarySection>
  <QuaternarySection title="Остальное">
    <PrimaryTextarea bind:value={language.VPN.Name} title="Заголовок"/>
    <PrimaryTextarea bind:value={language.VPN.Description} title="Описание"/>
    <PrimaryTextarea bind:value={language.VPN.Tariffs} title="Тарифы"/>
    <PrimaryTextarea bind:value={language.VPN.OneMonth} title="Один месяц"/>
    <PrimaryTextarea bind:value={language.VPN.ThreeMonths} title="Три месяца"/>
    <PrimaryTextarea bind:value={language.VPN.HalfYear} title="Шесть месяцев"/>
    <PrimaryTextarea bind:value={language.VPN.Year} title="Год"/>
    <PrimaryTextarea bind:value={language.VPN.Discount} title="Скидка"/>
    <PrimaryTextarea bind:value={language.VPN.DiscountThreeMonths} title="Скидка (три месяца)"/>
    <PrimaryTextarea bind:value={language.VPN.DiscountHalfYear} title="Скидка (шесть месяцов)"/>
    <PrimaryTextarea bind:value={language.VPN.DiscountYear} title="Скидка (год)"/>
    <PrimaryCheckbox bind:value={language.VPN.DiscountPosition} title="Число скидки находится перед текстом 'Скидка'?"/>
    <QuinaryPreset bind:list={language.VPN.VPNCollection} title="Перечисление"/>
    <HexadecimalPreset bind:list={language.VPN.VPNPoints} title="Описание для карточек"/>
  </QuaternarySection>
</SecondaryPage>