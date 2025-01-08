<script>
  import {getContext} from "svelte";
  import {createDateFormatter} from "$lib/tools.js";
  import PrimarySection from "$lib/components/sections/PrimarySection.svelte";
  import PrimaryCard from "$lib/components/cards/PrimaryCard.svelte";
  import SecondaryCard from "$lib/components/cards/SecondaryCard.svelte";
  import SecondarySection from "$lib/components/sections/SecondarySection.svelte";
  
  const {data} = $props();
  const {projectData} = data;
  const {name} = projectData;
  
  let language = $derived(getContext("language")());
  let locale = $derived(getContext("locale")());
  let news = $state(data.news);
  let dateFormatter = $derived(createDateFormatter(locale));
  
  $effect(async () => {
    if (language.Locale !== locale) {
      news = await (await fetch(`/news?require=false&max=3&locale=${locale}`)).json();
    }
  });
</script>

<svelte:head>
  <title>{language.Home.Title} - {name}</title>
</svelte:head>

<div class="flex flex-col gap-y-28">
  {#if true}
    <PrimarySection title={language.GameServers.Name} href="/game-servers">
      <nav class="primary-section">
        <PrimaryCard name="Minecraft" description="{language.Shared.PriceFrom} {language.Shared.CurrencySign}24"
                     src="minecraft.png" class="secondary-size" href="/"/>
        <PrimaryCard name="RUST" description="{language.Shared.PriceFrom} {language.Shared.CurrencySign}32"
                     src="rust.png" class="secondary-size" href="/"/>
        <PrimaryCard name="Battlefield 2042" description="{language.Shared.PriceFrom} {language.Shared.CurrencySign}12"
                     src="Battlefield 2042.png" class="secondary-size" href="/"/>
        <PrimaryCard name="7 Days to Die" description="{language.Shared.PriceFrom} {language.Shared.CurrencySign}16"
                     src="7 Days to Die.png" class="secondary-size" href="/"/>
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
  
  <section class="{language.Home.DataCenters.length ? 'grid grid-cols-2 primary-gap-x max-ternary:grid-cols-1 max-ternary:gap-y-10' : ''}">
    <article class="flex flex-col primary-gap-y max-ternary:w-full">
      <h1 class="primary-title">{language.DataCenters.Name}</h1>
      <p>{language.Home.DataCentersDescription}</p>
      <a class="quinary-block w-fit px-6 py-2.5"
         href="/data-centers">{language.Shared.ReadMore}</a>
    </article>
    {#if language.Home.DataCenters.length}
      <SecondarySection items={language.Home.DataCenters} class="h-fit primary-block border-quaternary secondary-p
max-ternary:w-full"/>
    {/if}
  </section>
  
  {#if news.length}
    <PrimarySection title={language.News.Name} href="/news">
      <nav class="primary-section">
        {#each news as newsItem}
          <PrimaryCard name={newsItem.Name} description={dateFormatter.format(new Date(newsItem.Date))}
                       src={newsItem.Src} href="/news/{newsItem.ParentId}"
                       class="quinary-size"/>
        {/each}
      </nav>
    </PrimarySection>
  {/if}
</div>

