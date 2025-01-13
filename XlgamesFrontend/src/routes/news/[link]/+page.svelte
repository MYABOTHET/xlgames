<script>
  import {getContext, onMount} from "svelte";
  import {createDateFormatter} from "$lib/tools.js";
  import PrimaryArrow from "$lib/components/svg/PrimaryArrow.svelte";
  import {replaceState} from "$app/navigation";
  import {page} from "$app/state";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
  let languageDto = $derived(getContext("languageDto")());
  let news = $state(data.news);
  let dateFormatter = $derived(createDateFormatter(languageDto.Locale));
  const newsParentId = data.news.ParentId;
  
  $effect(async () => {
    if (language.Locale !== languageDto.Locale) {
      let result = await (await fetch(`/news/${newsParentId}`)).json();
      replaceState(`/news/${result.LinkName}`, {
        result
      });
      news = result;
    }
  });
  
  onMount(() => {
    const result = page.state.result;
    if (result) {
      if (news.Name !== result.Name) {
        news = result;
      }
    }
  });
</script>

<svelte:head>
  <title>{language.News.Title} - {news.Name} - {data.projectData.Name}</title>
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
    
    a { @apply transition-colors text-ternary hover:text-quaternary; }
    
    iframe {
      @apply w-full;
    }
  }
</style>