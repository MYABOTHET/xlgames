<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";
  
  let language = getContext("language")();
</script>

<SecondaryPage title="Игровые серверы">
  <QuaternarySection title="Важное">
    <PrimaryTextarea bind:value={language.GameServers.Title} title="Название страницы"/>
    <PrimaryTextarea bind:value={language.GameServers.Head} title="Метаданные"/>
  </QuaternarySection>
  <QuaternarySection title="Остальное">
    <PrimaryTextarea bind:value={language.GameServers.Name} title="Заголовок"/>
    <PrimaryTextarea bind:value={language.GameServers.All} title="Все"/>
    <PrimaryTextarea bind:value={language.GameServers.Popular} title="Популярные"/>
    <PrimaryTextarea bind:value={language.GameServers.Search} title="Поиск"/>
  </QuaternarySection>
</SecondaryPage>