<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";
  
  let language = getContext("language")();
</script>

<SecondaryPage title="О нас">
  <QuaternarySection title="Важное">
    <PrimaryTextarea bind:value={language.AboutUs.Title} title="Название страницы"/>
    <PrimaryTextarea bind:value={language.AboutUs.Head} title="Метаданные"/>
  </QuaternarySection>
  <QuaternarySection title="Остальное">
    <PrimaryTextarea bind:value={language.AboutUs.Name} title="Заголовок"/>
    <PrimaryTextarea bind:value={language.AboutUs.Description} title="Описание"/>
  </QuaternarySection>
</SecondaryPage>