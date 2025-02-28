<script module>
  let gameServer = $state(null);
</script>

<script>
  import PrimaryPage from "$lib/components/pages/PrimaryPage.svelte";
  import PrimaryNav from "$lib/components/nav/PrimaryNav.svelte";
  import {getContext, setContext} from "svelte";
  import {page} from "$app/state";
  import {goto} from "$app/navigation";
  
  const {children, data} = $props();
  
  gameServer = data.gameServer;
  let links = getContext("links");
  let access = $state(null);
  let error = $state(null);
  let init = $state.raw({init: false});
  let counter = $state(20);
  let timeout = $state(null);
  
  async function updateGameServer() {
    clearTimeout(timeout);
    access = null;
    error = null;
    const response = await fetch(`/admin/game-servers/${page.params.id}`, {
      method: "PUT",
      body: JSON.stringify(gameServer),
      headers: {
        'Content-Type': 'application/json'
      }
    });
    if (response.status === 200) {
      access = true;
      links.find(gameServerItem => gameServerItem.id === gameServer.Id).title = gameServer.Name;
      links.sort((a, b) => a.title.localeCompare(b.title, "ru-RU"));
    } else {
      access = false;
      error = await response.text();
    }
    timeout = setTimeout(() => {
      access = null;
      error = null;
    }, 5000);
  }
  
  async function deleteGameServer() {
    access = null;
    error = null;
    counter--;
    if (counter === 0) {
      const response = await fetch(`/admin/game-servers/${page.params.id}`, {
        method: "DELETE"
      });
      if (response.status === 200) {
        const index = links.findIndex(link => link.id === gameServer.Id);
        links.splice(index, 1);
        links.sort((a, b) => a.title.localeCompare(b.title, "ru-RU"));
        await goto(`/admin/game-servers`);
      } else {
        counter = 20;
        access = false;
        error = await response.text();
      }
    }
  }
  
  $effect(() => {
    data.gameServer;
    if (init.init) {
      gameServer = data.gameServer;
      access = null;
      error = null;
      counter = 20;
    } else {
      init.init = true;
    }
  });
  
  setContext("gameServer", () => gameServer);
  setContext("access", () => access);
  setContext("error", () => error);
  setContext("updateGameServer", updateGameServer);
  setContext("deleteGameServer", deleteGameServer);
  setContext("counter", () => counter);
</script>

<PrimaryNav links={data.linksOptions}/>

<PrimaryPage>
  {@render children?.()}
</PrimaryPage>