<script>
  import PrimaryScreen from "$lib/components/Screens/PrimaryScreen.svelte";
  import {getContext} from "svelte";
  import ProjectTitle from "$lib/components/Project/ProjectTitle.svelte";
  import Vk from "$lib/components/Images/Svg/Vk.svelte";
  import SecondaryIcon from "$lib/components/Images/SecondaryIcon.svelte";
  import Instagram from "$lib/components/Images/Svg/Instagram.svelte";
  import Telegram from "$lib/components/Images/Svg/Telegram.svelte";
  import Snapchat from "$lib/components/Images/Svg/Snapchat.svelte";
  import Whatsapp from "$lib/components/Images/Svg/Whatsapp.svelte";
  import Twitter from "$lib/components/Images/Svg/Twitter.svelte";
  import Discord from "$lib/components/Images/Svg/Discord.svelte";
  import Facebook from "$lib/components/Images/Svg/Facebook.svelte";
  import PrimaryLink from "$lib/components/Links/PrimaryLink.svelte";
  
  const {links, project, ...props} = $props();
  
  const language = $derived(getContext('language')());
</script>

<footer {...props} class="{props.class} border-t border-t-xlgames-secondary primary-x-padding pb-8 pt-12 flex-center
text-nowrap">
  <PrimaryScreen>
    <div class="flex flex-col xlgames-quaternary:gap-y-16 primary-gap-y">
      <div class="flex flex-col gap-x-0 xlgames-quaternary:gap-x-14 primary-gap-y xlgames-quaternary:gap-y-0
       xlgames-quaternary:flex-row">
        <div class="flex flex-col gap-y-5">
          <a href="/" class="w-fit block">
            <ProjectTitle logo={project.logo} name={project.name}/>
          </a>
          <div class="grid grid-cols-4 w-fit gap-2.5">
            <a href="/">
              <SecondaryIcon Icon={Vk} class="size-8 fill-xlgames-quaternary"></SecondaryIcon>
            </a>
            <a href="/">
              <SecondaryIcon Icon={Instagram} class="size-8 fill-xlgames-quaternary"></SecondaryIcon>
            </a>
            <a href="/">
              <SecondaryIcon Icon={Telegram} class="size-8 fill-xlgames-quaternary"></SecondaryIcon>
            </a>
            <a href="/">
              <SecondaryIcon Icon={Snapchat} class="size-8 fill-xlgames-quaternary"></SecondaryIcon>
            </a>
            <a href="/">
              <SecondaryIcon Icon={Whatsapp} class="size-8 fill-xlgames-quaternary"></SecondaryIcon>
            </a>
            <a href="/">
              <SecondaryIcon Icon={Twitter} class="size-8 fill-xlgames-quaternary"></SecondaryIcon>
            </a>
            <a href="/">
              <SecondaryIcon Icon={Discord} class="size-8 fill-xlgames-quaternary"></SecondaryIcon>
            </a>
            <a href="/">
              <SecondaryIcon Icon={Facebook} class="size-8 fill-xlgames-quaternary"></SecondaryIcon>
            </a>
          </div>
        </div>
        <div class="grid grid-cols-1 xlgames-quaternary:grid-cols-2 xlgames-ternary:grid-cols-3 xlgames-secondary:grid-cols-4 w-full h-fit gap-y-5 gap-x-0 xlgames-quaternary:gap-x-2 xlgames-quaternary:gap-y-3">
          {#each [...links.header.other, ...links.header.dedicatedServers.links,
            ...links.other, ...links.profile] as link}
            <PrimaryLink class="w-fit block" href={link.href}>{language["Shared"][link.name]}</PrimaryLink>
          {/each}
        </div>
      </div>
      <div class="xlgames-quaternary:flex-center xlgames-quaternary:gap-x-5 xlgames-quaternary:gap-y-0
      xlgames-quaternary:flex-row text-xlgames-quaternary text-xs gap-y-3 flex flex-col font-normal">
        <h1>© {project.year} {project.name}</h1>
        {#each links.footer as link}
          <PrimaryLink class="w-fit block" href={link.href}>{language["Shared"][link.name]}</PrimaryLink>
        {/each}
      </div>
    </div>
  </PrimaryScreen>
</footer>