<script>
  import ProjectLogo from "$lib/components/icons/components/ProjectLogo.svelte";
  import Profile from "$lib/components/icons/svg/Profile.svelte";
  import Language from "$lib/components/icons/svg/Language.svelte";
  import Link1 from "$lib/components/links/Link1.svelte";
  import Icon1 from "$lib/components/icons/Icon1.svelte";
  import DropDownMenu1 from "$lib/components/drop-down-menus/DropDownMenu1.svelte";
  import Block1 from "$lib/components/blocks/Block1.svelte";
  import Block2 from "$lib/components/blocks/Block2.svelte";
  import {fade, fly} from 'svelte/transition';
  import Block3 from "$lib/components/blocks/Block3.svelte";
  import Menu from "$lib/components/icons/svg/Menu.svelte";
  import DropDownMenu2 from "$lib/components/drop-down-menus/DropDownMenu2.svelte";
  import {onMount} from "svelte";
  
  let {navigation_links, project_titles, languages, language, mobile, ...props} = $props();
  let header_color = $state(true);
  let doc = null;
  
  function toggle(menu_visible) {
    if (doc) {
      if (!menu_visible) {
        document.body.classList.remove("fixed");
      } else {
        document.body.classList.add("fixed");
      }
      header_color = !menu_visible;
    }
  }
  
  onMount(() => {
    doc = document;
  })
  
</script>

<header {...props} class="{props.class} {header_color ? 'bg-xlgames-2 border-b-transparent' :
'bg-xlgames-1 border-b-xlgames-2'} transition-colors border-b min-h-20 flex justify-center items-center z-30 w-full">
  <div class="flex w-full justify-center items-center max-w-screen-xlgames-1 px-4">
    <div class="flex-1 flex justify-start items-center">
      <a href="/">
        <ProjectLogo mini_title={project_titles.logo} title={project_titles.title}/>
      </a>
    </div>
    {#if !mobile}
      <nav class="flex justify-center items-center lg:gap-x-7 gap-x-4">
        {#each navigation_links.header.other as navigation_link}
          <Link1 href={navigation_link.href} style="order: {navigation_link.order}">{navigation_link.title}</Link1>
        {/each}
        <DropDownMenu1 class="relative" style="order: {navigation_links.header.menu.order}">
          {#snippet button(menu_visible)}
            <div class="{menu_visible ? 'text-xlgames-3' : 'hover:text-xlgames-3'}
             transition-colors">{language[navigation_links.header.menu.title]}</div>
          {/snippet}
          {#snippet menu()}
          <div transition:fade={{duration: 75}} class="absolute top-full mt-2">
            <Block1>
              {#each navigation_links.header.menu.links as navigation_link}
                <Link1 href={navigation_link.href}><Block3>{navigation_link.title}</Block3></Link1>
              {/each}
            </Block1>
          </div>
          {/snippet}
        </DropDownMenu1>
      </nav>
    {/if}
    <div class="flex-1 flex justify-end items-center">
      <div class="flex gap-x-6 justify-center items-center">
        <DropDownMenu1 class="relative">
          {#snippet button(menu_visible)}
            <Icon1 active={menu_visible}>
              <Language class="h-[22px]"/>
            </Icon1>
          {/snippet}
          {#snippet menu()}
          <div transition:fade={{duration: 75}} class="absolute top-full mt-2 -right-4">
            <Block1 position="right">
              {#each languages as language}
                <button><Block2>{language.title}</Block2></button>
              {/each}
            </Block1>
          </div>
          {/snippet}
        </DropDownMenu1>
        {#if !mobile}
          <DropDownMenu1 class="relative">
            {#snippet button(menu_visible)}
            <Icon1 active={menu_visible}>
              <Profile class="h-[22px]"/>
            </Icon1>
            {/snippet}
            {#snippet menu()}
            <div transition:fade={{duration: 75}} class="absolute top-full mt-2 -right-4">
              <Block1 position="right">
                {#each navigation_links.profile as navigation_link}
                  <Link1 href={navigation_link.href}><Block3>{navigation_link.title}</Block3></Link1>
                {/each}
              </Block1>
            </div>
            {/snippet}
          </DropDownMenu1>
        {:else}
          <DropDownMenu2 visible={toggle}>
            {#snippet button(menu_visible)}
              <Icon1 active={menu_visible}><Menu class="h-[22px]"/></Icon1>
            {/snippet}
            {#snippet menu(close_menu)}
            <div in:fly={{x: "-100vw", duration: 125, delay: 0, opacity: 1}}
                 out:fly={{x: "-100vw", duration: 125, delay: 75, opacity: 1}}
                 class="bg-xlgames-1 z-30 absolute top-0 left-0 mt-20 w-full overflow-y-auto
                  custom-scroll" style="height: calc(100vh - 80px);">
              <div class="flex flex-col gap-y-6 px-4 py-8 w-full">
                {#each [...navigation_links.header.other, ...navigation_links.header.menu.links,
                  ...navigation_links.profile, ...navigation_links.other, ...navigation_links.footer]
                    as navigation_link}
                  <Link1 onclick={close_menu} href={navigation_link.href} class="w-fit">{navigation_link.title}</Link1>
                {/each}
              </div>
            </div>
            {/snippet}
          </DropDownMenu2>
        {/if}
      </div>
    </div>
  </div>
</header>