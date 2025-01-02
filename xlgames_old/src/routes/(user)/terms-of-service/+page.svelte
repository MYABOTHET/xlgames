<script>
  import {store} from "$lib/state.svelte.js";
  import Title1 from "$lib/components/titles/Title1.svelte";
  import {onMount} from "svelte";
  
  const {data} = $props();
  
  let terms_of_service = $state(data.terms_of_service);
  let init = $state(false);
  onMount(async () => {
    let unsubscribe = store.subscribe(async () => {
      if (!init) {
        init = true;
        return 0;
      }
      terms_of_service = await (await fetch('/terms-of-service')).json();
    });
    return () => {
      unsubscribe();
    }
  })
</script>

<svelte:head>
  <title>{terms_of_service.title}</title>
</svelte:head>

<Title1>{terms_of_service.name}</Title1>

<div class="min-h-12"></div>

<p>{terms_of_service.description}</p>

<div class="min-h-12"></div>

<div class="flex flex-col gap-y-4">
  {#each terms_of_service.items as item, index}
    <article class="flex flex-col gap-y-1">
      <h1 class="text-xlgames-3 font-semibold">{item.title}</h1>
      <p>{item.description}</p>
    </article>
    {#if terms_of_service.items.length - 1 !== index}
      <div class="border-b border-b-xlgames-2"></div>
    {/if}
  {/each}
</div>