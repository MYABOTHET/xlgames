<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";
  
  let language = getContext("language")();
</script>

<SecondaryPage title="Серверы без видеокарты">
  <QuaternarySection title="Важное">
    <PrimaryTextarea bind:value={language.ServersWithoutGPU.Title} title="Название страницы"/>
    <PrimaryTextarea bind:value={language.ServersWithoutGPU.Head} title="Метаданные"/>
  </QuaternarySection>
  <QuaternarySection title="Остальное">
    <PrimaryTextarea bind:value={language.ServersWithoutGPU.Name} title="Заголовок"/>
    <PrimaryTextarea bind:value={language.ServersWithoutGPU.Description} title="Описание"/>
  </QuaternarySection>
</SecondaryPage>