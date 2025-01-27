<script>
  import PrimaryPage from "$lib/components/pages/PrimaryPage.svelte";
  import PrimaryNav from "$lib/components/nav/PrimaryNav.svelte";
  
  const {children, data} = $props();
</script>

<PrimaryNav links={data.links}/>

<PrimaryPage>
  {@render children?.()}
</PrimaryPage>