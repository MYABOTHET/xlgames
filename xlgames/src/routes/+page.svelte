<script>
  import Section1 from "$lib/components/sections/Section1.svelte";
  import Card1 from "$lib/components/cards/Card1.svelte";
  import Block4 from "$lib/components/blocks/Block4.svelte";
  import Link4 from "$lib/components/links/Link4.svelte";
  import Block5 from "$lib/components/blocks/Block5.svelte";
  import Card2 from "$lib/components/cards/Card2.svelte";
</script>

<Section1>
  <div class="flex flex-nowrap gap-x-7 justify-between overflow-x-scroll custom-scroll2 pb-1">
    <Card1 href="/"></Card1>
    <Card1 href="/"></Card1>
    <Card1 href="/"></Card1>
    <Card1 href="/"></Card1>
  </div>
</Section1>

<div class="h-28"></div>

<div class="flex flex-wrap gap-8">
  {#each new Array(5) as _}
    <Block4 class="flex-[1_1_100%] md:flex-[1_1_35%] xlgames-1:flex-[1_1_25%]"/>
  {/each}
</div>

<div class="h-28"></div>

<div class="flex gap-x-8 gap-y-12 flex-col min-[1000px]:flex-row">
  <div class="flex-[1_1_25%] flex flex-col gap-y-8">
    <h1 class="text-[28px] leading-8 font-semibold">Дата центры</h1>
    <p>Мы размещаем оборудование в современных ЦОД по всему миру, уровня не менее Tier 3,
      что означает постоянную доступность ваших услуг, SLA 99,982%</p>
    <Link4 class="w-fit" href="/">Читать ещё</Link4>
  </div>
  <Block5 class="flex-[1_1_25%]"/>
</div>

<div class="h-28"></div>

<Section1>
  <div class="flex flex-nowrap gap-x-7 justify-between overflow-x-scroll custom-scroll2 pb-1">
    <Card2 href="/"></Card2>
    <Card2 href="/"></Card2>
    <Card2 href="/"></Card2>
  </div>
</Section1>