<script>
  import {store} from "$lib/state.svelte.js";
  import Title1 from "$lib/components/titles/Title1.svelte";
  import {onMount} from "svelte";
  
  const {data} = $props();
  
  let vpn_page = $state(data.vpn_page);
  let init = $state(false);
  onMount(async () => {
    let unsubscribe = store.subscribe(async () => {
      if (!init) {
        init = true;
        return 0;
      }
      vpn_page = await (await fetch('/vpn')).json();
    });
    return () => {
      unsubscribe();
    }
  })
</script>

<svelte:head>
  <title>{vpn_page.title}</title>
</svelte:head>

<Title1>{vpn_page.name}</Title1>

<div class="min-h-12"></div>

<p>{vpn_page.description}</p>

<div class="min-h-12"></div>

<p>{vpn_page.whatDoesOurVPNGive}</p>