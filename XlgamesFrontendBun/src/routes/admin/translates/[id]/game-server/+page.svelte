<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";
  
  let language = getContext("language")();
</script>

<SecondaryPage title="Игровой сервер">
  <QuaternarySection title="Важное">
    <PrimaryTextarea bind:value={language.GameServer.Title} title="Название страницы"/>
    <PrimaryTextarea bind:value={language.GameServer.Head} title="Метаданные"/>
  </QuaternarySection>
  <QuaternarySection title="Остальное">
    <PrimaryTextarea bind:value={language.GameServer.Name} title="Заголовок"/>
    <PrimaryTextarea bind:value={language.GameServer.Unlimited} title="Неограничено"/>
  </QuaternarySection>
</SecondaryPage>