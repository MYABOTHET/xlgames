<script>
  import Title1 from "$lib/components/titles/Title1.svelte";
  import Img1 from "$lib/components/img/Img1.svelte";
  import {onMount} from "svelte";
  import {locale_store, store} from "$lib/state.svelte.js";
  import {page} from "$app/stores";
  import Arrow from "$lib/components/icons/svg/Arrow.svelte";
  
  let {data} = $props();
  
  let news_item = $state(data.news_item);
  let init = $state(false);
  let formatter = $derived(new Intl.DateTimeFormat(locale_store.locale, {
    weekday: "long",
    year: "numeric",
    month: "long",
    day: "numeric"
  }));
  let date_formatted = $derived(formatter.format(new Date(news_item.date)));
  onMount(async () => {
    let unsubscribe = store.subscribe(async () => {
      if (!init) {
        init = true;
        return 0;
      }
      fetch(`/news/${$page.params.name}`).then(r => r.json().then(t => news_item = t));
    });
    return () => {
      unsubscribe();
    }
  })
</script>

<div class="hidden h-3.5"></div>

<svelte:head>
  <title>{news_item.name}</title>
</svelte:head>

<article class="max-w-screen-xlgames-3 w-full m-auto">
  <a class="flex flex-nowrap gap-x-6 items-center hover:text-xlgames-3 transition-colors
hover:fill-xlgames-3 fill-white" href="/news">
    <Arrow class="min-w-3 max-w-3 -rotate-90"></Arrow>
    <Title1>{news_item.name}</Title1>
  </a>
  
  <div class="min-h-12"></div>
  
  <Img1 class="w-full min-h-64 rounded-2xl overflow-hidden" src={news_item.src}/>
  
  <div class="min-h-2"></div>
  
  <p class="text-xs text-xlgames-4 leading-[22px] w-fit ml-auto">{date_formatted}</p>
  
  <div class="min-h-6"></div>
  
  <div class="text-sm leading-[22px] my-custom-block">{@html news_item.description}</div>
</article>

<style lang="postcss">
  .my-custom-block :global {
    h1, h2, h3, h4, h5, h6 {
      @apply font-semibold mt-4 text-xl;
    }
    
    strong {
      @apply font-semibold;
    }
    
    li {
      @apply list-disc;
    }
    
    a {
      @apply transition-colors text-xlgames-3 hover:text-slate-400;
    }
  }
</style>