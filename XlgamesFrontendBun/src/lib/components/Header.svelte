<script>
  import {getContext} from "svelte";
  import {fade, fly} from 'svelte/transition';
  import ProjectData from "$lib/components/ProjectData.svelte";
  import PrimaryLink from "$lib/components/links/PrimaryLink.svelte";
  import PrimaryDropdownMenu from "$lib/components/dropdown-menus/PrimaryDropdownMenu.svelte";
  import PrimarySpan from "$lib/components/spans/PrimarySpan.svelte";
  import PrimaryBlock from "$lib/components/blocks/PrimaryBlock.svelte";
  import PrimaryIcon from "$lib/components/icons/PrimaryIcon.svelte";
  import PrimaryLanguage from "$lib/components/svg/PrimaryLanguage.svelte";
  import PrimaryProfile from "$lib/components/svg/PrimaryProfile.svelte";
  import PrimaryMenu from "$lib/components/svg/PrimaryMenu.svelte";
  import SecondaryIcon from "$lib/components/icons/SecondaryIcon.svelte";
  import {quartInOut} from "svelte/easing";
  import {afterNavigate} from "$app/navigation";
  
  const {headerHeight, navigationLinks, projectData, languages, userOnMobile, setLanguage, ...props} = $props();
  const {Name, Logo} = projectData;
  
  let language = $derived(getContext("language")());
  let menuIsVisible = $state(false);
  
  const duration = 75;
  
  function openMenu() {
    menuIsVisible = true;
    document.body.classList.add("fixed");
  }
  
  function closeMenu() {
    menuIsVisible = false;
    document.body.classList.remove("fixed");
  }
  
  function toggle() {
    !menuIsVisible ? openMenu() : closeMenu();
  }
  
  function menu(node) {
    $effect(() => {
      return () => {
        closeMenu();
      };
    });
  }
  
  afterNavigate(() => {
    closeMenu();
  });
</script>

{#snippet linkBlock(link)}
<PrimaryLink class="primary-bg primary-p transition-colors" href={link.href}>
  {language.Shared[link.name]}
</PrimaryLink>
{/snippet}

{#snippet project()}
<nav class="flex-1 flex items-center">
  <a class="inline-block" href="/">
    <ProjectData logo={Logo} name={Name}/>
  </a>
</nav>
{/snippet}

{#snippet navigation()}
<nav class="flex-center gap-x-8">
  {#each navigationLinks.header.other as link}
    <PrimaryLink style="order: {link.position}" href={link.href}>{language.Shared[link.name]}</PrimaryLink>
  {/each}
  <PrimaryDropdownMenu class="flex justify-center" style="order: {navigationLinks.header.menu.position}">
    {#snippet button(isMenuVisible)}
    <PrimarySpan isActive={isMenuVisible}>{language.Shared[navigationLinks.header.menu.name]}</PrimarySpan>
    {/snippet}
    <div class="absolute primary-top z-20" transition:fade={{duration}}>
      <PrimaryBlock position="primary-triangle-center">
        {#each navigationLinks.header.menu.links as link}
          {@render linkBlock?.(link)}
        {/each}
      </PrimaryBlock>
    </div>
  </PrimaryDropdownMenu>
</nav>
{/snippet}

{#snippet menus()}
<div class="flex-1 flex justify-end items-center">
  <div class="flex-center gap-x-6">
    <PrimaryDropdownMenu class="flex justify-end">
      {#snippet button(isMenuVisible)}
      <PrimaryIcon Icon={PrimaryLanguage} class="secondary-height stroke-white" isActive={isMenuVisible}/>
      {/snippet}
      <div class="absolute primary-top -mr-2 z-20" transition:fade={{duration}}>
        <PrimaryBlock position="primary-triangle-end">
          {#each languages as languageitem}
            <button onclick={() => {setLanguage(languageitem)}}>
              <PrimarySpan isActive={languageitem.Locale === language.Locale} class="primary-bg primary-p
              transition-colors">{languageitem.OriginalName}</PrimarySpan>
            </button>
          {/each}
        </PrimaryBlock>
      </div>
    </PrimaryDropdownMenu>
    {#if !userOnMobile}
      <PrimaryDropdownMenu class="flex justify-end">
        {#snippet button(isMenuVisible)}
        <PrimaryIcon Icon={PrimaryProfile} isActive={isMenuVisible} class="secondary-height stroke-white"/>
        {/snippet}
        <div transition:fade={{duration}} class="absolute primary-top -mr-3 z-20">
          <PrimaryBlock position="primary-triangle-end">
            {#each navigationLinks.menu as link}
              <PrimaryLink href={link.href} class="primary-bg primary-p" rel="nofollow">
                {language.Shared[link.name]}
              </PrimaryLink>
            {/each}
          </PrimaryBlock>
        </div>
      </PrimaryDropdownMenu>
    {:else}
      <div class="flex" use:menu>
        <button onclick={toggle}>
          <SecondaryIcon Icon={PrimaryMenu} isActive={menuIsVisible} class="ternary-height fill-white"/>
        </button>
        {#if menuIsVisible}
          <div transition:fly={{x: "-100vw", duration: 175, delay: 0, opacity: 1, easing: quartInOut}}
               style="min-height: calc(100dvh - {headerHeight}rem);
             max-height: calc(100dvh - {headerHeight}rem); margin-top: {headerHeight}rem;"
               class="absolute top-0 left-0 overflow-y-auto w-full bg-(--color-primary) primary-px py-6 scroll z-10">
            <nav class="flex flex-col w-full gap-y-6">
              {#each [...navigationLinks.header.menu.links, ...navigationLinks.header.other,
                ...navigationLinks.other] as link}
                <PrimaryLink style="width: fit-content" href={link.href}>{language.Shared[link.name]}</PrimaryLink>
              {/each}
              {#each navigationLinks.menu as link}
                <PrimaryLink style="width: fit-content" href={link.href}
                             rel="nofollow">{language.Shared[link.name]}</PrimaryLink>
              {/each}
              {#each navigationLinks.footer as link}
                <PrimaryLink style="width: fit-content" href={link.href}>{language.Shared[link.name]}</PrimaryLink>
              {/each}
            </nav>
          </div>
        {/if}
      </div>
    {/if}
  </div>
</div>
{/snippet}

<header {...props} class="{props.class}
flex-center border-b border-b-(--color-secondary) primary-px {menuIsVisible ? 'bg-(--color-primary)' : 'bg-(--color-secondary)'}
{userOnMobile ? 'transition-[background-color]' : ''}" style="min-height: {headerHeight}rem; max-height: {headerHeight}rem;">
  <div class="flex-center max-w-(--breakpoint-primary) w-full">
    {@render project?.()}
    {#if !userOnMobile}{@render navigation?.()}{/if}
    {@render menus?.()}
  </div>
</header>

<style>
  @reference "tailwindcss/theme";
  
  .scroll {
    scrollbar-width: none;
  }
  
  .scroll::-webkit-scrollbar {
    @apply w-0;
  }
</style>