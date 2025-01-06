<script>
  import {getContext} from "svelte";
  import PrimaryTitle from "$lib/components/Titles/PrimaryTitle.svelte";
  import PrimaryCard from "$lib/components/Cards/PrimaryCard.svelte";
  
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
  <title>{language["News"]["Title"]} - {project.name}</title>
</svelte:head>

<div class="secondary-gap-y flex flex-col">
  <PrimaryTitle>{language["News"]["Name"]}</PrimaryTitle>
  
  <div class="grid gap-cols-1 md:grid-cols-2 gap-[26px]">
    {#each news as newsItem}
      <PrimaryCard class="min-h-[16.5rem] max-h-[16.5rem]" href="/news/{newsItem['ParentId']}"
                   src={newsItem["Src"]} alt={newsItem['Name']}
                   name={newsItem["Name"]} title={formatter.format(new Date(newsItem["Date"]))}/>
    {/each}
  </div>
</div>