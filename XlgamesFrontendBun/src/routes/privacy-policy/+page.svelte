<script>
  import {getContext} from "svelte";
  import SecondarySection from "$lib/components/sections/SecondarySection.svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
</script>

<svelte:head>
  <title>{language.PrivacyPolicy.Title} - {data.projectData.Name}</title>
  {@html language.PrivacyPolicy.Head}
</svelte:head>

<article class="secondary-section">
  <h1 class="primary-title">{language.PrivacyPolicy.Title}</h1>
  <p>{language.PrivacyPolicy.Description}</p>
  {#if language.PrivacyPolicy.PrivacyPolicyCollection.length}
    <SecondarySection items={language.PrivacyPolicy.PrivacyPolicyCollection}/>
  {/if}
  <p>{language.Shared.AnyQuestionsStart}<a href="/contacts" class="primary-link">{language.Shared.AnyQuestionsCenter}</a>{language.Shared.AnyQuestionsEnd}</p>
</article>