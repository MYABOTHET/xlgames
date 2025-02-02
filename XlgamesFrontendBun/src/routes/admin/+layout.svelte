<script>
  import PrimaryNav from "$lib/components/nav/PrimaryNav.svelte";
  import PrimaryPage from "$lib/components/pages/PrimaryPage.svelte";
  
  const {children, data} = $props();
</script>

<svelte:head>
  <meta content="noindex, nofollow" name="robots"/>
  <meta content="initial-scale=0.1" name="viewport"/>
  <title>{data.title}</title>
</svelte:head>

<div class="flex h-full">
  <PrimaryNav links={data.links}/>
  <PrimaryPage>
    {@render children?.()}
  </PrimaryPage>
</div>
