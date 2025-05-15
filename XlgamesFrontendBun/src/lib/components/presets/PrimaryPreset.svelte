<script>
  import {getContext, untrack} from "svelte";
  import Singapore from "$lib/components/svg/flags/Singapore.svelte";
  import Germany from "$lib/components/svg/flags/Germany.svelte";
  import Finland from "$lib/components/svg/flags/Finland.svelte";
  import Russia from "$lib/components/svg/flags/Russia.svelte";
  import USA from "$lib/components/svg/flags/USA.svelte";
  import SecondaryDropdownMenu from "$lib/components/dropdown-menus/SecondaryDropdownMenu.svelte";
  import France from "$lib/components/svg/flags/France.svelte";
  import Canada from "$lib/components/svg/flags/Canada.svelte";
  import Poland from "$lib/components/svg/flags/Poland.svelte";
  import Uk from "$lib/components/svg/flags/Uk.svelte";
  import PrimaryLoupe from "$lib/components/svg/PrimaryLoupe.svelte";
  import ProductHaveInfo from "$lib/components/svg/ProductHaveInfo.svelte";
  import PrimaryCheckbox from "$lib/components/checkbox/PrimaryCheckbox.svelte";

  const {serversProp, userOnMobile, preset, stock = true, ...props} = $props();
  
  let language = $derived(getContext("language")());
  let oldLanguage = $state.raw({
    Id: getContext("language")().Id,
    Shared: getContext("language")().Shared,
  });
  
  let result = $state.raw(serversProp);
  let resultSorted = $derived(result.sort(compareNumeric));
  let priceFormatter = $derived(new Intl.NumberFormat(language.Locale));
  // Костыль
  let init = $state.raw({init: false});
  
  let countryKey = $state(null);
  let regionKey = $state(null);
  
  let CPUs = $state.raw(initCPUs(serversProp));
  let currentCPU = $state(null);
  
  let GPUs = $state.raw(preset === "primary" ? initGPUs(serversProp) : new Set());
  let currentGPU = $state(null);
  
  let countries = $state.raw(initCountries(serversProp));
  let currentCountry = $state(null);
  
  let regions = $state.raw(initRegions(serversProp));
  let currentRegion = $state(null);

  let searchQuery = $state("");

  let availableStock = $state();
  
  function selectCPU(CPU) {
    searchQuery = "";
    currentCPU = CPU;
    filter();
  }
  
  function selectGPU(GPU) {
    searchQuery = "";
    currentGPU = GPU;
    filter();
  }
  
  function selectCountry(country) {
    searchQuery = "";
    countryKey = country ? getKeyByValue(language.Shared, country) : null;
    currentCountry = country;
    filter();
  }

  function selectRegion(region) {
    searchQuery = "";
    regionKey = region ? getKeyByValue(language.Shared, region) : null;
    currentRegion = region;
    filter();
  }

  $effect(() => {
    if (stock) {
      if (!searchQuery) {
        filter();
        if (availableStock) {
          untrack(() => {
            if (!CPUs.has(currentCPU)) {
              currentCPU = "";
            }
            if (!countries.has(currentCountry)) {
              currentCountry = "";
            }
            if (!regions.has(currentRegion)) {
              currentRegion = "";
            }
            if (preset === "primary") {
              if (!GPUs.has(currentGPU)) {
                currentGPU = "";
              }
            }
          })
        }
      } else {
        search();
      }
    }
  });

  function filter() {
    const servers = serversProp.filter(server =>
        (stock ? (availableStock ? (!server.Russian || server.qty) : true) : true) &&
        (currentCPU ? server.Data.CPU === currentCPU : true) &&
        (currentCountry ? server.Data[countryKey] : true) &&
        (currentRegion ? server.Data[regionKey] : true) &&
        (preset === "primary" ? (currentGPU ? server.Data.GPU === currentGPU : true) : true)
    );
    
    CPUs = new Set(serversProp.filter(server =>
      (stock ? (availableStock ? (!server.Russian || server.qty) : true) : true) &&
        (currentCountry ? server.Data[countryKey] : true) &&
        (currentRegion ? server.Data[regionKey] : true) &&
        (preset === "primary" ? (currentGPU ? server.Data.GPU === currentGPU : true) : true)
    ).map(server => server.Data.CPU));
    
    const serversCountries = serversProp.filter(server =>
      (stock ? (availableStock ? (!server.Russian || server.qty) : true) : true) &&
        (currentCPU ? server.Data.CPU === currentCPU : true) &&
        (currentRegion ? server.Data[regionKey] : true) &&
        (preset === "primary" ? (currentGPU ? server.Data.GPU === currentGPU : true) : true));
    
    if (currentRegion) {
      countries = findCountry(currentRegion);
    } else {
      countries = initCountries(serversCountries);
    }
    
    const serversRegions = serversProp.filter(server =>
      (stock ? (availableStock ? (!server.Russian || server.qty) : true) : true) &&
        (currentCPU ? server.Data.CPU === currentCPU : true) &&
        (currentCountry ? server.Data[countryKey] : true) &&
        (preset === "primary" ? (currentGPU ? server.Data.GPU === currentGPU : true) : true));
    
    if (currentCountry) {
      regions = findRegions(serversRegions, currentCountry);
    } else {
      regions = initRegions(serversRegions);
    }
    
    if (preset === "primary") {
      GPUs = new Set(serversProp.filter(server =>
        (stock ? (availableStock ? (!server.Russian || server.qty) : true) : true) &&
          (currentCPU ? server.Data.CPU === currentCPU : true) &&
          (currentCountry ? server.Data[countryKey] : true) &&
          (currentRegion ? server.Data[regionKey] : true)
      ).map(server => server.Data.GPU));
    }

    result = servers;
  }
  
  $effect(() => {
    language;
    reinit();
  });
  
  function clearFilters(event, clearInput) {
    if (currentCPU || currentCountry || currentRegion || currentGPU || searchQuery
      || availableStock === true
    ) {
      if (clearInput === undefined) clearInput = true;
      result = serversProp;
      CPUs = initCPUs(serversProp);
      currentCPU = null;
      countries = initCountries(serversProp);
      currentCountry = null;
      regions = initRegions(serversProp);
      currentRegion = null;
      countryKey = null;
      regionKey = null;
      if (preset === "primary") {
        GPUs = initGPUs(serversProp);
        currentGPU = null;
      }
      if (clearInput) {
        searchQuery = "";
        availableStock = false;
      }
    }
  }
  
  function reinit() {
    if (init.init) {
      
      if (oldLanguage.Id === language.Id) return;
      
      if (currentCountry) {
        currentCountry = language.Shared[countryKey];
      }
      if (currentRegion) {
        currentRegion = language.Shared[regionKey];
      }
      
      let translateCountries = new Set();
      countries.forEach(country => {
        if (country === oldLanguage.Shared.Germany) translateCountries.add(language.Shared.Germany);
        if (country === oldLanguage.Shared.Finland) translateCountries.add(language.Shared.Finland);
        if (country === oldLanguage.Shared.Russia) translateCountries.add(language.Shared.Russia);
        if (country === oldLanguage.Shared.USA) translateCountries.add(language.Shared.USA);
        if (country === oldLanguage.Shared.Singapore) translateCountries.add(language.Shared.Singapore);
        if (country === oldLanguage.Shared.France) translateCountries.add(language.Shared.France);
        if (country === oldLanguage.Shared.UnitedKingdom) translateCountries.add(language.Shared.UnitedKingdom);
        if (country === oldLanguage.Shared.Poland) translateCountries.add(language.Shared.Poland);
        if (country === oldLanguage.Shared.Canada) translateCountries.add(language.Shared.Canada);
      });
      countries = translateCountries;
      
      let translateRegions = new Set();
      regions.forEach(region => {
        if (region === oldLanguage.Shared.Falkenstein) translateRegions.add(language.Shared.Falkenstein);
        if (region === oldLanguage.Shared.Frankfurt) translateRegions.add(language.Shared.Frankfurt);
        if (region === oldLanguage.Shared.Nuremberg) translateRegions.add(language.Shared.Nuremberg);
        if (region === oldLanguage.Shared.Helsinki) translateRegions.add(language.Shared.Helsinki);
        if (region === oldLanguage.Shared.Moscow) translateRegions.add(language.Shared.Moscow);
        if (region === oldLanguage.Shared.SaintPetersburg) translateRegions.add(language.Shared.SaintPetersburg);
        if (region === oldLanguage.Shared.Orenburg) translateRegions.add(language.Shared.Orenburg);
        if (region === oldLanguage.Shared.Ekaterenburg) translateRegions.add(language.Shared.Ekaterenburg);
        if (region === oldLanguage.Shared.Vladivastok) translateRegions.add(language.Shared.Vladivastok);
        if (region === oldLanguage.Shared.NewYork) translateRegions.add(language.Shared.NewYork);
        if (region === oldLanguage.Shared.Miami) translateRegions.add(language.Shared.Miami);
        if (region === oldLanguage.Shared.LosAngeles) translateRegions.add(language.Shared.LosAngeles);
        if (region === oldLanguage.Shared.Hillsboro) translateRegions.add(language.Shared.Hillsboro);
        if (region === oldLanguage.Shared.Ashburn) translateRegions.add(language.Shared.Ashburn);
        if (region === oldLanguage.Shared.Singapore) translateRegions.add(language.Shared.Singapore);
        if (region === oldLanguage.Shared.Gravelines) translateRegions.add(language.Shared.Gravelines);
        if (region === oldLanguage.Shared.Limburg) translateRegions.add(language.Shared.Limburg);
        if (region === oldLanguage.Shared.Erith) translateRegions.add(language.Shared.Erith);
        if (region === oldLanguage.Shared.Strasbourg) translateRegions.add(language.Shared.Strasbourg);
        if (region === oldLanguage.Shared.Warsaw) translateRegions.add(language.Shared.Warsaw);
        if (region === oldLanguage.Shared.Beauharnois) translateRegions.add(language.Shared.Beauharnois);
      });
      regions = translateRegions;
      
      oldLanguage = {
        Id: language.Id,
        Shared: language.Shared,
      };
    } else {
      init.init = true;
    }
  }
  
  function initCPUs(servers) {
    return new Set(servers.map(server => server.Data.CPU));
  }
  
  function initGPUs(servers) {
    return new Set(servers.map(server => server.Data.GPU));
  }
  
  function initCountries(servers) {
    let countries = new Set();
    servers.forEach(server => {
      if (server.Data.Germany) countries.add(language.Shared.Germany);
      if (server.Data.Finland) countries.add(language.Shared.Finland);
      if (server.Data.Russia) countries.add(language.Shared.Russia);
      if (server.Data.USA) countries.add(language.Shared.USA);
      if (server.Data.Singapore) countries.add(language.Shared.Singapore);
      if (server.Data.France) countries.add(language.Shared.France);
      if (server.Data.UnitedKingdom) countries.add(language.Shared.UnitedKingdom);
      if (server.Data.Poland) countries.add(language.Shared.Poland);
      if (server.Data.Canada) countries.add(language.Shared.Canada);
    });
    return countries;
  }
  
  function findCountry(region) {
    let country = new Set();
    if (language.Shared.Falkenstein === region ||
        language.Shared.Frankfurt === region ||
        language.Shared.Nuremberg === region ||
      language.Shared.Limburg === region) {
      country.add(language.Shared.Germany);
      return country;
    }
    if (language.Shared.Helsinki === region) {
      country.add(language.Shared.Finland);
      return country;
    }
    if (language.Shared.Moscow === region ||
        language.Shared.SaintPetersburg === region ||
      language.Shared.Orenburg === region ||
      language.Shared.Ekaterenburg === region ||
      language.Shared.Vladivastok === region) {
      country.add(language.Shared.Russia);
      return country;
    }
    if (language.Shared.NewYork === region ||
        language.Shared.Miami === region ||
        language.Shared.LosAngeles === region ||
        language.Shared.Hillsboro === region ||
        language.Shared.Ashburn === region) {
      country.add(language.Shared.USA);
      return country;
    }
    if (language.Shared.Gravelines === region ||
      language.Shared.Strasbourg === region) {
      country.add(language.Shared.France);
      return country;
    }
    if (language.Shared.Erith === region) {
      country.add(language.Shared.UnitedKingdom);
      return country;
    }
    if (language.Shared.Warsaw === region) {
      country.add(language.Shared.Poland);
      return country;
    }
    if (language.Shared.Beauharnois === region) {
      country.add(language.Shared.Canada);
      return country;
    }
    if (language.Shared.Singapore === region) {
      country.add(language.Shared.Singapore);
    }
    return country;
  }
  
  function findRegions(servers, country) {
    let regions = new Set();
    servers.forEach(server => {
      if (server.Data.Germany && language.Shared.Germany === country) {
        if (server.Data.Falkenstein) regions.add(language.Shared.Falkenstein);
        if (server.Data.Frankfurt) regions.add(language.Shared.Frankfurt);
        if (server.Data.Nuremberg) regions.add(language.Shared.Nuremberg);
        if (server.Data.Limburg) regions.add(language.Shared.Limburg);
      }
      if (server.Data.Finland && language.Shared.Finland === country) {
        if (server.Data.Helsinki) regions.add(language.Shared.Helsinki);
      }
      if (server.Data.France && language.Shared.France === country) {
        if (server.Data.Gravelines) regions.add(language.Shared.Gravelines);
        if (server.Data.Strasbourg) regions.add(language.Shared.Strasbourg);
      }
      if (server.Data.Russia && language.Shared.Russia === country) {
        if (server.Data.Moscow) regions.add(language.Shared.Moscow);
        if (server.Data.SaintPetersburg) regions.add(language.Shared.SaintPetersburg);
        if (server.Data.Orenburg) regions.add(language.Shared.Orenburg);
        if (server.Data.Ekaterenburg) regions.add(language.Shared.Ekaterenburg);
        if (server.Data.Vladivastok) regions.add(language.Shared.Vladivastok);
      }
      if (server.Data.USA && language.Shared.USA === country) {
        if (server.Data.NewYork) regions.add(language.Shared.NewYork);
        if (server.Data.Miami) regions.add(language.Shared.Miami);
        if (server.Data.LosAngeles) regions.add(language.Shared.LosAngeles);
        if (server.Data.Hillsboro) regions.add(language.Shared.Hillsboro);
        if (server.Data.Ashburn) regions.add(language.Shared.Ashburn);
      }
      if (server.Data.UnitedKingdom && language.Shared.UnitedKingdom === country) regions.add(language.Shared.Erith);
      if (server.Data.Poland && language.Shared.Poland === country) regions.add(language.Shared.Warsaw);
      if (server.Data.Canada && language.Shared.Canada === country) regions.add(language.Shared.Beauharnois);
      if (server.Data.Singapore && language.Shared.Singapore === country) regions.add(language.Shared.Singapore);
    });
    return regions;
  }
  
  function initRegions(servers) {
    let regions = new Set();
    servers.forEach(server => {
      if (server.Data.Germany) {
        if (server.Data.Falkenstein) regions.add(language.Shared.Falkenstein);
        if (server.Data.Frankfurt) regions.add(language.Shared.Frankfurt);
        if (server.Data.Nuremberg) regions.add(language.Shared.Nuremberg);
        if (server.Data.Limburg) regions.add(language.Shared.Limburg);
      }
      if (server.Data.Finland) {
        if (server.Data.Helsinki) regions.add(language.Shared.Helsinki);
      }
      if (server.Data.UnitedKingdom) {
        if (server.Data.Erith) regions.add(language.Shared.Erith);
      }
      if (server.Data.Poland) {
        if (server.Data.Warsaw) regions.add(language.Shared.Warsaw);
      }
      if (server.Data.Canada) {
        if (server.Data.Beauharnois) regions.add(language.Shared.Beauharnois);
      }
      if (server.Data.France) {
        if (server.Data.Gravelines) regions.add(language.Shared.Gravelines);
        if (server.Data.Strasbourg) regions.add(language.Shared.Strasbourg);
      }
      if (server.Data.Russia) {
        if (server.Data.Moscow) regions.add(language.Shared.Moscow);
        if (server.Data.SaintPetersburg) regions.add(language.Shared.SaintPetersburg);
        if (server.Data.Orenburg) regions.add(language.Shared.Orenburg);
        if (server.Data.Ekaterenburg) regions.add(language.Shared.Ekaterenburg);
        if (server.Data.Vladivastok) regions.add(language.Shared.Vladivastok);
      }
      if (server.Data.USA) {
        if (server.Data.NewYork) regions.add(language.Shared.NewYork);
        if (server.Data.Miami) regions.add(language.Shared.Miami);
        if (server.Data.LosAngeles) regions.add(language.Shared.LosAngeles);
        if (server.Data.Hillsboro) regions.add(language.Shared.Hillsboro);
        if (server.Data.Ashburn) regions.add(language.Shared.Ashburn);
      }
      if (server.Data.Singapore) regions.add(language.Shared.Singapore);
    });
    return regions;
  }
  
  function getKeyByValue(object, value) {
    return Object.keys(object).find(key => object[key] === value);
  }
  
  function compareNumeric(a, b) {
    if (a.Pricings.find(pricing => pricing.CurrencyId === language.CurrencyId).Price > b.Pricings.find(pricing => pricing.CurrencyId === language.CurrencyId).Price) return 1;
    if (a.Pricings.find(pricing => pricing.CurrencyId === language.CurrencyId).Price === b.Pricings.find(pricing => pricing.CurrencyId === language.CurrencyId).Price) return 0;
    if (a.Pricings.find(pricing => pricing.CurrencyId === language.CurrencyId).Price < b.Pricings.find(pricing => pricing.CurrencyId === language.CurrencyId).Price) return -1;
  }
  
  function getCountries(server) {
    let countries = [];
    server.Data.Germany ? countries.push(language.Shared.Germany) : null;
    server.Data.Finland ? countries.push(language.Shared.Finland) : null;
    server.Data.Russia ? countries.push(language.Shared.Russia) : null;
    server.Data.USA ? countries.push(language.Shared.USA) : null;
    server.Data.Singapore ? countries.push(language.Shared.Singapore) : null;
    server.Data.France ? countries.push(language.Shared.France) : null;
    server.Data.UnitedKingdom ? countries.push(language.Shared.UnitedKingdom) : null;
    server.Data.Poland ? countries.push(language.Shared.Poland) : null;
    server.Data.Canada ? countries.push(language.Shared.Canada) : null;
    if (!countries.length) countries.push("...");
    return countries.join(", ");
  }
  
  function getRegions(server) {
    let regions = [];
    server.Data.Falkenstein ? regions.push(language.Shared.Falkenstein) : null;
    server.Data.Frankfurt ? regions.push(language.Shared.Frankfurt) : null;
    server.Data.Nuremberg ? regions.push(language.Shared.Nuremberg) : null;
    server.Data.Helsinki ? regions.push(language.Shared.Helsinki) : null;
    server.Data.Moscow ? regions.push(language.Shared.Moscow) : null;
    server.Data.SaintPetersburg ? regions.push(language.Shared.SaintPetersburg) : null;
    server.Data.Orenburg ? regions.push(language.Shared.Orenburg) : null;
    server.Data.Ekaterenburg ? regions.push(language.Shared.Ekaterenburg) : null;
    server.Data.Vladivastok ? regions.push(language.Shared.Vladivastok) : null;
    server.Data.NewYork ? regions.push(language.Shared.NewYork) : null;
    server.Data.Miami ? regions.push(language.Shared.Miami) : null;
    server.Data.LosAngeles ? regions.push(language.Shared.LosAngeles) : null;
    server.Data.Hillsboro ? regions.push(language.Shared.Hillsboro) : null;
    server.Data.Ashburn ? regions.push(language.Shared.Ashburn) : null;
    server.Data.Gravelines ? regions.push(language.Shared.Gravelines) : null;
    server.Data.Singapore ? regions.push(language.Shared.Singapore) : null;
    server.Data.Limburg ? regions.push(language.Shared.Limburg) : null;
    server.Data.Erith ? regions.push(language.Shared.Erith) : null;
    server.Data.Strasbourg ? regions.push(language.Shared.Strasbourg) : null;
    server.Data.Warsaw ? regions.push(language.Shared.Warsaw) : null;
    server.Data.Beauharnois ? regions.push(language.Shared.Beauharnois) : null;
    if (!regions.length) regions.push("...");
    for (let i = 0; i < regions.length; i++) regions[i] = regions[i].replaceAll(" ", "&nbsp;");
    return regions.join(", ");
  }
  
  function getPrice(server) {
    const sign = language.Shared.CurrencySign;
    const position = language.Shared.CurrencySignPosition;
    const price = priceFormatter.format(server.Pricings.find(pricing => pricing.CurrencyId === language.CurrencyId).Price);
    return position ? sign + price : price + sign;
  }

  function search() {
    clearFilters({}, false);
    result = serversProp.filter(server => (stock ? (availableStock ? (!server.Russian || server.qty) : true) : true) && [server.Data.CPU, server.Data.Disk, server.Data.DiskType, server.Data.GHz,
      server.Data.RAM, server.Data.RAMType, getCountries(server).replaceAll("&nbsp;", " ").replaceAll(",", ""), getRegions(server).replaceAll("&nbsp;", " ").replaceAll(",", ""),
      (server.Data.GPU ? server.Data.GPU : "")].join(" ").toLowerCase().includes(searchQuery.trim().toLowerCase()));
  }

  function splitAtFirstNumber(str) {
    const match = str.match(/\d/);
    if (match) {
      const index = match.index;
      return [
        str.substring(0, index).trim(),
        str.substring(index).trim()
      ];
    }
    return [str.trim(), ''];
  }
</script>

{#snippet Enum(title, description)}
  <article class="flex">
    <article class="flex min-w-44 max-hexadecimal:min-w-fit max-hexadecimal:flex-1">
      <h1 class="text-nowrap h-fit">{title}</h1>
      <div class="min-w-4 flex-1 secondary-line"></div>
    </article>
    <h1>{@html description}</h1>
  </article>
{/snippet}

{#snippet Card(server, setupTime)}
  <section class="flex flex-col gap-y-1 border-2 rounded-2xl overflow-hidden border-(--color-ternary) py-5 px-6">
    {@render Enum(language.Shared.CPU, server.Data.CPU)}
    {#if preset === "secondary"}
      {@render Enum(language.Shared.Cores, server.Data.Cores)}
    {/if}
    {#if preset !== "secondary"}
      {@render Enum(language.Shared.GHz, server.Data.GHz)}
      {#if preset === "primary"}
        {@render Enum(language.Shared.GPU, server.Data.GPU)}
      {/if}
    {/if}
    {@render Enum(`${language.Shared.RAM} (${language.Shared.GB})`, server.Data.RAM)}
    {#if preset !== "secondary"}
      {@render Enum(language.Shared.RAMType, server.Data.RAMType)}
    {/if}
    {@render Enum(language.Shared.Disk, `${server.Data.Disk} ${server.Data.GB ? language.Shared.GB : server.Data.TB ? language.Shared.TB : language.Shared.GB} ${server.Data.DiskType}`)}
    {@render Enum(language.Shared.Country, getCountries(server))}
    {@render Enum(language.Shared.Region, getRegions(server))}
    {@render Enum(language.Shared.PricePerMonth, getPrice(server))}
    {#if stock && setupTime}
      {@render Enum(setupTime[0].split(" ")[0], setupTime[1])}
    {/if}
    <a rel="nofollow" class="primary-link mx-auto mt-3" href="/store/store/{server.Link}" data-sveltekit-reload>{language.Shared.Order}</a>
  </section>
{/snippet}

{#snippet resetFiltersPreset()}
  <button class="border-2 px-6 py-2.5 rounded-full text-nowrap transition-colors hover:bg-(--color-secondary)
border-(--color-quaternary) text-(--color-quaternary)"
          onclick={clearFilters}>{language.Shared.ResetFilters}</button>
{/snippet}

<div {...props} class="{props.class} gap-4 grid grid-cols-2 max-sm:grid-cols-1">
  <SecondaryDropdownMenu class=""
                         currentItem={currentCPU} defaultItem={language.Shared.AnyCPU} items={CPUs}
                         select={selectCPU}>
  </SecondaryDropdownMenu>
  {#if preset === "primary"}
    <SecondaryDropdownMenu class=""
                           defaultItem={language.Shared.AnyGPU} select={selectGPU} currentItem={currentGPU}
                           items={GPUs}>
    </SecondaryDropdownMenu>
  {/if}
  <SecondaryDropdownMenu class=""
                         currentItem={currentCountry} defaultItem={language.Shared.AnyCountry} items={countries}
                         select={selectCountry}>
  </SecondaryDropdownMenu>
  <SecondaryDropdownMenu class=""
                         currentItem={currentRegion} defaultItem={language.Shared.AnyRegion} items={regions}
                         select={selectRegion}>
  </SecondaryDropdownMenu>
  {#if preset !== "primary"}
    {@render resetFiltersPreset()}
  {/if}
  <div class="flex col-span-2 max-sm:col-span-1 max-sm:flex max-sm:flex-col" style="gap: inherit">
    {#if preset === "primary"}
      {@render resetFiltersPreset()}
    {/if}
    <div class="pl-6 flex-center primary-block-default text-white rounded-full primary-bg w-full {preset === 'primary' ? '' : 'col-span-2 max-sm:col-span-1'}
{searchQuery
    ? 'border-(--color-ternary) fill-(--color-ternary)'
    : 'border-(--color-quaternary) fill-(--color-quaternary)'}">
      <PrimaryLoupe class="min-w-3.5 min-h-3.5 max-w-3.5 max-h-3.5"/>
      <input autocomplete="off" bind:value={
          () => searchQuery,
          (value) => {searchQuery = value; search();}
          }
             class="min-w-0 w-full pl-3 pr-6 py-2.5 bg-transparent placeholder-(--color-quaternary) outline-hidden"
             id="search" name="search" placeholder={language.GameServers.Search}
             spellcheck="false">
    </div>
    {#if stock}
      <div class="flex gap-2 items-center justify-center mr-1">
        <button aria-label={language.Shared.AvailableStock}
                onclick={() => {availableStock = !availableStock}}
                class="rounded-full border-2 transition-colors size-5.5 {availableStock ? 'bg-(--color-ternary) border-(--color-ternary)' : 'border-(--color-quaternary) hover:bg-(--color-secondary)'}"></button>
        <span class="text-nowrap text-(--color-quaternary) font-[390]"><span class="mr-1">—</span> {language.Shared.AvailableStock}?</span>
      </div>
    {/if}
  </div>
</div>

{#if result.length}
  {#if !userOnMobile}
    <div class="border-2 border-(--color-ternary) rounded-2xl overflow-hidden">
      <table class="w-full border-separate border-spacing-x-4 border-spacing-y-4 px-1 text-center text-sm text-[13px]">
        <thead>
        <tr>
          <th>{language.Shared.CPU}</th>
          {#if preset === "secondary"}
            <th>{language.Shared.Cores}</th>
          {/if}
          {#if preset !== "secondary"}
            <th>{language.Shared.GHz}</th>
            {#if preset === "primary"}
              <th>{language.Shared.GPU}</th>
            {/if}
          {/if}
          <th>{language.Shared.RAM} ({language.Shared.GB})</th>
          {#if preset !== "secondary"}
            <th>{language.Shared.RAMType}</th>
          {/if}
          <th>{language.Shared.Disk}</th>
          <th>{language.Shared.Country}</th>
          <th><p class="pl-4">{language.Shared.Region}</p></th>
          <th>{language.Shared.PricePerMonth}</th>
          {#if stock}
            <th><div class="flex gap-2 items-center justify-center">
              <span>{language.Shared.Availability}</span>
              <div title={language.Shared.CursorCircle}>
                <ProductHaveInfo title={language.Shared.CursorCircle}
                                 class="min-w-3.5 max-w-3.5 fill-(--color-ternary)
                                hover:fill-(--color-quaternary) transition-colors"/>
              </div>
            </div></th>
          {/if}
          <th></th>
        </tr>
        </thead>
        <tbody>
        {#each resultSorted as server (server.Id)}
          <tr>
            <td>{server.Data.CPU}</td>
            {#if preset === "secondary"}
              <td>{server.Data.Cores}</td>
            {/if}
            {#if preset !== "secondary"}
              <td>{server.Data.GHz}</td>
              {#if preset === "primary"}
                <td>{server.Data.GPU}</td>
              {/if}
            {/if}
            <td>{server.Data.RAM}</td>
            {#if preset !== "secondary"}
              <td>{server.Data.RAMType}</td>
            {/if}
            <td class="text-wrap! min-w-24">{server.Data.Disk} {#if server.Data.GB}{language.Shared.GB}{/if}{#if server.Data.TB}{language.Shared.TB}{/if}{#if !server.Data.TB && !server.Data.GB}{language.Shared.GB}{/if} {server.Data.DiskType}</td>
            <td>
              <div class="grid grid-cols-2 mt-0.5 gap-2 mx-auto w-fit">
                {#if server.Data.Germany}
                  <Germany class="min-h-4 max-h-4"/>
                {/if}
                {#if server.Data.Finland}
                  <Finland class="min-h-4 max-h-4"/>
                {/if}
                {#if server.Data.Russia}
                  <Russia class="min-h-4 max-h-4"/>
                {/if}
                {#if server.Data.USA}
                  <USA class="min-h-4 max-h-4"/>
                {/if}
                {#if server.Data.Singapore}
                  <Singapore class="min-h-4 max-h-4"/>
                {/if}
                {#if server.Data.France}
                  <France class="min-h-4 max-h-4"/>
                {/if}
                {#if server.Data.UnitedKingdom}
                  <Uk class="min-h-4 max-h-4"/>
                {/if}
                {#if server.Data.Poland}
                  <Poland class="min-h-4 max-h-4"/>
                {/if}
                {#if server.Data.Canada}
                  <Canada class="min-h-4 max-h-4"/>
                {/if}
                {#if !(server.Data.Germany || server.Data.Finland || server.Data.Russia || server.Data.USA || server.Data.Singapore || server.Data.France || server.Data.UnitedKingdom || server.Data.Poland || server.Data.Canada)}
                  ...
                {/if}
              </div>
            </td>
            <td class="text-left"><p class="pl-4">{@html getRegions(server)}</p></td>
            <td>{getPrice(server)}</td>
            {#if stock}
              <td>
                <div title={(!server.Russian || server.qty ? `${language.Shared.AvailableStock}. ` : '') + server.SetupTimes.find(setupTime => setupTime.WHMCSName === language.WHMCSName)?.Content} class="mt-1 place-self-center size-2 rounded-full flex justify-center items-center {(!server.Russian || server.qty) ? 'bg-green-500' : server.SetupTimes.find(setupTime => setupTime.WHMCSName === 'english')?.Content.includes('hour') ? 'bg-yellow-300' : 'bg-red-500'}">
                  <div class="absolute size-8 rounded-full"></div>
                </div>
              </td>
            {/if}
            <td><a rel="nofollow" class="primary-link mx-auto"
                   href="/store/store/{server.Link}" data-sveltekit-reload>{language.Shared.Order}</a></td>
          </tr>
        {/each}
        </tbody>
      </table>
    </div>
  {:else}
    <section class="flex flex-col gap-y-8">
      {#each resultSorted as server (server.Id)}
        {@const content = server.SetupTimes.find(setupTime => setupTime.WHMCSName === language.WHMCSName)?.Content}
        {@const setupTime = (!content || content === "...") ? null : splitAtFirstNumber(content)}
        {@render Card?.(server, setupTime)}
      {/each}
    </section>
  {/if}
{:else}
  <h1 class="mx-auto text-(--color-quaternary)">{'≽^•⩊•^≼'}</h1>
{/if}

<style>
  @reference "tailwindcss/theme";
  
  table {
    th, td {
      @apply p-0 text-nowrap;
    }
    
    th {
      @apply font-[350] pb-1;
    }
    
    td {
      @apply align-top;
    }
  }
</style>