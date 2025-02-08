<script>
  import {page} from '$app/state';
  
  const {data} = $props();
</script>

<svelte:head>
  <title>{page.error.message}</title>
</svelte:head>

<article class="flex-center h-full">
  <h1 class="text-(--color-quaternary) text-4xl font-medium">
    {page.error.message} | {page.status}
  </h1>
</article>