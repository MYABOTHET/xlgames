<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";
  
  let language = getContext("language")();
</script>

<SecondaryPage title="Новости">
  <QuaternarySection title="Важное">
    <PrimaryTextarea bind:value={language.News.Title} title="Название страницы"/>
    <PrimaryTextarea bind:value={language.News.Head} title="Метаданные"/>
  </QuaternarySection>
  <QuaternarySection title="Остальное">
    <PrimaryTextarea bind:value={language.News.Name} title="Заголовок"/>
  </QuaternarySection>
</SecondaryPage>