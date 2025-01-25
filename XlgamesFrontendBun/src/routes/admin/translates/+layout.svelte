<script>
  import PrimaryPage from "$lib/components/pages/PrimaryPage.svelte";
  import PrimaryNav from "$lib/components/nav/PrimaryNav.svelte";
  import {setContext} from "svelte";
  
  const {children, data} = $props();
  
  let links = $state(data.links);
  let sorted = $derived(links.slice().sort((a, b) => a.title.localeCompare(b.title, "ru-RU")));
  
  setContext("links", links);
</script>

<PrimaryNav links={[{title: "Создать язык", href: "/admin/translates/create"}, ...sorted]}/>

<PrimaryPage>
  {@render children?.()}
</PrimaryPage>