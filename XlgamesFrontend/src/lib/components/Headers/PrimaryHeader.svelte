<script>
  import {getContext} from "svelte";
  import {fade, fly} from 'svelte/transition';
  import PrimaryScreen from "$lib/components/Screens/PrimaryScreen.svelte";
  import PrimaryLink from "$lib/components/Links/PrimaryLink.svelte";
  import PrimaryDropdownMenu from "$lib/components/DropdownMenus/PrimaryDropdownMenu.svelte";
  import PrimaryBlock from "$lib/components/Blocks/PrimaryBlock.svelte";
  import PrimarySpan from "$lib/components/Spans/PrimarySpan.svelte";
  import SecondaryBlock from "$lib/components/Blocks/SecondaryBlock.svelte";
  import ProjectTitle from "$lib/components/Project/ProjectTitle.svelte";
  import PrimaryProfile from "$lib/components/Images/Svg/PrimaryProfile.svelte";
  import PrimaryLanguage from "$lib/components/Images/Svg/PrimaryLanguage.svelte";
  import PrimaryIcon from "$lib/components/Images/PrimaryIcon.svelte";
  import PrimaryTriangle from "$lib/components/Images/Svg/PrimaryTriangle.svelte";
  import PrimaryMenu from "$lib/components/Images/Svg/PrimaryMenu.svelte";
  import SecondaryIcon from "$lib/components/Images/SecondaryIcon.svelte";
  
  const {links, project, languages, setLanguage, isMobile, height, ...props} = $props();
  
  const language = $derived(getContext('language')());
  let isVisible = $state(false);
  
  function openMenu() {
    isVisible = true;
    document.body.classList.add("fixed");
  }
  
  function closeMenu() {
    isVisible = false;
    document.body.classList.remove("fixed");
  }

</script>

<header {...props} style="min-height: {height}"
        class="{props.class} {isVisible ? 'bg-xlgames-primary' : 'bg-xlgames-secondary'} relative
primary-x-padding flex-center text-nowrap text-center border-b border-b-xlgames-secondary
{isMobile ? 'transition-[background-color]' : ''}">
  <PrimaryScreen>
    <div class="flex">
      <div class="flex-1 flex items-center">
        <a href="/" class="w-fit block">
          <ProjectTitle logo={project.logo} name={project.name}/>
        </a>
      </div>
      {#if !isMobile}
        <div class="flex justify-center items-center">
          <nav class="flex items-center gap-x-8">
            {#each links.header.other as link}
              <PrimaryLink style="order: {link.order}" href={link.href}>{language["Shared"][link.name]}</PrimaryLink>
            {/each}
            <PrimaryDropdownMenu style="order: {links.header.dedicatedServers.order}"
                                 class="relative flex justify-center">
              {#snippet button(isMenuVisible)}
              <PrimarySpan
                  isActive={isMenuVisible}>{language["Shared"][links.header.dedicatedServers.name]}</PrimarySpan>
              {/snippet}
              <div transition:fade={{duration: 75}} class="absolute top-full mt-3 z-20">
                <div class="flex flex-col">
                  <PrimaryTriangle class="h-1 fill-xlgames-ternary relative top-[1px]"></PrimaryTriangle>
                  <PrimaryBlock preset="primary">
                    {#each links.header.dedicatedServers.links as link}
                      <PrimaryLink href={link.href}>
                        <SecondaryBlock class="primary-padding">{language["Shared"][link.name]}</SecondaryBlock>
                      </PrimaryLink>
                    {/each}
                  </PrimaryBlock>
                </div>
              </div>
            </PrimaryDropdownMenu>
          </nav>
        </div>
      {/if}
      <div class="flex-1 flex justify-end items-center">
        <div class="flex gap-x-6 items-center">
          <PrimaryDropdownMenu class="relative flex">
            {#snippet button(isMenuVisible)}
            <PrimaryIcon Icon={PrimaryLanguage} isActive={isMenuVisible} class="min-h-6 stroke-white"/>
            {/snippet}
            <div transition:fade={{duration: 75}} class="absolute top-full right-full -mr-8 mt-3 z-20">
              <div class="flex flex-col items-end">
                <PrimaryTriangle class="h-1 fill-xlgames-ternary relative top-[1px] mr-4"></PrimaryTriangle>
                <PrimaryBlock preset="primary">
                  {#each languages as languageItem}
                    <button onclick={() => {setLanguage(languageItem)}} class="block w-full">
                      <PrimarySpan isActive={languageItem["Locale"] === language["Locale"]}>
                        <SecondaryBlock class="primary-padding">
                          {languageItem["OriginalName"]}
                        </SecondaryBlock>
                      </PrimarySpan>
                    </button>
                  {/each}
                </PrimaryBlock>
              </div>
            </div>
          </PrimaryDropdownMenu>
          {#if !isMobile}
            <PrimaryDropdownMenu class="relative flex">
              {#snippet button(isMenuVisible)}
              <PrimaryIcon Icon={PrimaryProfile} isActive={isMenuVisible} class="min-h-[1.45rem] stroke-white"/>
              {/snippet}
              <div transition:fade={{duration: 75}} class="absolute top-full right-full -mr-7 mt-[0.79rem] z-20">
                <div class="flex flex-col items-end">
                  <PrimaryTriangle class="h-1 fill-xlgames-ternary relative top-[1px] mr-[15px]"></PrimaryTriangle>
                  <PrimaryBlock preset="primary">
                    {#each links.profile as link}
                      <PrimaryLink href={link.href}>
                        <SecondaryBlock class="primary-padding">{language["Shared"][link.name]}</SecondaryBlock>
                      </PrimaryLink>
                    {/each}
                  </PrimaryBlock>
                </div>
              </div>
            </PrimaryDropdownMenu>
          {:else}
            <PrimaryDropdownMenu class="flex" open={openMenu} close={closeMenu}>
              {#snippet button(isMenuVisible)}
              <SecondaryIcon Icon={PrimaryMenu} isActive={isMenuVisible} class="min-h-5 fill-white"/>
              {/snippet}
              <div transition:fly={{x: "-100vw", duration: 175, delay: 0, opacity: 1}}
                   class="absolute top-0 left-0 primary-scroll z-10
              h-dvh w-full overflow-y-auto" style="height: calc(100dvh - {height}); margin-top: {height};">
                <nav class="primary-x-padding py-6 flex flex-col gap-y-6 bg-xlgames-primary w-full">
                  {#each [...links.header.dedicatedServers.links, ...links.header.other,
                    ...links.profile, ...links.other, ...links.footer] as link}
                    <PrimaryLink class="w-fit" href={link.href}>{language["Shared"][link.name]}</PrimaryLink>
                  {/each}
                </nav>
              </div>
            </PrimaryDropdownMenu>
          {/if}
        </div>
      </div>
    </div>
  </PrimaryScreen>
</header>