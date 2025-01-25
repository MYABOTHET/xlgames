<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";
  import QuinaryPreset from "$lib/components/presets/QuinaryPreset.svelte";
  import HexadecimalPreset from "$lib/components/presets/HexadecimalPreset.svelte";
  
  let language = getContext("language")();
</script>

<SecondaryPage title="Дата центры">
  <QuaternarySection title="Важное">
    <PrimaryTextarea bind:value={language.DataCenters.Title} title="Название страницы"/>
    <PrimaryTextarea bind:value={language.DataCenters.Head} title="Метаданные"/>
  </QuaternarySection>
  <QuaternarySection title="Остальное">
    <PrimaryTextarea bind:value={language.DataCenters.Name} title="Заголовок"/>
    <PrimaryTextarea bind:value={language.DataCenters.Description} title="Описание"/>
    <QuinaryPreset bind:list={language.DataCenters.DataCenterCollection} title="Дата центры"/>
    <HexadecimalPreset bind:list={language.DataCenters.DataCenterPoints} title="Перечисление"/>
  </QuaternarySection>
</SecondaryPage>