<script>
  import PrimaryPage from "$lib/components/pages/PrimaryPage.svelte";
  import PrimaryNav from "$lib/components/nav/PrimaryNav.svelte";
  import {setContext} from "svelte";
  
  const {children, data} = $props();
  
  let links = $state(data.links);
  
  setContext("links", links);
</script>

<PrimaryNav links={[{title: "Создать игр. сервер", href: `/admin/game-servers/create`}, ...links]}/>

<PrimaryPage>
  {@render children?.()}
</PrimaryPage>