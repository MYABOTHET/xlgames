<script>
  import {getContext, tick} from "svelte";
  import PrimarySection from "$lib/components/Sections/PrimarySection.svelte";
  import PrimaryCard from "$lib/components/Cards/PrimaryCard.svelte";
  import SecondaryCard from "$lib/components/Cards/SecondaryCard.svelte";
  import PrimaryTitle from "$lib/components/Titles/PrimaryTitle.svelte";
  import TernaryBlock from "$lib/components/Blocks/TernaryBlock.svelte";
  import PrimaryBlock from "$lib/components/Blocks/PrimaryBlock.svelte";
  import SecondarySection from "$lib/components/Sections/SecondarySection.svelte";
  
  const {data} = $props();
  const {project} = data;
  
  const language = $derived(getContext('language')());
  let news = $state(data.news);
  let locale = $state(language["Locale"]);
  
  $effect(async () => {
    if (language["Locale"] !== locale) {
      locale = language["Locale"];
      const url = new URL(`${location.origin}/news`);
      url.searchParams.set('require', String(false));
      url.searchParams.set('max', String(3));
      url.searchParams.set('locale', locale);
      news = await (await fetch(url)).json();
    }
  });
  
  let formatter = $derived(new Intl.DateTimeFormat(language["Locale"], {
    hour: "numeric",
    minute: "numeric",
    weekday: "long",
    year: "numeric",
    month: "long",
    day: "numeric",
  }));
</script>

<svelte:head>
  <title>{language["Home"]["Title"]} - {project.name}</title>
</svelte:head>

<section class="flex flex-col gap-y-28">
  <PrimarySection title={language["GameServers"]["Name"]} href="/game-servers">
    <div class="primary-section">
      <PrimaryCard fetchpriority="high" class="primary-card-size" href="/" src="minecraft.png" alt="Minecraft" name="Minecraft"
                   title='{language["Shared"]["PriceFrom"]} {language["Shared"]["CurrencySign"]}12'/>
      <PrimaryCard fetchpriority="high" class="primary-card-size" href="/" src="rust.png" alt="RUST" name="RUST"
                   title='{language["Shared"]["PriceFrom"]} {language["Shared"]["CurrencySign"]}8'/>
      <PrimaryCard fetchpriority="high" class="primary-card-size" href="/" src="Battlefield 2042.png" alt="Battlefield 2042"
                   name="Battlefield 2042"
                   title='{language["Shared"]["PriceFrom"]} {language["Shared"]["CurrencySign"]}34'/>
      <PrimaryCard fetchpriority="high" class="primary-card-size" href="/" src="7 Days to Die.png" alt="7 Days to Die" name="7 Days to Die"
                   title='{language["Shared"]["PriceFrom"]} {language["Shared"]["CurrencySign"]}15'/>
    </div>
  </PrimarySection>
  
  <section class="flex flex-wrap primary-gap">
    <SecondaryCard href="/servers" name={language["Home"]["ServersWithoutGPU"]["Name"]}
                   description={language["Home"]["ServersWithoutGPU"]["Description"]}/>
    <SecondaryCard href="/vps" name={language["Home"]["VPS"]["Name"]}
                   description={language["Home"]["VPS"]["Description"]}/>
    <SecondaryCard href="/web-hosting" name={language["Home"]["WebHosting"]["Name"]}
                   description={language["Home"]["WebHosting"]["Description"]}/>
    <SecondaryCard href="/vpn" name={language["Home"]["VPN"]["Name"]}
                   description={language["Home"]["VPN"]["Description"]}/>
    <SecondaryCard href="/servers-gpu" name={language["Home"]["ServersWithGPU"]["Name"]}
                   description={language["Home"]["ServersWithGPU"]["Description"]}/>
  </section>
  
  <section class="flex primary-gap-x flex-col xlgames-secondary:flex-row xlgames-secondary:gap-y-0 primary-gap-y">
    <article class="w-full xlgames-secondary:w-1/2 flex flex-col gap-y-7">
      <PrimaryTitle>{language["DataCenters"]["Name"]}</PrimaryTitle>
      <p>{language["Home"]["DataCentersDescription"]}</p>
      <TernaryBlock class="text-xlgames-primary hover:text-white w-fit">
        <a href="/data-centers" class="px-6 py-2 block">{language["Shared"]["ReadMore"]}</a>
      </TernaryBlock>
    </article>
    <PrimaryBlock preset="secondary" class="w-full xlgames-secondary:w-1/2 px-7 py-[1.25rem] gap-y-5 flex flex-col">
      {#each language["Home"]["DataCenters"] as dataCenter, index}
        <SecondarySection name={dataCenter["Name"]} description={dataCenter["Description"]}/>
        {#if language["Home"]["DataCenters"].length - 1 !== index}
          <div class="primary-line"></div>
        {/if}
      {/each}
    </PrimaryBlock>
  </section>
  
  <PrimarySection title={language["News"]["Name"]} href="/news">
    <div class="primary-section">
      {#each news as newsItem}
        <PrimaryCard class="secondary-card-size" href="/news/{newsItem['ParentId']}"
                     src={newsItem["Src"]} alt={newsItem['Name']}
                     name={newsItem["Name"]} title={formatter.format(new Date(newsItem["Date"]))}/>
      {/each}
    </div>
  </PrimarySection>
</section>
