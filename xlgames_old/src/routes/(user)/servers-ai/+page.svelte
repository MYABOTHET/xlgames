<script>
  import {store} from "$lib/state.svelte.js";
  import Title1 from "$lib/components/titles/Title1.svelte";
  import {onMount} from "svelte";
  
  const {data} = $props();
  
  let servers_ai = $state(data.servers_ai);
  let init = $state(false);
  onMount(async () => {
    let unsubscribe = store.subscribe(async () => {
      if (!init) {
        init = true;
        return 0;
      }
      servers_ai = await (await fetch('/servers-ai')).json();
    });
    return () => {
      unsubscribe();
    }
  })
</script>

<svelte:head>
  <title>{servers_ai.title}</title>
</svelte:head>

<Title1>{servers_ai.name}</Title1>

<div class="min-h-12"></div>

<p>{servers_ai.description}</p>

<div class="min-h-8"></div>