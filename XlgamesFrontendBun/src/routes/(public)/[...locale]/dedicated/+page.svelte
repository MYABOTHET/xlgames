<script>
  import {getContext, onMount} from "svelte";
  import PrimaryPreset from "$lib/components/presets/PrimaryPreset.svelte";
  import QuinaryCard from "$lib/components/cards/QuinaryCard.svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
  
  let userOnMobile = $state(data.userOnMobile);
  
  function setUserOnMobile(event) {
    userOnMobile = event.matches;
  }
  
  onMount(() => {
    // 1rem = 16px;
    userOnMobile = (window.innerWidth / 16) <= data.mobileWidth;
    const matchMedia = `(max-width: ${data.mobileWidth}rem)`;
    const mql = window.matchMedia(matchMedia);
    mql.addEventListener("change", setUserOnMobile);
    return () => {
      mql.removeEventListener("change", setUserOnMobile);
    };
  });
</script>

<svelte:head>
  <title>{language.ServersWithoutGPU.Title} - {data.projectData.Name}</title>
  {@html language.ServersWithoutGPU.Head}
</svelte:head>

<article class="flex flex-col gap-y-14">
  <h1 class="primary-title">{language.ServersWithoutGPU.Name}</h1>
  <p>{language.ServersWithoutGPU.Description}</p>
  <PrimaryPreset serversProp={data.servers} {userOnMobile}/>
  <QuinaryCard/>
</article>