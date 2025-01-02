<script>
  import {global_state, store} from "$lib/state.svelte.js";
  import Title1 from "$lib/components/titles/Title1.svelte";
  import {onMount} from "svelte";
  
  const {data} = $props();
  
  let web_hosting_page = $state(data.web_hosting_page);
  let init = $state(false);
  onMount(async () => {
    let unsubscribe = store.subscribe(async () => {
      if (!init) {
        init = true;
        return 0;
      }
      web_hosting_page = await (await fetch('/web-hosting')).json();
    });
    return () => {
      unsubscribe();
    }
  })

</script>

<svelte:head>
  <title>{web_hosting_page.title}</title>
</svelte:head>

<Title1>{web_hosting_page.name}</Title1>

<div class="flex justify-center items-center h-full flex-col gap-y-2">
  <Title1 class="text-xl text-xlgames-4 text-center">{global_state.shared_page.pageTemporarilyEmpty}</Title1>
  <Title1 class="text-xl text-xlgames-4 text-center">{'｡ﾟ･ (>﹏<) ･ﾟ｡ '}</Title1>
</div>