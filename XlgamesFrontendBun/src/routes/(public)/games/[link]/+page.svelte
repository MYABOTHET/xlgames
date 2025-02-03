<script>
  import {getContext} from "svelte";
  import SecondaryLink from "$lib/components/links/SecondaryLink.svelte";
  import PrimaryList from "$lib/components/lists/PrimaryList.svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
  let languageDto = $derived(getContext("languageDto")());
  let gameServerData = $state.raw(data.gameServerData);
  let priceFormatter = $derived(new Intl.NumberFormat(language.Locale));
  
  function getControl(gameServer) {
    let controls = [];
    gameServer.ControlPanel ? controls.push(language.Shared.ControlPanel) : null;
    gameServer.FTP ? controls.push(language.Shared.FTP) : null;
    if (!controls.length) controls.push("...");
    return controls.join(", ");
    
  }
  
  function getCountry(gameServerData) {
    let countries = [];
    gameServerData.Germany ? countries.push(language.Shared.Germany) : null;
    gameServerData.Finland ? countries.push(language.Shared.Finland) : null;
    gameServerData.Russia ? countries.push(language.Shared.Russia) : null;
    gameServerData.USA ? countries.push(language.Shared.USA) : null;
    gameServerData.Singapore ? countries.push(language.Shared.Singapore) : null;
    gameServerData.France ? countries.push(language.Shared.France) : null;
    gameServerData.Europe ? countries.push(language.Shared.Europe) : null;
    if (!countries.length) countries.push("...");
    return countries.join(", ");
  }
  
  $effect(async () => {
    if (language.Locale !== languageDto.Locale) {
      gameServerData = await (await fetch(`/games/${data.gameServer.GameServerDataPrimaryModels.find(gameServerData => gameServerData.LanguageId === languageDto.Id).Id}`)).json();
    }
  });
</script>

<svelte:head>
  <title>{language.GameServer.TitlePosition
      ? data.gameServer.Name  + " " + language.GameServer.Title
      : language.GameServer.Title + " " + data.gameServer.Name } - {data.projectData.Name}</title>
  {@html language.GameServer.Head}
  {@html gameServerData.Head}
</svelte:head>

{#snippet descLine(title, description)}
  <article class="flex">
    <article class="flex min-w-48 max-decimal:min-w-fit max-decimal:flex-1">
      <h1 class="text-nowrap h-fit">{title}</h1>
      <div class="min-w-4 flex-1 secondary-line"></div>
    </article>
    <h1>{description}</h1>
  </article>
{/snippet}

<article class="secondary-section">
  <SecondaryLink href="/games" name='{language.GameServer.TitlePosition
      ? "«" + data.gameServer.Name + "» " + language.GameServer.Name
      : language.GameServer.Name + " «" + data.gameServer.Name  + "»"}'/>
  <SecondaryLink href="/games" name="{language.GameServer.Name} «{data.gameServer.Name}»"/>
  <article class="flex gap-x-10 ternary-gap-y max-decimal:flex-col">
    <img alt={data.gameServer.Name} class="decimal:secondary-size ternary-size rounded-2xl
max-decimal:aspect-square" src={data.gameServer.Src}/>
    <div class="flex flex-col gap-y-6">
      <section class="h-full flex flex-col gap-y-1 justify-between">
        {@render descLine?.(language.Shared.CPU, data.gameServer.CPU)}
        {@render descLine?.(language.Shared.RAMType, data.gameServer.RAM)}
        {@render descLine?.(language.Shared.DiskType, data.gameServer.Disk)}
        {@render descLine?.(language.Shared.Slots, data.gameServer.Slots === "-" ? language.GameServer.Unlimited : data.gameServer.Slots)}
        {@render descLine?.(language.Shared.Control, getControl(data.gameServer))}
        {@render descLine?.(language.Shared.Country, getCountry(gameServerData))}
      </section>
      <article class="flex items-center max-decimal:gap-x-4 gap-x-8 max-decimal:justify-between">
        <h1>{language.Shared.PriceFrom} {language.Shared.CurrencySignPosition
            ? language.Shared.CurrencySign + priceFormatter.format(gameServerData.Price)
            : priceFormatter.format(gameServerData.Price) + language.Shared.CurrencySign} / {language.Shared.Month}</h1>
        <a class="quinary-block w-fit quaternary-p" href={data.gameServer.Link}
           rel="nofollow">{language.Shared.Order}</a>
      </article>
    </div>
  </article>
  <p>{gameServerData.Description}</p>
  {#if gameServerData.GameServerDataPoints.length}
    <PrimaryList items={gameServerData.GameServerDataPoints}/>
  {/if}
</article>