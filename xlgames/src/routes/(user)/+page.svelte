<script>
  import Section1 from "$lib/components/sections/Section1.svelte";
  import Card1 from "$lib/components/cards/Card1.svelte";
  import Block4 from "$lib/components/blocks/Block4.svelte";
  import Link4 from "$lib/components/links/Link4.svelte";
  import Block5 from "$lib/components/blocks/Block5.svelte";
  import Card2 from "$lib/components/cards/Card2.svelte";
  import Title1 from "$lib/components/titles/Title1.svelte";
  import {global_state, store} from "$lib/state.svelte.js";
  import {onMount} from "svelte";
  
  let {data} = $props();
  
  let main_page = $state(data.main_page);
  let data_center_points = $derived.by(() => {
    let sort_array = main_page.dataCenterPoints.slice();
    sort_array.sort((f, t) => {
      if (f.title > t.title) return 1;
      if (f.title == t.title) return 0;
      if (f.title < t.title) return -1;
    });
    return sort_array;
  });
  let server_block = $derived(main_page.posts.find(post => post.name === "ServerBlock"));
  let server_ai_block = $derived(main_page.posts.find(post => post.name === "ServerAIBlock"));
  let vps_block = $derived(main_page.posts.find(post => post.name === "VPSBlock"));
  let vpn_block = $derived(main_page.posts.find(post => post.name === "VPNBlock"));
  let web_hosting_block = $derived(main_page.posts.find(post => post.name === "WebHostingBlock"));
  let init = $state(false);
  
  onMount(async () => {
    let unsubscribe = store.subscribe(async () => {
      if (!init) {
        init = true;
        return 0;
      }
      main_page = await (await fetch('/?page_id=1')).json();
    });
    return () => {
      unsubscribe();
    }
  })

</script>

<Section1 href="/game-servers" more={global_state.shared_page.more}
          title={main_page.gameServers}>
  <div class="flex flex-nowrap gap-x-7 justify-between overflow-x-scroll custom-scroll2 pb-1">
    <Card1 href="/"></Card1>
    <Card1 href="/"></Card1>
    <Card1 href="/"></Card1>
    <Card1 href="/"></Card1>
  </div>
</Section1>

<div class="min-h-28"></div>

<div class="flex flex-wrap gap-8">
  <Block4 class="flex-[1_1_100%] md:flex-[1_1_35%] xlgames-1:flex-[1_1_25%]" description={server_block.description}
          title={server_block.title}/>
  <Block4 class="flex-[1_1_100%] md:flex-[1_1_35%] xlgames-1:flex-[1_1_25%]" description={vps_block.description}
          title={vps_block.title}/>
  <Block4 class="flex-[1_1_100%] md:flex-[1_1_35%] xlgames-1:flex-[1_1_25%]" description={web_hosting_block.description}
          title={web_hosting_block.title}/>
  <Block4 class="flex-[1_1_100%] md:flex-[1_1_35%] xlgames-1:flex-[1_1_25%]" description={vpn_block.description}
          title={vpn_block.title}/>
  <Block4 class="flex-[1_1_100%] md:flex-[1_1_35%] xlgames-1:flex-[1_1_25%]" description={server_ai_block.description}
          title={server_ai_block.title}/>
</div>

<div class="min-h-28"></div>

<div class="flex gap-x-8 gap-y-12 flex-col min-[1000px]:flex-row">
  <div class="flex-[1_1_25%] flex flex-col gap-y-8">
    <Title1>{main_page.dataCenters}</Title1>
    <p>{main_page.dataCentersDescription}</p>
    <Link4 class="w-fit" href="/">{global_state.shared_page.readMore}</Link4>
  </div>
  <div class="border-2 border-xlgames-4 rounded-2xl px-8 py-4 flex flex-col gap-y-4 flex-[1_1_25%]">
    {#each data_center_points as point, index}
      <Block5 title={point.title} description={point.description}
              border={index !== data_center_points.length - 1}/>
    {/each}
  </div>
</div>

<div class="min-h-28"></div>

<Section1 href="/news" more={global_state.shared_page.more} title={main_page.news}>
  <div class="flex flex-nowrap gap-x-7 justify-between overflow-x-scroll custom-scroll2 pb-1">
    <Card2 href="/"></Card2>
    <Card2 href="/"></Card2>
    <Card2 href="/"></Card2>
  </div>
</Section1>