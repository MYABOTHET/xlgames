<script>
  import {store} from "$lib/state.svelte.js";
  import Title1 from "$lib/components/titles/Title1.svelte";
  import {onMount} from "svelte";
  
  const {data} = $props();
  
  let data_center_page = $state(data.data_center_page);
  let init = $state(false);
  onMount(async () => {
    let unsubscribe = store.subscribe(async () => {
      if (!init) {
        init = true;
        return 0;
      }
      data_center_page = await (await fetch('/data-center')).json();
    });
    return () => {
      unsubscribe();
    }
  })
</script>

<svelte:head>
  <title>{data_center_page.title}</title>
</svelte:head>

<Title1>{data_center_page.name}</Title1>

<div class="min-h-12"></div>

<p class="whitespace-pre-wrap">{data_center_page.description}</p>

<div class="min-h-12"></div>

<div class="flex flex-col gap-y-4">
  {#each data_center_page.items as item, index}
    <article class="flex flex-col gap-y-1">
      <h1 class="text-xlgames-3 font-semibold">{item.title}</h1>
      <p>{item.description}</p>
    </article>
    {#if data_center_page.items.length - 1 !== index}
      <div class="border-b border-b-xlgames-2"></div>
    {/if}
  {/each}
</div>

<div class="min-h-12"></div>

{#if data_center_page.points.length > 0}
  <div class="w-full border-2 border-xlgames-3 py-6 rounded-2xl px-8 flex flex-col gap-y-3">
    {#each data_center_page.points as point}
      <div class="flex gap-x-6 items-center">
        <div class="text-2xl text-xlgames-3">•</div>
        <p>{point}</p>
      </div>
    {/each}
  </div>
{/if}