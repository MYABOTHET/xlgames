<script>
  import {getContext} from "svelte";
  import {createDateFormatter, transformLocale} from "$lib/tools.js";
  import PrimarySection from "$lib/components/sections/PrimarySection.svelte";
  import PrimaryCard from "$lib/components/cards/PrimaryCard.svelte";
  import SecondaryCard from "$lib/components/cards/SecondaryCard.svelte";
  import SecondarySection from "$lib/components/sections/SecondarySection.svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
  let languageDto = $derived(getContext("languageDto")());
  let news = $state.raw(data.news);
  let dateFormatter = $derived(createDateFormatter(language.Locale));
  let priceFormatter = $derived(new Intl.NumberFormat(language.Locale));
  
  $effect(async () => {
    if (language.Locale !== languageDto.Locale) {
      news = await (await fetch(`/news?max=3&WHMCSName=${languageDto.WHMCSName}`)).json();
    }
  });
</script>

<svelte:head>
  <title>{language.Home.Title} - {data.projectData.Name}</title>
  {@html language.Home.Head}
</svelte:head>

{#snippet noCard(cardProps)}
  <div class="{cardProps} primary-block border-transparent">
    <div
        class="primary-block border-(--color-quaternary) text-(--color-quaternary) size-full flex-center font-medium text-lg">
      ≽^•⩊•^≼
    </div>
  </div>
{/snippet}

<div class="flex flex-col gap-y-28">
  {#if data.gameServers.length}
    <PrimarySection title={language.GameServers.Name} href={transformLocale(languageDto.Lang, "/games")}>
      <nav class="section">
        {#each data.gameServers as gameServer}
          {@const translate = gameServer.GameServerDataModels.find(item => item.LanguageId === language.Id)}
          {@const sign = language.Shared.CurrencySign}
          {@const position = language.Shared.CurrencySignPosition}
          {@const price = priceFormatter.format(translate.Price)}
          <PrimaryCard name={gameServer.Name} description="{language.Shared.PriceFrom}
{position ? sign + price : price + sign}"
                       src={gameServer.Src} class="secondary-size" href={transformLocale(languageDto.Lang, `/games/${gameServer.LinkName}`)}/>
        {/each}
        {#if data.max - data.gameServers.length >= 0}
          {#each {length: data.max - data.gameServers.length} as _}
            {@render noCard?.("secondary-size")}
          {/each}
        {/if}
      </nav>
    </PrimarySection>
  {/if}
  
  <section class="flex flex-wrap primary-gap">
    <SecondaryCard class="quaternary-size" description={language.Home.ServersWithoutGPU.Description}
                   href={transformLocale(languageDto.Lang, "/dedicated")}
                   name={language.Home.ServersWithoutGPU.Name}/>
    <SecondaryCard class="quaternary-size" description={language.Home.VPS.Description}
                   href={transformLocale(languageDto.Lang, "/vps")}
                   name={language.Home.VPS.Name}/>
    <SecondaryCard class="quaternary-size" description={language.Home.WebHosting.Description}
                   href={transformLocale(languageDto.Lang, "/web-hosting")}
                   name={language.Home.WebHosting.Name}/>
    <SecondaryCard class="quaternary-size" description={language.Home.VPN.Description}
                   href={transformLocale(languageDto.Lang, "/vpn")}
                   name={language.Home.VPN.Name}/>
    <SecondaryCard class="quaternary-size" description={language.Home.ServersWithGPU.Description}
                   href={transformLocale(languageDto.Lang, "/gpu-servers")}
                   name={language.Home.ServersWithGPU.Name}/>
  </section>
  
  <section
      class="{language.Home.DataCenters.length ? 'grid grid-cols-2 primary-gap-x max-secondary:grid-cols-1 max-secondary:gap-y-10' : ''}">
    <article class="flex flex-col primary-gap-y">
      <h1 class="primary-title">{language.DataCenters.Name}</h1>
      <p>{language.Home.DataCentersDescription}</p>
      <a class="quinary-block w-fit px-6 py-2.5"
         href={transformLocale(languageDto.Lang, "/data-centers")}>{language.Shared.ReadMore}</a>
    </article>
    {#if language.Home.DataCenters.length}
      <SecondarySection items={language.Home.DataCenters}
                        class="h-fit primary-block border-(--color-quaternary) secondary-p"/>
    {/if}
  </section>
  
  {#if news.length}
    <PrimarySection title={language.News.Name} href={transformLocale(languageDto.Lang, "/news")}>
      <nav class="section">
        {#each news as newsItem}
          <PrimaryCard name={newsItem.Name} description={dateFormatter.format(new Date(newsItem.Date))}
                       src={newsItem.Src} href={transformLocale(languageDto.Lang, `/news/${newsItem.LinkName}`)}
                       class="quinary-size" rel="nofollow"/>
        {/each}
        {#if data.maxNews - data.news.length >= 0}
          {#each {length: data.maxNews - data.news.length} as _}
            {@render noCard?.("quinary-size")}
          {/each}
        {/if}
      </nav>
    </PrimarySection>
  {/if}
</div>

<style>
  @reference "tailwindcss/theme";
  
  .section {
    @apply flex gap-8 overflow-x-scroll pb-1;
  }
  
  .section::-webkit-scrollbar {
    @apply h-1.5;
  }
  
  .section::-webkit-scrollbar-track {
    @apply bg-transparent;
  }
  
  .section::-webkit-scrollbar-thumb {
    @apply bg-(--color-secondary) rounded-full;
  }
</style>