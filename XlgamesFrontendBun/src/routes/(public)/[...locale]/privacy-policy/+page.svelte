<script>
  import {getContext} from "svelte";
  import {transformLocale} from "$lib/tools.js";
  import SecondarySection from "$lib/components/sections/SecondarySection.svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
  let languageDto = $derived(getContext("languageDto")());
</script>

<svelte:head>
  <title>{language.PrivacyPolicy.Title} - {data.projectData.Name}</title>
  {@html language.PrivacyPolicy.Head}
</svelte:head>

<article class="secondary-section">
  <h1 class="primary-title">{language.PrivacyPolicy.Name}</h1>
  <p>{language.PrivacyPolicy.Description}</p>
  {#if language.PrivacyPolicy.PrivacyPolicyCollection.length}
    <SecondarySection items={language.PrivacyPolicy.PrivacyPolicyCollection}/>
  {/if}
  <p>{language.Shared.AnyQuestionsStart}<a class="primary-link"
                                           href={transformLocale(languageDto.Lang, "/contacts")}>{language.Shared.AnyQuestionsCenter}</a>{language.Shared.AnyQuestionsEnd}
  </p>
</article>