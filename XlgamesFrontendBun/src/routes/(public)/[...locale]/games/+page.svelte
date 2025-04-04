<script>
  import {getContext} from "svelte";
  import PrimaryLoupe from "$lib/components/svg/PrimaryLoupe.svelte";
  import PrimaryCard from "$lib/components/cards/PrimaryCard.svelte";
  import {transformLocale} from "$lib/tools.js";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
  let languageDto = $derived(getContext("languageDto")());
  
  let allActive = $state(true);
  let popularActive = $state(false);
  let searchQuery = $state("");
  let gameServers = $state.raw(data.gameServers);
  let priceFormatter = $derived(new Intl.NumberFormat(language.Locale));
  
  function compare( a, b ) {
    if ( a.Name < b.Name ) return -1;
    if ( a.Name > b.Name ) return 1;
    return 0;
  }
  
  function seeAll() {
    if (!allActive) {
      searchQuery = "";
      allActive = true;
      popularActive = false;
      search();
    }
  }
  
  function seePopular() {
    if (!popularActive) {
      searchQuery = "";
      allActive = false;
      popularActive = true;
      search();
    }
  }
  
  function search() {
    gameServers = data.gameServers.filter(item => {
      let queryTrim = searchQuery.trim().toLowerCase();
      if (queryTrim !== "") {
        const name = item.Name.replace(/ +/g, "").toLowerCase();
        const result = name.includes(queryTrim.replace(/ +/g, ""));
        if (!result) return false;
      }
      if (popularActive) {
        if (!item.isPopular) return false;
      }
      return true;
    });
  }
</script>

<svelte:head>
  <title>{language.GameServers.Title} - {data.projectData.Name}</title>
  {@html language.GameServers.Head}
</svelte:head>

{#snippet buttonFilter(click, isActive, content)}
  <button
      class="{isActive ? 'border-(--color-ternary) text-(--color-ternary)' : 'border-(--color-quaternary) text-(--color-quaternary)'}
    border-2 px-6 py-2.5 rounded-full text-nowrap transition-colors hover:bg-(--color-secondary)
max-nine:flex-[1_1_25%]"
      onclick={click}>{content}</button>
{/snippet}

<article class="secondary-section">
  <h1 class="primary-title">{language.GameServers.Name}</h1>
  <div class="flex flex-wrap gap-4">
    {@render buttonFilter?.(seeAll, allActive, language.GameServers.All)}
    {@render buttonFilter?.(seePopular, popularActive, language.GameServers.Popular)}
    <div class="pl-6 flex-center primary-block-default text-white rounded-full primary-bg
    max-w-72 max-nine:max-w-full max-nine:flex-[1_1_100%] w-full {searchQuery
    ? 'border-(--color-ternary) fill-(--color-ternary)'
    : 'border-(--color-quaternary) fill-(--color-quaternary)'}">
      <PrimaryLoupe class="min-w-3.5 min-h-3.5 max-w-3.5 max-h-3.5"/>
      <input autocomplete="off" bind:value={
          () => searchQuery,
          (value) => {allActive = true; popularActive = false; searchQuery = value; search();}
          }
             class="min-w-0 w-full pl-3 pr-6 py-2.5 bg-transparent placeholder-(--color-quaternary) outline-hidden"
             id="search" name="search" placeholder={language.GameServers.Search}
             spellcheck="false">
    </div>
  </div>
  {#if gameServers.length}
    <nav class="grid grid-cols-4 primary-gap max-octal:grid-cols-3 max-ternary:grid-cols-2 max-nine:grid-cols-none
    max-nine:auto-cols-fr">
      {#each gameServers.slice().sort(compare) as gameServer (gameServer.Id)}
        {@const translate = gameServer.GameServerDataModels.find(item => item.LanguageId === language.Id)}
        {@const sign = language.Shared.CurrencySign}
        {@const position = language.Shared.CurrencySignPosition}
        {@const price = priceFormatter.format(translate.Price)}
        <PrimaryCard name={gameServer.Name} description="{language.Shared.PriceFrom}
{position ? sign + price : price + sign}"
                     src={gameServer.Src} class="w-full h-full aspect-square" href={transformLocale(languageDto.Lang, `/games/${gameServer.LinkName}`)}/>
      {/each}
    </nav>
  {/if}
</article>