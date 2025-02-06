<script>
  import {getContext} from "svelte";
  import SecondarySection from "$lib/components/sections/SecondarySection.svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
</script>

<svelte:head>
  <title>{language.CookiePolicy.Title} - {data.projectData.Name}</title>
  {@html language.CookiePolicy.Head}
</svelte:head>

<article class="secondary-section">
  <h1 class="primary-title">{language.CookiePolicy.Name}</h1>
  <p>{language.CookiePolicy.Description}</p>
  {#if language.CookiePolicy.CookiePolicyCollection.length}
    <SecondarySection items={language.CookiePolicy.CookiePolicyCollection}/>
  {/if}
  <p>{language.Shared.AnyQuestionsStart}<a class="primary-link"
                                           href="/contacts">{language.Shared.AnyQuestionsCenter}</a>{language.Shared.AnyQuestionsEnd}
  </p>
</article>