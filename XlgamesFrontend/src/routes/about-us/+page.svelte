<script>
  import {getContext} from "svelte";
  
  const {data} = $props();
  const {projectData} = data;
  const {name} = projectData;
  
  let language = $derived(getContext("language")());
</script>

<svelte:head>
  <title>{language.AboutUs.Title} - {name}</title>
</svelte:head>

<div class="max-w-screen-hexadecimal w-full mx-auto">
  <article class="w-full flex flex-col ternary-gap-y">
    <h1 class="primary-title">{language.AboutUs.Name}</h1>
    <img src={language.AboutUs.Src} alt={language.AboutUs.Name} class="rounded-2xl ternary-size quaternary-height">
    <p class="text-sm leading-[1.375rem] whitespace-pre-line">
      {language.AboutUs.Description}
      
      {language.Shared.AnySuggestionsStart}
      <a href="/contacts" class="primary-link">{language.Shared.AnySuggestionsCenter}</a>
      {language.Shared.AnySuggestionsEnd}
    </p>
  </article>
</div>