<script>
  import {getContext} from "svelte";
  import SecondaryDropdownMenu from "$lib/components/dropdown-menus/SecondaryDropdownMenu.svelte";
  import Germany from "$lib/components/svg/flags/Germany.svelte";
  import Finland from "$lib/components/svg/flags/Finland.svelte";
  import Russia from "$lib/components/svg/flags/Russia.svelte";
  import USA from "$lib/components/svg/flags/USA.svelte";
  import Singapore from "$lib/components/svg/flags/Singapore.svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
  const servers = [
    {
      id: 1,
      price: 5974.43,
      info: {
        CPU: "Intel Core i5 13500",
        GHz: 4.8,
        RAM: "64...128",
        RAMType: "DDR4",
        Disk: "2x512",
        DiskType: "SSD",
        
        Germany: true,
        Falkenstein: false,
        Frankfurt: true,
        Nuremberg: false,
        
        Finland: true,
        Helsinki: true,
        
        Russia: false,
        Moscow: false,
        SaintPetersburg: false,
        
        USA: false,
        NewYork: false,
        Miami: false,
        LosAngeles: false,
        Hillsboro: false,
        Ashburn: false,
        
        Singapore: false
      }
    },
    {
      id: 2,
      price: 1200.97,
      info: {
        CPU: "AMD Ryzen 9 5950X",
        GHz: 4.9,
        RAM: "128",
        RAMType: "DDR5",
        Disk: "2048",
        DiskType: "NVMe",
        
        Germany: false,
        Falkenstein: false,
        Frankfurt: false,
        Nuremberg: false,
        
        Finland: false,
        Helsinki: false,
        
        Russia: false,
        Moscow: false,
        SaintPetersburg: false,
        
        USA: true,
        NewYork: true,
        Miami: true,
        LosAngeles: true,
        Hillsboro: false,
        Ashburn: false,
        
        Singapore: false
      }
    }
  ];
  let list = $state(servers);
  
  let CPU = $state(null);
  let CPUs = servers.map(server => server.info.CPU);
  let Country = $state(null);
  let CountryKey = $state(null);
  let Countries = $derived.by(() => {
    let countries = new Set();
    list.forEach(server => {
      if (!CPU || server.info.CPU === CPU) {
        if (server.info.Germany) countries.add(language.Shared.Germany);
        if (server.info.Finland) countries.add(language.Shared.Finland);
        if (server.info.Russia) countries.add(language.Shared.Russia);
        if (server.info.USA) countries.add(language.Shared.USA);
        if (server.info.Singapore) countries.add(language.Shared.Singapore);
      }
    });
    return countries;
  });
  let Region = $state(null);
  let RegionKey = $state(null);
  let Regions = $derived.by(() => {
    let regions = new Set();
    list.forEach(server => {
      if (!Country || Country === language.Shared.Germany) {
        if (server.info.Falkenstein) regions.add(language.Shared.Falkenstein);
        if (server.info.Frankfurt) regions.add(language.Shared.Frankfurt);
        if (server.info.Nuremberg) regions.add(language.Shared.Nuremberg);
      }
      if (!Country || Country === language.Shared.Finland) {
        if (server.info.Helsinki) regions.add(language.Shared.Helsinki);
      }
      if (!Country || Country === language.Shared.Russia) {
        if (server.info.Moscow) regions.add(language.Shared.Moscow);
        if (server.info.SaintPetersburg) regions.add(language.Shared.SaintPetersburg);
      }
      if (!Country || Country === language.Shared.USA) {
        if (server.info.NewYork) regions.add(language.Shared.NewYork);
        if (server.info.Miami) regions.add(language.Shared.Miami);
        if (server.info.LosAngeles) regions.add(language.Shared.LosAngeles);
        if (server.info.Hillsboro) regions.add(language.Shared.Hillsboro);
        if (server.info.Ashburn) regions.add(language.Shared.Ashburn);
      }
      if (!Country || Country === language.Shared.Singapore) {
        regions.add(language.Shared.Singapore);
      }
    });
    return regions;
  });
  
  function selectCPU(newCPU) {
    if (CPU === newCPU) return;
    CPU = newCPU;
    if (CPU) {
      list = servers.filter(server => server.info.CPU === CPU);
    } else {
      list = servers.slice();
    }
    selectCountry(null);
  }
  
  function selectCountry(newCountry) {
    if (Country === newCountry) return;
    Country = newCountry;
    Country ? CountryKey = Object.keys(language.Shared).find(key => language.Shared[key] === Country) : CountryKey = null;
    if (Country) {
      list = list.filter(server => server.info[CountryKey]);
    }
    selectRegion(null);
  }
  
  function selectRegion(newRegion) {
    if (Region === newRegion) return;
    Region = newRegion;
    Region ? RegionKey = Object.keys(language.Shared).find(key => language.Shared[key] === Region) : RegionKey = null;
    if (Region) {
      list = list.filter(server => server.info[RegionKey]);
    }
  }
  
  $effect(() => {
    if (Country) Country = language.Shared[CountryKey];
    if (Region) Region = language.Shared[RegionKey];
  });
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
                           values={CPUs} item={CPU}
                           defaultItem={language.Shared.AnyCPU} select={selectCPU}/>
    <SecondaryDropdownMenu class="min-w-60 max-w-60 max-nine:max-w-full max-nine:min-w-full flex-[1_1_25%]"
                           values={Countries} item={Country}
                           defaultItem={language.Shared.AnyCountry} select={selectCountry}/>
    <SecondaryDropdownMenu class="min-w-60 max-w-60 max-nine:max-w-full max-nine:min-w-full flex-[1_1_25%]"
                           values={Regions} item={Region}
                           defaultItem={language.Shared.AnyRegion} select={selectRegion}/>
  </div>
  <div class="border-2 border-ternary rounded-2xl overflow-hidden">
    <table class="w-full border-separate border-spacing-4 px-2 text-[0.9375rem] leading-[1.375rem] text-center">
      <thead>
      <tr>
        <th>{language.Shared.CPU}</th>
        <th>{language.Shared.GHz}</th>
        <th>{language.Shared.RAM} ({language.Shared.GB})</th>
        <th>{language.Shared.RAMType}</th>
        <th>{language.Shared.Disk} ({language.Shared.GB})</th>
        <th>{language.Shared.DiskType}</th>
        <th>{language.Shared.Country}</th>
        <th>{language.Shared.Region}</th>
        <th>{language.Shared.PricePerMonth}</th>
        <th></th>
      </tr>
      </thead>
      <tbody>
      {#each servers as server (server.id)}
        {@const regions = ''.concat(
            server.info.Falkenstein ? ', ' + language.Shared.Falkenstein : '',
            server.info.Frankfurt ? ', ' + language.Shared.Frankfurt : '',
            server.info.Nuremberg ? ', ' + language.Shared.Nuremberg : '',
            server.info.Helsinki ? ', ' + language.Shared.Helsinki : '',
            server.info.Moscow ? ', ' + language.Shared.Moscow : '',
            server.info.SaintPetersburg ? ', ' + language.Shared.SaintPetersburg : '',
            server.info.NewYork ? ', ' + language.Shared.NewYork : '',
            server.info.Miami ? ', ' + language.Shared.Miami : '',
            server.info.LosAngeles ? ', ' + language.Shared.LosAngeles : '',
            server.info.Hillsboro ? ', ' + language.Shared.Hillsboro : '',
            server.info.Ashburn ? ', ' + language.Shared.Ashburn : '',
            server.info.Singapore ? ', ' + language.Shared.Singapore : '').slice(2)}
        {@const sign = language.Shared.CurrencySign}
        {@const position = language.Shared.CurrencySignPosition}
        {@const price = Math.floor(server.price)}
        <tr>
          <td>{server.info.CPU}</td>
          <td>{server.info.GHz}</td>
          <td>{server.info.RAM}</td>
          <td>{server.info.RAMType}</td>
          <td>{server.info.Disk}</td>
          <td>{server.info.DiskType}</td>
          <td>
            <div class="grid grid-cols-2 gap-1.5 py-0.5">
              {#if server.info.Germany}<Germany class="min-h-4 max-h-4"/>{/if}
              {#if server.info.Finland}<Finland class="min-h-4 max-h-4"/>{/if}
              {#if server.info.Russia}<Russia class="min-h-4 max-h-4"/>{/if}
              {#if server.info.USA}<USA class="min-h-4 max-h-4"/>{/if}
              {#if server.info.Singapore}<Singapore class="min-h-4 max-h-4"/>{/if}
            </div>
          </td>
          <td class="w-full !text-wrap">{regions}</td>
          <td>{position ? sign + price : price + sign}</td>
          <td><a class="primary-link" href="/">{language.Shared.Order}</a></td>
        </tr>
      {/each}
      </tbody>
    </table>
  </div>
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