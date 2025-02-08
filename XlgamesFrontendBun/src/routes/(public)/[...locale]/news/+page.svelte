<script>
  import {getContext} from "svelte";
  import {createDateFormatter, transformLocale} from "$lib/tools.js";
  import PrimaryCard from "$lib/components/cards/PrimaryCard.svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
  let languageDto = $derived(getContext("languageDto")());
  let news = $state.raw(data.news);
  let dateFormatter = $derived(createDateFormatter(language.Locale));
  
  $effect(async () => {
    if (language.Locale !== languageDto.Locale) {
      news = await (await fetch(`/news?WHMCSName=${languageDto.WHMCSName}`)).json();
    }
  });
</script>

<svelte:head>
  <title>{language.News.Title} - {data.projectData.Name}</title>
  {@html language.News.Head}
</svelte:head>

<article class="secondary-section">
  <h1 class="primary-title">{language.News.Name}</h1>
  {#if news.length}
    <nav class="grid grid-cols-2 max-quinary:grid-cols-1 primary-gap">
      {#each news as newsItem}
        <PrimaryCard name={newsItem.Name} description={dateFormatter.format(new Date(newsItem.Date))}
                     src={newsItem.Src} href={transformLocale(languageDto.Lang, `/news/${newsItem.LinkName}`)}
                     class="quaternary-height" rel="nofollow"/>
      {/each}
    </nav>
  {/if}
</article>