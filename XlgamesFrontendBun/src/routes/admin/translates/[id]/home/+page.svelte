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
    <TernaryPreset title="Серверы без видеокарты" bind:object={language.Home.ServersWithoutGPU}/>
    <TernaryPreset title="VPS" bind:object={language.Home.VPS}/>
    <TernaryPreset title="Веб хостинг" bind:object={language.Home.WebHosting}/>
    <TernaryPreset title="VPN" bind:object={language.Home.VPN}/>
    <TernaryPreset title="Серверы с видеокартой" bind:object={language.Home.ServersWithGPU}/>
  </QuaternarySection>
  <QuaternarySection title="Дата центры">
    <PrimaryTextarea bind:value={language.Home.DataCentersDescription} title="Описание дата центров"/>
    <QuinaryPreset bind:list={language.Home.DataCenters} title="Дата центры"/>
  </QuaternarySection>
</SecondaryPage>