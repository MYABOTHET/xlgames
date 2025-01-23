<script>
  import PrimaryNav from "$lib/components/nav/PrimaryNav.svelte";
  import PrimaryPage from "$lib/components/pages/PrimaryPage.svelte";
  
  const {children, data} = $props();
</script>

<svelte:head>
  <meta name="robots" content="noindex, nofollow" />
  <title>{data.title}</title>
</svelte:head>

<div class="flex h-full">
  <PrimaryNav links={data.links}/>
  <PrimaryPage>
    {@render children?.()}
  </PrimaryPage>
</div>
