<script>
  import {getContext} from "svelte";
  import {createDateFormatter} from "$lib/tools.js";
  import PrimaryCard from "$lib/components/cards/PrimaryCard.svelte";
  
  const {data} = $props();
  const {projectData} = data;
  const {name} = projectData;
  
  let language = $derived(getContext("language")());
  let locale = $derived(getContext("locale")());
  let news = $state(data.news);
  let dateFormatter = $derived(createDateFormatter(locale));
  
  $effect(async () => {
    if (language.Locale !== locale) {
      news = await (await fetch(`?require=false&locale=${locale}`)).json();
    }
  });
</script>

<svelte:head>
  <title>{language.News.Title} - {name}</title>
</svelte:head>

<article class="flex flex-col gap-y-14">
  <h1 class="primary-title">{language.News.Title}</h1>
  {#if news.length}
    <nav class="grid grid-cols-2 max-quinary:grid-cols-1 primary-gap">
      {#each news as newsItem}
        <PrimaryCard name={newsItem.Name} description={dateFormatter.format(new Date(newsItem.Date))}
                     src={newsItem.Src} href="/news/{newsItem.ParentId}"
                     class="quaternary-height"/>
      {/each}
    </nav>
  {/if}
</article>