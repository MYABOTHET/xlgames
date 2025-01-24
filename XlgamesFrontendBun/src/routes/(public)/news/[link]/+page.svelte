<script>
  import {getContext} from "svelte";
  import {createDateFormatter} from "$lib/tools.js";
  import SecondaryLink from "$lib/components/links/SecondaryLink.svelte";
  import {replaceState} from "$app/navigation";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
  let languageDto = $derived(getContext("languageDto")());
  let news = $state.raw(data.news);
  let dateFormatter = $derived(createDateFormatter(language.Locale));
  const newsParentId = data.news.ParentId;
  
  $effect(async () => {
    if (language.Locale !== languageDto.Locale) {
      const result = await (await fetch(`/news/${newsParentId}`)).json();
      replaceState(`/news/${result.LinkName}`, {});
      news = result;
    }
  });
</script>

<svelte:head>
  <meta name="robots" content="noindex, nofollow" />
  <title>{language.News.Title} - {news.Name} - {data.projectData.Name}</title>
</svelte:head>

<div class="max-w-(--breakpoint-hexadecimal) w-full mx-auto">
  <article class="secondary-section">
    <SecondaryLink name={news.Name} href="/news"/>
    <div class="flex flex-col gap-y-6">
      <img src={news.Src} alt={news.Name} class="rounded-2xl ternary-size quaternary-height">
      <p class="text-(--color-quaternary) text-xs mx-auto font-normal">{dateFormatter.format(new Date(news.Date))}</p>
    </div>
    {#if news.Description}
      <div class="description">
        {@html news.Description}
      </div>
    {/if}
  </article>
</div>

<style>
  @reference "tailwindcss/theme";
  
  .description :global {
    @apply text-sm leading-[1.375rem] flex flex-col gap-y-4 text-wrap;
    
    ul, ol {
      @apply flex flex-col gap-y-4;
    }
    
    li > ul, li > ol {
      @apply gap-y-2 pt-2;
    }
    
    ul {
      @apply list-disc pl-3.5;
    }
    
    ol {
      @apply list-decimal pl-4;
    }
    
    h1, h2, h3, h4, h5, h6, strong {
      @apply font-(--font-weight-medium-up);
    }
    
    h1 { @apply text-2xl; }
    h2 { @apply text-xl; }
    h3 { @apply text-lg; }
    h4 { @apply text-sm; }
    h5 { @apply text-xs; }
    h6 { @apply text-[0.625rem] leading-[0.75rem]; }
    
    a { @apply transition-colors text-(--color-ternary) hover:text-(--color-quaternary); }
    
    iframe {
      @apply w-full;
    }
  }
</style>