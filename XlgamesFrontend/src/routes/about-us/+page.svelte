<script>
  import {getContext} from "svelte";
  import PrimaryTitle from "$lib/components/Titles/PrimaryTitle.svelte";
  import SecondaryScreen from "$lib/components/Screens/SecondaryScreen.svelte";
  
  const {data} = $props();
  const {project} = data;
  
  const language = $derived(getContext('language')());
</script>

<svelte:head>
  <title>{language["AboutUs"]["Title"]} - {project.name}</title>
</svelte:head>

<div class="flex-center">
  <SecondaryScreen class="secondary-gap-y flex flex-col">
    <PrimaryTitle>{language["AboutUs"]["Name"]}</PrimaryTitle>
    <img class="primary-img rounded-2xl min-h-[16.5rem] max-h-[16.5rem]" src={language["AboutUs"]["Src"]}
         alt={language["AboutUs"]["Name"]}>
    <div class="news-description whitespace-pre">
      {@html language["AboutUs"]["Description"]}
    </div>
    <div class="news-description">{language["Shared"]["AnySuggestionsStart"]}
      <a href="/contacts">{language["Shared"]["AnySuggestionsCenter"]}</a>
      {language["Shared"]["AnySuggestionsEnd"]}</div>
  </SecondaryScreen>
</div>