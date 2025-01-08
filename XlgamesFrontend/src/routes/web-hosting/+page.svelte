<script>
  import {getContext} from "svelte";
  
  const {data} = $props();
  const {projectData} = data;
  const {name} = projectData;
  
  let language = $derived(getContext("language")());
</script>

<svelte:head>
  <title>{language.WebHosting.Title} - {name}</title>
</svelte:head>

<article class="flex flex-col gap-y-14">
  <h1 class="primary-title">{language.WebHosting.Title}</h1>
  <p class="whitespace-pre-line">{language.WebHosting.Description}</p>
</article>