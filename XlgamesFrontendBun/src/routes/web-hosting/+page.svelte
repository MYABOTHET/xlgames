<script>
  import {getContext} from "svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
</script>

<svelte:head>
  <title>{language.WebHosting.Title} - {data.projectData.Name}</title>
  {@html language.WebHosting.Head}
</svelte:head>

<article class="secondary-section">
  <h1 class="primary-title">{language.WebHosting.Title}</h1>
  <p>{language.WebHosting.Description}</p>
</article>