<script>
  import {store} from "$lib/state.svelte.js";
  import Title1 from "$lib/components/titles/Title1.svelte";
  import {onMount} from "svelte";
  
  const {data} = $props();
  
  let privacy_policy = $state(data.privacy_policy);
  let init = $state(false);
  onMount(async () => {
    let unsubscribe = store.subscribe(async () => {
      if (!init) {
        init = true;
        return 0;
      }
      privacy_policy = await (await fetch('/privacy-policy')).json();
    });
    return () => {
      unsubscribe();
    }
  })
</script>

<svelte:head>
  <title>{privacy_policy.title}</title>
</svelte:head>

<Title1>{privacy_policy.name}</Title1>