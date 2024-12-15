<script>
  import {global_state} from "$lib/state.svelte.js";
  import Title1 from "$lib/components/titles/Title1.svelte";
  
  const {data} = $props();
</script>

<div class="max-w-screen-xlgames-3 w-full m-auto">
  <Title1>{global_state.language.pages.contacts.title}</Title1>
  
  <div class="min-h-8"></div>
  
  <article class="py-4 px-6 border-2 border-xlgames-3 rounded-2xl overflow-hidden">
    <h1>{global_state.language.pages.contacts.description}</h1>
    <div class="min-h-3"></div>
    <div class="border-b border-xlgames-2"></div>
    <div class="min-h-3"></div>
    <div class="text-sm flex flex-col gap-y-1">
      {#each global_state.language.pages.contacts.contacts as contact}
        <div class="flex">
          <div class="flex flex-auto min-w-28 max-w-28 h-fit">
            <h1 class="truncate">{contact.title}</h1>
            <div>:</div>
            <div class="flex-auto border-b-xlgames-4 border-b border-dotted min-w-2 my-1 mx-1"></div>
          </div>
          <h1 class="text-wrap break-all">{contact.description}</h1>
        </div>
      {/each}
    </div>
  </article>
</div>