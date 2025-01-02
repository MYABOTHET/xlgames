<script>
  import {store} from "$lib/state.svelte.js";
  import Title1 from "$lib/components/titles/Title1.svelte";
  import {onMount} from "svelte";
  
  const {data} = $props();
  
  let game_servers = $state(data.game_servers);
  let init = $state(false);
  onMount(async () => {
    let unsubscribe = store.subscribe(async () => {
      if (!init) {
        init = true;
        return 0;
      }
      game_servers = await (await fetch('/game-servers')).json();
    });
    return () => {
      unsubscribe();
    }
  })
</script>

<svelte:head>
  <title>{game_servers.title}</title>
</svelte:head>

<Title1>{game_servers.name}</Title1>