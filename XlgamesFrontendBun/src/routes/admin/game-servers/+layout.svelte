<script>
  import PrimaryPage from "$lib/components/pages/PrimaryPage.svelte";
  import PrimaryNav from "$lib/components/nav/PrimaryNav.svelte";
  
  const {children, data} = $props();
</script>

<PrimaryNav links={[{title: "Создать ", href: `/admin/game-servers/create`}, ...data.links]}/>

<PrimaryPage>
  {@render children?.()}
</PrimaryPage>