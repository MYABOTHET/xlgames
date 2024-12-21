<script>
  import {store} from "$lib/state.svelte.js";
  import Title1 from "$lib/components/titles/Title1.svelte";
  import {onMount} from "svelte";
  
  const {data} = $props();
  
  let servers = $state(data.servers);
  let init = $state(false);
  onMount(async () => {
    let unsubscribe = store.subscribe(async () => {
      if (!init) {
        init = true;
        return 0;
      }
      servers = await (await fetch('/servers')).json();
    });
    return () => {
      unsubscribe();
    }
  })
</script>

<svelte:head>
  <title>{servers.title}</title>
</svelte:head>

<Title1>{servers.name}</Title1>

<div class="min-h-12"></div>

<p>{servers.description}</p>

<div class="min-h-8"></div>