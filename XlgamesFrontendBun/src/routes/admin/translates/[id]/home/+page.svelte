<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";
  import TernaryPreset from "$lib/components/presets/TernaryPreset.svelte";
  import QuinaryPreset from "$lib/components/presets/QuinaryPreset.svelte";
  
  let language = getContext("language")();
</script>

<SecondaryPage title="Главная">
  <QuaternarySection title="Важное">
    <PrimaryTextarea bind:value={language.Home.Title} title="Название страницы"/>
    <PrimaryTextarea bind:value={language.Home.Head} title="Метаданные"/>
  </QuaternarySection>
  <QuaternarySection title="Навигационные блоки">
    <TernaryPreset bind:object={language.Home.ServersWithoutGPU} title="Серверы без видеокарты"/>
    <TernaryPreset bind:object={language.Home.VPS} title="VPS"/>
    <TernaryPreset bind:object={language.Home.WebHosting} title="Веб хостинг"/>
    <TernaryPreset bind:object={language.Home.VPN} title="VPN"/>
    <TernaryPreset bind:object={language.Home.ServersWithGPU} title="Серверы с видеокартой"/>
  </QuaternarySection>
  <QuaternarySection title="Дата центры">
    <PrimaryTextarea bind:value={language.Home.DataCentersDescription} title="Описание дата центров"/>
    <QuinaryPreset bind:list={language.Home.DataCenters} title="Дата центры"/>
  </QuaternarySection>
</SecondaryPage>