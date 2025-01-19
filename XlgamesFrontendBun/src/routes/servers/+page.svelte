<script>
  import {getContext} from "svelte";
  import Germany from "$lib/components/svg/flags/Germany.svelte";
  import Finland from "$lib/components/svg/flags/Finland.svelte";
  import Russia from "$lib/components/svg/flags/Russia.svelte";
  import USA from "$lib/components/svg/flags/USA.svelte";
  import Singapore from "$lib/components/svg/flags/Singapore.svelte";
  import SecondaryDropdownMenu from "$lib/components/dropdown-menus/SecondaryDropdownMenu.svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
  
  let result = $state.raw(data.servers);
  // Костыль
  let init = $state.raw({init: false});
  
  let countryKey = $state(null);
  let regionKey = $state(null);
  
  let CPUs = $state.raw(initCPUs(data.servers));
  let currentCPU = $state(null);
  
  let countries = $state.raw(initCountries(data.servers));
  let currentCountry = $state(null);
  
  let regions = $state.raw(initRegions(data.servers));
  let currentRegion = $state(null);
  
  function selectCPU(CPU) {
    currentCPU = CPU;
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
    const servers = data.servers.filter(server =>
        (currentCPU ? server.Data.CPU === currentCPU : true) &&
        (currentCountry ? server.Data[countryKey] : true) &&
        (currentRegion ? server.Data[regionKey] : true)
    );
    if (currentCountry || currentRegion) {
      CPUs = initCPUs(servers);
    } else {
      CPUs = initCPUs(data.servers);
    }
    if (currentCPU || currentRegion) {
      countries = initCountries(servers)
    } else {
      countries = initCountries(data.servers)
    }
    if (currentCountry || currentCPU) {
      regions = initRegions(servers)
    } else {
      regions = initRegions(data.servers)
    }
    result = servers;
  }
  
  $effect(() => {
    language;
    reinit();
  });
  
  function clearFilters() {
    if (currentCPU || currentCountry || currentRegion) {
      reinit();
    }
  }
  
  function reinit() {
    if (init.init) {
      result = data.servers;
      CPUs = initCPUs(data.servers);
      currentCPU = null;
      countries = initCountries(data.servers);
      currentCountry = null;
      regions = initRegions(data.servers);
      currentRegion = null;
      countryKey = null;
      regionKey = null;
    } else {
      init.init = true;
    }
  }
  
  function initCPUs(servers) {
    return new Set(servers.map(server => server.Data.CPU));
  }
  
  function initCountries(servers) {
    let countries = new Set();
    servers.forEach(server => {
      if (server.Data.Germany) countries.add(language.Shared.Germany);
      if (server.Data.Finland) countries.add(language.Shared.Finland);
      if (server.Data.Russia) countries.add(language.Shared.Russia);
      if (server.Data.USA) countries.add(language.Shared.USA);
      if (server.Data.Singapore) countries.add(language.Shared.Singapore);
    });
    return countries;
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
      if (server.Data.Russia) {
        if (server.Data.Moscow) regions.add(language.Shared.Moscow);
        if (server.Data.SaintPetersburg) regions.add(language.Shared.SaintPetersburg);
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
</script>

<svelte:head>
  <title>{language.ServersWithoutGPU.Title} - {data.projectData.Name}</title>
  {@html language.ServersWithoutGPU.Head}
</svelte:head>

<article class="flex flex-col gap-y-14">
  <h1 class="primary-title">{language.ServersWithoutGPU.Title}</h1>
  <p>{language.ServersWithoutGPU.Description}</p>
  <div class="flex flex-wrap gap-4">
    <SecondaryDropdownMenu class="min-w-80 max-w-80 max-nine:max-w-full max-nine:min-w-full flex-[1_1_100%]"
                           defaultItem={language.Shared.AnyCPU} select={selectCPU} currentItem={currentCPU}
                           items={CPUs}>
    </SecondaryDropdownMenu>
    <SecondaryDropdownMenu class="min-w-56 max-w-56 max-nine:max-w-full max-nine:min-w-full flex-[1_1_100%]"
                           defaultItem={language.Shared.AnyCountry} select={selectCountry} currentItem={currentCountry}
                           items={countries}>
    </SecondaryDropdownMenu>
    <SecondaryDropdownMenu class="min-w-56 max-w-56 max-nine:max-w-full max-nine:min-w-full flex-[1_1_100%]"
                           defaultItem={language.Shared.AnyRegion} select={selectRegion} currentItem={currentRegion}
                           items={regions}>
    </SecondaryDropdownMenu>
    <button onclick={clearFilters} class="border-2 px-6 py-2.5 rounded-full text-nowrap transition-colors hover:bg-secondary
border-quaternary text-quaternary max-nine:w-full">Сбросить фильтры</button>
  </div>
  {#if result.length}
    <div class="border-2 border-ternary rounded-2xl overflow-hidden">
      <table class="w-full border-separate border-spacing-4 px-2 text-center
text-sm">
        <thead>
        <tr>
          <th>{language.Shared.CPU}</th>
          <th>{language.Shared.GHz}</th>
          <th>{language.Shared.RAM} ({language.Shared.GB})</th>
          <th>{language.Shared.RAMType}</th>
          <th>{language.Shared.Disk} ({language.Shared.GB})</th>
          <th>{language.Shared.DiskType}</th>
          <th class="min-w-[60px]">{language.Shared.Country}</th>
          <th class="w-full">{language.Shared.Region}</th>
          <th>{language.Shared.PricePerMonth}</th>
          <th></th>
        </tr>
        </thead>
        <tbody>
        {#each result.slice().sort(compareNumeric) as server (server.Id)}
          {@const regions = ''.concat(
              server.Data.Falkenstein ? ', ' + language.Shared.Falkenstein : '',
              server.Data.Frankfurt ? ', ' + language.Shared.Frankfurt : '',
              server.Data.Nuremberg ? ', ' + language.Shared.Nuremberg : '',
              server.Data.Helsinki ? ', ' + language.Shared.Helsinki : '',
              server.Data.Moscow ? ', ' + language.Shared.Moscow : '',
              server.Data.SaintPetersburg ? ', ' + language.Shared.SaintPetersburg : '',
              server.Data.NewYork ? ', ' + language.Shared.NewYork : '',
              server.Data.Miami ? ', ' + language.Shared.Miami : '',
              server.Data.LosAngeles ? ', ' + language.Shared.LosAngeles : '',
              server.Data.Hillsboro ? ', ' + language.Shared.Hillsboro : '',
              server.Data.Ashburn ? ', ' + language.Shared.Ashburn : '',
              server.Data.Singapore ? ', ' + language.Shared.Singapore : '').slice(2)}
          {@const sign = language.Shared.CurrencySign}
          {@const position = language.Shared.CurrencySignPosition}
          {@const price = server.Pricings.find(pricing => pricing.CurrencyId === language.CurrencyId).Price}
          <tr>
            <td>{server.Data.CPU}</td>
            <td>{server.Data.GHz}</td>
            <td>{server.Data.RAM}</td>
            <td>{server.Data.RAMType}</td>
            <td>{server.Data.Disk}</td>
            <td>{server.Data.DiskType}</td>
            <td class="min-w-[60px]">
              <div class="grid grid-cols-2 gap-2 py-0.5">
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
              </div>
            </td>
            <td class="!text-wrap w-full">{regions}</td>
            <td>{position ? sign + price : price + sign}</td>
            <td><a class="primary-link" href="/store/store/{server.Link}">{language.Shared.Order}</a></td>
          </tr>
        {/each}
        </tbody>
      </table>
    </div>
  {:else}
    <h1 class="mx-auto text-quaternary">{'≽^•⩊•^≼'}</h1>
  {/if}
</article>

<style lang="postcss">
  table {
    th, td {
      @apply p-0 text-nowrap;
    }
    
    th {
      @apply font-[350];
    }
    
    td {
      @apply align-top;
    }
  }
</style>