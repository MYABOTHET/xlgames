<script>
  import '../app.css';
  import ProjectLogo from "$lib/components/icons/components/ProjectLogo.svelte";
  import Profile from "$lib/components/icons/svg/Profile.svelte";
  import Language from "$lib/components/icons/svg/Language.svelte";
  import Header from "$lib/components/Header.svelte";
  import Block from "$lib/components/Block.svelte";
  import DropDownMenu from "$lib/components/DropDownMenu.svelte";
  import Link from "$lib/components/Link.svelte";
  import Span from "$lib/components/Span.svelte";
  
  let {children, data} = $props();
  let {navigation_links} = data;
</script>

<svelte:head>
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link href="https://fonts.googleapis.com/css2?family=Inter:opsz,wght@14..32,100..900&display=swap" rel="stylesheet">
</svelte:head>

<Span hui="red">qwdwdqwd</Span>

<!--{#snippet start()}-->
<!--  <a href="/"><ProjectLogo mini_title="XL" title="XLGAMES.PRO"/></a>-->
<!--{/snippet}-->

<!--{#snippet center()}-->
<!--  <nav class="flex gap-x-8 justify-center items-center">-->
<!--    {#each navigation_links as navigation_link}-->
<!--      <Link href={navigation_link.href}>{navigation_link.title}</Link>-->
<!--    {/each}-->
<!--  </nav>-->
<!--{/snippet}-->

<!--{#snippet end()}-->
<!--  <div class="flex gap-x-5 justify-center items-center">-->
<!--    <DropDownMenu>-->
<!--      {#snippet button(menu_visible)}-->
<!--        <Language class="stroke-white h-[22px] transition-all hover:stroke-xlgames-3-->
<!--{menu_visible ? 'stroke-xlgames-3' : ''}"/>-->
<!--      {/snippet}-->
<!--      -->
<!--      {#snippet menu(data)}-->
<!--        <Block class="{data} top-full right-0 my-2">-->
<!--          <button class="transition-all hover:text-xlgames-3 py-3 hover:bg-xlgames-2 px-6">Русский</button>-->
<!--          <button class="transition-all hover:text-xlgames-3 py-3 hover:bg-xlgames-2 px-6">Englisssssssh</button>-->
<!--        </Block>-->
<!--      {/snippet}-->
<!--    </DropDownMenu>-->
<!--    <DropDownMenu>-->
<!--      {#snippet button(menu_visible)}-->
<!--        <Profile class="stroke-white h-[22px] transition-all hover:stroke-xlgames-3-->
<!--{menu_visible ? 'stroke-xlgames-3' : ''}"/>-->
<!--      {/snippet}-->
<!--      -->
<!--      {#snippet menu(data)}-->
<!--        <Block class="{data} top-full right-0 my-2">Links</Block>-->
<!--      {/snippet}-->
<!--    </DropDownMenu>-->
<!--  </div>-->
<!--{/snippet}-->

<!--<Header {start} {center} {end}/>-->

<main>
  {@render children()}
</main>