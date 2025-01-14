<script>
  import {getContext} from "svelte";
  import {createDateFormatter} from "$lib/tools.js";
  import PrimarySection from "$lib/components/sections/PrimarySection.svelte";
  import PrimaryCard from "$lib/components/cards/PrimaryCard.svelte";
  import SecondaryCard from "$lib/components/cards/SecondaryCard.svelte";
  import SecondarySection from "$lib/components/sections/SecondarySection.svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
  let languageDto = $derived(getContext("languageDto")());
  let news = $state(data.news);
  let dateFormatter = $derived(createDateFormatter(languageDto.Locale));
  
  $effect(async () => {
    if (language.Locale !== languageDto.Locale) {
      news = await (await fetch(`/news?max=3`)).json();
    }
  });
</script>

<svelte:head>
  <title>{language.Home.Title} - {data.projectData.Name}</title>
  {@html language.Home.Head}
</svelte:head>

{#snippet noCard(cardProps)}
<div class="{cardProps} primary-block border-transparent">
  <div class="primary-block border-quaternary text-quaternary size-full flex-center font-medium text-lg">
    ≽^•⩊•^≼
  </div>
</div>
{/snippet}

<div class="flex flex-col gap-y-28">
  {#if data.gameServers.length}
    <PrimarySection title={language.GameServers.Name} href="/game-servers">
      <nav class="primary-section">
        {#each data.gameServers as gameServer}
          {@const translate = gameServer.GameServerDataModels.find(item => item.LanguageId === language.Id)}
          {@const sign = language.Shared.CurrencySign}
          {@const position = language.Shared.CurrencySignPosition}
          {@const price = translate.Price}
          <PrimaryCard name={gameServer.Name} description="{language.Shared.PriceFrom}
{position ? sign + price : price + sign}"
                       src={gameServer.Src} class="secondary-size" href="/game-servers/{gameServer.LinkName}"/>
        {/each}
        {#if data.max - data.gameServers.length >= 0}
          {#each {length: data.max - data.gameServers.length}}
            {@render noCard?.("secondary-size")}
          {/each}
        {/if}
      </nav>
    </PrimarySection>
  {/if}
  
  <section class="flex flex-wrap primary-gap">
    <SecondaryCard name={language.Home.ServersWithoutGPU.Name} href="/servers"
                   description={language.Home.ServersWithoutGPU.Description}
                   class="quaternary-size"/>
    <SecondaryCard name={language.Home.VPS.Name} href="/vps"
                   description={language.Home.VPS.Description}
                   class="quaternary-size"/>
    <SecondaryCard name={language.Home.WebHosting.Name} href="/web-hosting"
                   description={language.Home.WebHosting.Description}
                   class="quaternary-size"/>
    <SecondaryCard name={language.Home.VPN.Name} href="/vpn"
                   description={language.Home.VPN.Description}
                   class="quaternary-size"/>
    <SecondaryCard name={language.Home.ServersWithGPU.Name} href="/servers-gpu"
                   description={language.Home.ServersWithGPU.Description}
                   class="quaternary-size"/>
  </section>
  
  <section
      class="{language.Home.DataCenters.length ? 'grid grid-cols-2 primary-gap-x max-ternary:grid-cols-1 max-ternary:gap-y-10' : ''}">
    <article class="flex flex-col primary-gap-y">
      <h1 class="primary-title">{language.DataCenters.Name}</h1>
      <p>{language.Home.DataCentersDescription}</p>
      <a class="quinary-block w-fit px-6 py-2.5"
         href="/data-centers">{language.Shared.ReadMore}</a>
    </article>
    {#if language.Home.DataCenters.length}
      <SecondarySection items={language.Home.DataCenters} class="h-fit primary-block border-quaternary secondary-p"/>
    {/if}
  </section>
  
  {#if news.length}
    <PrimarySection title={language.News.Name} href="/news">
      <nav class="primary-section">
        {#each news as newsItem}
          <PrimaryCard name={newsItem.Name} description={dateFormatter.format(new Date(newsItem.Date))}
                       src={newsItem.Src} href="/news/{newsItem.LinkName}"
                       class="quinary-size"/>
        {/each}
        {#if data.maxNews - data.news.length >= 0}
          {#each {length: data.maxNews - data.news.length}}
            {@render noCard?.("quinary-size")}
          {/each}
        {/if}
      </nav>
    </PrimarySection>
  {/if}
</div>