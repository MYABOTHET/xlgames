<script>
  import {store} from "$lib/state.svelte.js";
  import Title1 from "$lib/components/titles/Title1.svelte";
  import {onMount} from "svelte";
  
  const {data} = $props();
  
  let contacts_page = $state(data.contacts_page);
  let init = $state(false);
  onMount(async () => {
    let unsubscribe = store.subscribe(async () => {
      if (!init) {
        init = true;
        return 0;
      }
      contacts_page = await (await fetch('/contacts')).json();
    });
    return () => {
      unsubscribe();
    }
  })
</script>

<svelte:head>
  <title>{contacts_page.title}</title>
</svelte:head>

<div class="max-w-screen-xlgames-3 w-full m-auto">
  <Title1>{contacts_page.name}</Title1>
  
  <div class="min-h-8"></div>
  
  <article class="py-4 px-6 border-2 border-xlgames-3 rounded-2xl overflow-hidden">
    <h1 class="text-lg">{contacts_page.description}</h1>
    <div class="min-h-3"></div>
    <div class="border-b border-xlgames-2"></div>
    <div class="min-h-3"></div>
    <div class="flex flex-col gap-y-1">
      {#each contacts_page.contacts as contact}
        <div class="flex">
          <div class="flex flex-auto min-w-28 max-w-28 h-fit">
            <h1 class="truncate">{contact.title}</h1>
            <div>:</div>
            <div class="flex-auto border-b-xlgames-4 border-b border-dotted min-w-2 my-1 mx-1"></div>
          </div>
          <h1 class="text-wrap break-all">{contact.description}</h1>
        </div>
      {/each}
      {#if contacts_page.contacts.length === 0}
        <Title1 class="text-xl text-xlgames-4 text-center py-2">{'(* ^ ω ^)'}</Title1>
      {/if}
    </div>
  </article>
</div>