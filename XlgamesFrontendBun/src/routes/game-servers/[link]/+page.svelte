<script>
  import {getContext} from "svelte";
  import SecondaryLink from "$lib/components/links/SecondaryLink.svelte";
  import PrimaryList from "$lib/components/lists/PrimaryList.svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
  let languageDto = $derived(getContext("languageDto")());
  let gameServerData = $state.raw(data.gameServerData);
  
  $effect(async () => {
    if (language.Locale !== languageDto.Locale) {
      gameServerData = await (await fetch(`/game-servers/${data.gameServer.GameServerDataPrimaryModels.find(gameServerData => gameServerData.LanguageId === languageDto.Id).Id}`)).json();
    }
  });
</script>

<svelte:head>
  <title>{language.GameServer.Title} - {data.gameServer.Name} - {data.projectData.Name}</title>
  {@html language.GameServer.Head}
  {@html gameServerData.Head}
</svelte:head>

{#snippet descLine(title, description)}
<article class="flex">
  <article class="flex min-w-48 max-decimal:min-w-fit max-decimal:flex-1">
    <h1 class="text-nowrap h-fit">{title}</h1>
    <div class="min-w-4 flex-1 secondary-line"></div>
  </article>
  <h1 class="text-wrap break-all">{description}</h1>
</article>
{/snippet}

<article class="secondary-section">
  <SecondaryLink href="/game-servers" name='{language.GameServer.Name} «{data.gameServer.Name}»'/>
  <article class="flex gap-x-10 ternary-gap-y max-decimal:flex-col">
    <img src={data.gameServer.Src} alt={data.gameServer.Name} class="decimal:secondary-size ternary-size rounded-2xl
max-decimal:aspect-square"/>
    <div class="flex flex-col gap-y-6">
      <section class="h-full flex flex-col gap-y-0.5 justify-between max-decimal:gap-y-0.5">
        {@render descLine?.(language.Shared.CPU, data.gameServer.CPU)}
        {@render descLine?.(language.Shared.RAMType, data.gameServer.RAM)}
        {@render descLine?.(language.Shared.DiskType, data.gameServer.Disk)}
        {@render descLine?.(language.Shared.Slots, data.gameServer.Slots === "-" ? language.GameServer.Unlimited : data.gameServer.Slots)}
        {@render descLine?.(language.Shared.Control, "Control panel, FTP")}
        {@render descLine?.(language.Shared.Region, "Europe")}
      </section>
      <article class="flex items-center max-decimal:gap-x-4 gap-x-8 max-decimal:justify-between">
        <h1>{language.Shared.PriceFrom} {language.Shared.CurrencySignPosition
            ? language.Shared.CurrencySign + gameServerData.Price
            : gameServerData.Price + language.Shared.CurrencySign} / {language.Shared.Month}</h1>
        <a href={data.gameServer.Link} class="quinary-block w-fit quaternary-p">{language.Shared.Order}</a>
      </article>
    </div>
  </article>
  <p>{gameServerData.Description}</p>
  {#if gameServerData.GameServerDataPoints.length}
    <PrimaryList items={gameServerData.GameServerDataPoints}/>
  {/if}
</article>