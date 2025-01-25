<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";
  import QuinaryPreset from "$lib/components/presets/QuinaryPreset.svelte";
  
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
    <QuinaryPreset bind:list={language.VPN.VPNCollection} title="Перечисление"/>
  </QuaternarySection>
</SecondaryPage>