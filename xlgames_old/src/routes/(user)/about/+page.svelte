<script>
  import {store} from "$lib/state.svelte.js";
  import Title1 from "$lib/components/titles/Title1.svelte";
  import Img1 from "$lib/components/img/Img1.svelte";
  import {onMount} from "svelte";
  
  const {data} = $props();
  
  let about_page = $state(data.about_page);
  let init = $state(false);
  onMount(async () => {
    let unsubscribe = store.subscribe(async () => {
      if (!init) {
        init = true;
        return 0;
      }
      about_page = await (await fetch('/about')).json();
    });
    return () => {
      unsubscribe();
    }
  })
</script>

<svelte:head>
  <title>{about_page.title}</title>
</svelte:head>

<div class="max-w-screen-xlgames-3 w-full m-auto">
  <Title1>{about_page.name}</Title1>
  
  <div class="min-h-12"></div>
  
  <Img1 class="w-full min-h-64 rounded-2xl overflow-hidden" src="minecraft.png"/>
  
  <div class="min-h-8"></div>
  
  <p class="text-sm whitespace-pre-wrap leading-[22px]">{about_page.description}</p>
</div>
