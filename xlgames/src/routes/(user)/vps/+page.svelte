<script>
  import {store} from "$lib/state.svelte.js";
  import Title1 from "$lib/components/titles/Title1.svelte";
  import {onMount} from "svelte";
  
  const {data} = $props();
  
  let vps_page = $state(data.vps_page);
  let init = $state(false);
  onMount(async () => {
    let unsubscribe = store.subscribe(async () => {
      if (!init) {
        init = true;
        return 0;
      }
      vps_page = await (await fetch('/vps')).json();
    });
    return () => {
      unsubscribe();
    }
  })
</script>

<svelte:head>
  <title>{vps_page.title}</title>
</svelte:head>

<Title1>{vps_page.name}</Title1>

<div class="min-h-12"></div>

<p>{vps_page.description}</p>

<div class="min-h-8"></div>