<script>
  import {getContext} from "svelte";
  import PrimaryTitle from "$lib/components/Titles/PrimaryTitle.svelte";
  
  const {data} = $props();
  const {project} = data;
  
  const language = $derived(getContext('language')());
</script>

<svelte:head>
  <title>{language["VPN"]["Title"]} - {project.name}</title>
</svelte:head>

<PrimaryTitle>{language["VPN"]["Name"]}</PrimaryTitle>