<script>
  import {getContext} from "svelte";
  import PrimaryTitle from "$lib/components/Titles/PrimaryTitle.svelte";
  import PrimaryCard from "$lib/components/Cards/PrimaryCard.svelte";
  import SecondaryScreen from "$lib/components/Screens/SecondaryScreen.svelte";
  import TernaryLink from "$lib/components/Links/TernaryLink.svelte";
  
  const {data} = $props();
  const {project} = data;
  
  const language = $derived(getContext('language')());
  let news = $state(data.news);
  let locale = $state(language["Locale"]);
  
  $effect(async () => {
    if (language["Locale"] !== locale) {
      locale = language["Locale"];
      const url = new URL(`${location.origin}/news/${news["ParentId"]}`);
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
  <title>{language["News"]["Title"]} - {news["Name"]} - {project.name}</title>
</svelte:head>

<div class="flex-center">
  <SecondaryScreen class="secondary-gap-y flex flex-col">
    <TernaryLink class="w-fit" href="/news">{news["Name"]}</TernaryLink>
    <div class="flex flex-col gap-y-4 items-center">
      <img class="primary-img rounded-2xl min-h-[16.5rem] max-h-[16.5rem]" src={news["Src"]} alt={news["Name"]}>
      <h1 class="text-xs text-xlgames-quaternary font-normal">{formatter.format(new Date(news["Date"]))}</h1>
    </div>
    <div class="news-description whitespace-pre">
      {@html news["Description"]}
    </div>
  </SecondaryScreen>
</div>