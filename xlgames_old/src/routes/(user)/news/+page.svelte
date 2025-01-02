<script>
  import {store} from "$lib/state.svelte.js";
  import Title1 from "$lib/components/titles/Title1.svelte";
  import {onMount} from "svelte";
  import Card2 from "$lib/components/cards/Card2.svelte";
  
  const {data} = $props();
  
  let news_page = $state(data.news_page);
  let news = $state(data.news);
  let init = $state(false);
  onMount(async () => {
    let unsubscribe = store.subscribe(async () => {
      if (!init) {
        init = true;
        return 0;
      }
      news = await (await fetch('/news?method=news&require=false')).json();
    });
    return () => {
      unsubscribe();
    }
  })
</script>

<svelte:head>
  <title>{news_page.title}</title>
</svelte:head>

<Title1>{news_page.name}</Title1>

<div class="min-h-12"></div>

<div class="grid grid-cols-1 xlgames-2:grid-cols-2 gap-6">
  {#each news as news_item}
    <Card2 class="min-w-[240px]" href="/news/{news_item.parentId}" title={news_item.name} data={news_item.date}
           img_src={news_item.src}/>
  {/each}
</div>