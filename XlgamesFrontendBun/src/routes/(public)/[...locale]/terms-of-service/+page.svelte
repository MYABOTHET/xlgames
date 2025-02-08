<script>
  import {getContext} from "svelte";
  import SecondarySection from "$lib/components/sections/SecondarySection.svelte";
  import {transformLocale} from "$lib/tools.js";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
  let languageDto = $derived(getContext("languageDto")());
</script>

<svelte:head>
  <title>{language.TermsService.Title} - {data.projectData.Name}</title>
  {@html language.TermsService.Head}
</svelte:head>

<article class="secondary-section">
  <h1 class="primary-title">{language.TermsService.Name}</h1>
  <p>{language.TermsService.Description}</p>
  {#if language.TermsService.TermsServiceCollection.length}
    <SecondarySection items={language.TermsService.TermsServiceCollection}/>
  {/if}
  <p>{language.Shared.AnyQuestionsStart}<a class="primary-link"
                                           href={transformLocale(languageDto.Lang, "/contacts")}>{language.Shared.AnyQuestionsCenter}</a>{language.Shared.AnyQuestionsEnd}
  </p>
</article>