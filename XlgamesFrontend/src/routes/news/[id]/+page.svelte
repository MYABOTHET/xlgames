<script>
  import {getContext} from "svelte";
  import {createDateFormatter} from "$lib/tools.js";
  import PrimaryArrow from "$lib/components/svg/PrimaryArrow.svelte";
  
  const {data} = $props();
  const {projectData} = data;
  const {name} = projectData;
  
  let language = $derived(getContext("language")());
  let locale = $derived(getContext("locale")());
  let news = $state(data.news);
  let dateFormatter = $derived(createDateFormatter(locale));
  const newsParentId = news.ParentId;
  
  $effect(async () => {
    if (language.Locale !== locale) {
      news = await (await fetch(`${newsParentId}?locale=${locale}`)).json();
    }
  });
</script>

<svelte:head>
  <title>{language.News.Title} - {news.Name} - {name}</title>
</svelte:head>

<div class="max-w-screen-hexadecimal w-full mx-auto">
  <article class="w-full flex flex-col ternary-gap-y">
    <a href="/news" class="flex-center transition-colors gap-x-6 text-white fill-white
hover:text-ternary hover:fill-ternary w-fit">
      <h1 class="order-2 primary-title">{news.Name}</h1>
      <PrimaryArrow class="ternary-width -rotate-90 order-1"/>
    </a>
    <div class="flex flex-col gap-y-6">
      <img src={news.Src} alt={news.Name} class="rounded-2xl ternary-size quaternary-height">
      <p class="text-quaternary text-xs mx-auto font-normal">{dateFormatter.format(new Date(news.Date))}</p>
    </div>
    {#if news.Description}
      <div class="description">
        {@html news.Description}
      </div>
    {/if}
  </article>
</div>

<style lang="postcss">
  .description :global {
    @apply text-sm leading-[1.375rem] flex flex-col gap-y-4 text-wrap;
    
    ul, ol {
      @apply flex flex-col gap-y-4;
    }
    
    ul {
      @apply list-disc pl-3.5;
    }
    
    ol {
      @apply list-decimal pl-4;
    }
    
    h1, h2, h3, h4, h5, h6, strong {
      @apply font-medium-up;
    }
    
    h1 { @apply text-2xl; }
    h2 { @apply text-xl; }
    h3 { @apply text-lg; }
    h4 { @apply text-sm; }
    h5 { @apply text-xs; }
    h6 { @apply text-[0.625rem] leading-[0.75rem]; }
    
    a {
      @apply primary-link;
    }
  }
</style>