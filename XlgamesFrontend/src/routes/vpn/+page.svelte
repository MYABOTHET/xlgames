<script>
  import {getContext} from "svelte";
  import SecondarySection from "$lib/components/sections/SecondarySection.svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
</script>

<svelte:head>
  <title>{language.VPN.Title} - {data.projectData.Name}</title>
  {@html language.VPN.Head}
</svelte:head>

<article class="secondary-section">
  <h1 class="primary-title">{language.VPN.Title}</h1>
  <p>{language.VPN.Description}</p>
  {#if language.VPN.VPNCollection.length}
    <SecondarySection items={language.VPN.VPNCollection}/>
  {/if}
</article>