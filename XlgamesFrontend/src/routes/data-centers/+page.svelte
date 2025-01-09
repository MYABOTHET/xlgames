<script>
  import {getContext} from "svelte";
  import SecondarySection from "$lib/components/sections/SecondarySection.svelte";
  import PrimaryList from "$lib/components/lists/PrimaryList.svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
</script>

<svelte:head>
  <title>{language.DataCenters.Title} - {data.projectData.Name}</title>
  {@html language.DataCenters.Head}
</svelte:head>

<article class="flex flex-col ternary-gap-y">
  <h1 class="primary-title">{language.DataCenters.Title}</h1>
  <p>{language.DataCenters.Description}</p>
  {#if language.DataCenters.DataCenterCollection.length}
    <SecondarySection items={language.DataCenters.DataCenterCollection}/>
  {/if}
  {#if language.DataCenters.DataCenterPoints.length}
    <PrimaryList items={language.DataCenters.DataCenterPoints}/>
  {/if}
</article>