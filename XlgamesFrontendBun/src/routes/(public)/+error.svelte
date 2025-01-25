<script>
  import {page} from '$app/state';
  import {getContext} from "svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
</script>

<svelte:head>
  <title>{language.Shared.Error} - {data.projectData.Name}</title>
</svelte:head>

<article class="flex-center h-full">
  <h1 class="text-(--color-quaternary) text-4xl font-medium">
    {language.Shared.Error} | {page.status}
  </h1>
</article>