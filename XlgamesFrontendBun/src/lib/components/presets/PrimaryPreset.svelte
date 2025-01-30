<script>
  import {getContext} from "svelte";
  import Singapore from "$lib/components/svg/flags/Singapore.svelte";
  import Germany from "$lib/components/svg/flags/Germany.svelte";
  import Finland from "$lib/components/svg/flags/Finland.svelte";
  import Russia from "$lib/components/svg/flags/Russia.svelte";
  import USA from "$lib/components/svg/flags/USA.svelte";
  import SecondaryDropdownMenu from "$lib/components/dropdown-menus/SecondaryDropdownMenu.svelte";
  import France from "$lib/components/svg/flags/France.svelte";
  
  const {serversProp, userOnMobile, preset, ...props} = $props();
  
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
  
  function selectCPU(CPU) {
    currentCPU = CPU;
    filter();
  }
  
  function selectGPU(GPU) {
    currentGPU = GPU;
    filter();
  }
  
  function selectCountry(country) {
    countryKey = country ? getKeyByValue(language.Shared, country) : null;
    currentCountry = country;
    filter();
  }
  
  function selectRegion(region) {
    regionKey = region ? getKeyByValue(language.Shared, region) : null;
    currentRegion = region;
    filter();
  }
  
  function filter() {
    const servers = serversProp.filter(server =>
        (currentCPU ? server.Data.CPU === currentCPU : true) &&
        (currentCountry ? server.Data[countryKey] : true) &&
        (currentRegion ? server.Data[regionKey] : true) &&
        (preset === "primary" ? (currentGPU ? server.Data.GPU === currentGPU : true) : true)
    );
    
    CPUs = new Set(serversProp.filter(server =>
        (currentCountry ? server.Data[countryKey] : true) &&
        (currentRegion ? server.Data[regionKey] : true) &&
        (preset === "primary" ? (currentGPU ? server.Data.GPU === currentGPU : true) : true)
    ).map(server => server.Data.CPU));
    
    const serversCountries = serversProp.filter(server =>
        (currentCPU ? server.Data.CPU === currentCPU : true) &&
        (currentRegion ? server.Data[regionKey] : true) &&
        (preset === "primary" ? (currentGPU ? server.Data.GPU === currentGPU : true) : true));
    
    if (currentRegion) {
      countries = findCountry(currentRegion);
    } else {
      countries = initCountries(serversCountries);
    }
    
    const serversRegions = serversProp.filter(server =>
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
  
  function clearFilters() {
    if (currentCPU || currentCountry || currentRegion || currentGPU) {
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
    });
    return countries;
  }
  
  function findCountry(region) {
    let country = new Set();
    if (language.Shared.Falkenstein === region ||
        language.Shared.Frankfurt === region ||
        language.Shared.Nuremberg === region) {
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
    if (language.Shared.Gravelines === region) {
      country.add(language.Shared.France);
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
      }
      if (server.Data.Finland && language.Shared.Finland === country) {
        if (server.Data.Helsinki) regions.add(language.Shared.Helsinki);
      }
      if (server.Data.France && language.Shared.France === country) {
        if (server.Data.Gravelines) regions.add(language.Shared.Gravelines);
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
      }
      if (server.Data.Finland) {
        if (server.Data.Helsinki) regions.add(language.Shared.Helsinki);
      }
      if (server.Data.France) {
        if (server.Data.Gravelines) regions.add(language.Shared.Gravelines);
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
    if (!regions.length) regions.push("...");
    return regions.join(", ");
  }
  
  function getPrice(server) {
    const sign = language.Shared.CurrencySign;
    const position = language.Shared.CurrencySignPosition;
    const price = priceFormatter.format(server.Pricings.find(pricing => pricing.CurrencyId === language.CurrencyId).Price);
    return position ? sign + price : price + sign;
  }
</script>

{#snippet Enum(title, description)}
  <article class="flex">
    <article class="flex min-w-44 max-hexadecimal:min-w-fit max-hexadecimal:flex-1">
      <h1 class="text-nowrap h-fit">{title}</h1>
      <div class="min-w-4 flex-1 secondary-line"></div>
    </article>
    <h1 class="text-wrap break-all">{description}</h1>
  </article>
{/snippet}

{#snippet Card(server)}
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
    {@render Enum(`${language.Shared.Disk} (${language.Shared.GB})`, server.Data.Disk)}
    {@render Enum(language.Shared.DiskType, server.Data.DiskType)}
    {@render Enum(language.Shared.Country, getCountries(server))}
    {@render Enum(language.Shared.Region, getRegions(server))}
    {@render Enum(language.Shared.PricePerMonth, getPrice(server))}
    <a rel="nofollow" class="primary-link mx-auto mt-3" href="/store/store/{server.Link}">{language.Shared.Order}</a>
  </section>
{/snippet}

<div {...props} class="{props.class} flex flex-wrap gap-4">
  <SecondaryDropdownMenu class="min-w-80 max-w-80 max-nine:max-w-full max-nine:min-w-full flex-[1_1_100%]"
                         currentItem={currentCPU} defaultItem={language.Shared.AnyCPU} items={CPUs}
                         select={selectCPU}>
  </SecondaryDropdownMenu>
  {#if preset === "primary"}
    <SecondaryDropdownMenu class="min-w-72 max-w-72 max-nine:max-w-full max-nine:min-w-full flex-[1_1_100%]"
                           defaultItem={language.Shared.AnyGPU} select={selectGPU} currentItem={currentGPU}
                           items={GPUs}>
    </SecondaryDropdownMenu>
  {/if}
  <SecondaryDropdownMenu class="min-w-56 max-w-56 max-nine:max-w-full max-nine:min-w-full flex-[1_1_100%]"
                         currentItem={currentCountry} defaultItem={language.Shared.AnyCountry} items={countries}
                         select={selectCountry}>
  </SecondaryDropdownMenu>
  <SecondaryDropdownMenu class="min-w-56 max-w-56 max-nine:max-w-full max-nine:min-w-full flex-[1_1_100%]"
                         currentItem={currentRegion} defaultItem={language.Shared.AnyRegion} items={regions}
                         select={selectRegion}>
  </SecondaryDropdownMenu>
  <button class="border-2 px-6 py-2.5 rounded-full text-nowrap transition-colors hover:bg-(--color-secondary)
border-(--color-quaternary) text-(--color-quaternary) max-nine:w-full"
          onclick={clearFilters}>{language.Shared.ResetFilters}</button>
</div>
{#if result.length}
  {#if !userOnMobile}
    <div class="border-2 border-(--color-ternary) rounded-2xl overflow-hidden">
      <table class="w-full border-separate border-spacing-4 px-2 text-center text-sm">
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
          <th>{language.Shared.Disk} ({language.Shared.GB})</th>
          <th>{language.Shared.DiskType}</th>
          <th>{language.Shared.Country}</th>
          <th>{language.Shared.Region}</th>
          <th>{language.Shared.PricePerMonth}</th>
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
            <td>{server.Data.Disk}</td>
            <td>{server.Data.DiskType}</td>
            <td>
              <div class="flex flex-wrap justify-center gap-2 mx-auto max-w-[60px] min-w-[60px]">
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
                {#if !(server.Data.Germany || server.Data.Finland || server.Data.Russia || server.Data.USA || server.Data.Singapore || server.Data.France)}
                  ...
                {/if}
              </div>
            </td>
            <td class="text-wrap! break-all">{getRegions(server)}</td>
            <td>{getPrice(server)}</td>
            <td><a rel="nofollow" class="primary-link mx-auto"
                   href="/store/store/{server.Link}">{language.Shared.Order}</a></td>
          </tr>
        {/each}
        </tbody>
      </table>
    </div>
  {:else}
    <section class="flex flex-col gap-y-8">
      {#each resultSorted as server (server.Id)}
        {@render Card?.(server)}
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