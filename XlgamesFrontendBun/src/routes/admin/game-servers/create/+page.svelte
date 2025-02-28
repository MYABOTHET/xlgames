<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import SaveForm from "$lib/components/SaveForm.svelte";
  import {getContext} from "svelte";
  import {goto} from "$app/navigation";
  
  let links = getContext("links");
  let name = $state("...");
  let access = $state(null);
  let error = $state(null);
  
  async function createGameServer() {
    access = null;
    error = null;
    const response = await fetch(`/admin/game-servers/create`, {
      method: "POST",
      body: name
    });
    if (response.status === 200) {
      const gameServer = await response.json();
      links.push({
        title: gameServer.Name, href: `/admin/game-servers/${gameServer.Id}`, id: gameServer.Id
      }).sort((a, b) => a.title.localeCompare(b.title, "ru-RU"));
      await goto(`/admin/game-servers/${gameServer.Id}`);
    } else {
      access = false;
      error = await response.text();
    }
  }
</script>

<SecondaryPage title="Создать игровой сервер">
  <QuaternarySection title="Данные игрового сервера">
    <PrimaryTextarea bind:value={name} title="Название игрового сервера | Minecraft"/>
  </QuaternarySection>
  <SaveForm {access} {error} onclick={createGameServer} saved="Успешно" title="Создать игровой сервер"/>
</SecondaryPage>