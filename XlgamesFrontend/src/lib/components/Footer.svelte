<script>
  import {getContext} from "svelte";
  import PrimaryLink from "$lib/components/links/PrimaryLink.svelte";
  import ProjectData from "$lib/components/ProjectData.svelte";
  import Vk from "$lib/components/svg/messengers/Vk.svelte";
  import Instagram from "$lib/components/svg/messengers/Instagram.svelte";
  import Telegram from "$lib/components/svg/messengers/Telegram.svelte";
  import Snapchat from "$lib/components/svg/messengers/Snapchat.svelte";
  import Whatsapp from "$lib/components/svg/messengers/Whatsapp.svelte";
  import Twitter from "$lib/components/svg/messengers/Twitter.svelte";
  import Discord from "$lib/components/svg/messengers/Discord.svelte";
  import Facebook from "$lib/components/svg/messengers/Facebook.svelte";
  import SecondaryIcon from "$lib/components/icons/SecondaryIcon.svelte";
  
  const {navigationLinks, projectData, ...props} = $props();
  const {name, logo, year} = projectData;
  
  let language = $derived(getContext("language")());
</script>

<footer {...props} class="{props.class} flex-center primary-px pb-8 pt-12 border-t border-t-secondary">
  <div class="max-w-screen-primary w-full flex-center flex flex-col gap-y-16 max-quaternary:primary-gap-y
max-quaternary:items-start">
    <div class="flex gap-x-14 w-full max-quaternary:flex-col max-quaternary:primary-gap-y">
      <nav class="flex flex-col gap-y-5">
        <a href="/" class="w-fit">
          <ProjectData {name} {logo}/>
        </a>
        <nav class="grid grid-cols-4 gap-2.5 w-fit">
          <a href="/">
            <SecondaryIcon Icon={Vk} class="primary-size fill-quaternary"></SecondaryIcon>
          </a>
          <a href="/">
            <SecondaryIcon Icon={Instagram} class="primary-size fill-quaternary"></SecondaryIcon>
          </a>
          <a href="/">
            <SecondaryIcon Icon={Telegram} class="primary-size fill-quaternary"></SecondaryIcon>
          </a>
          <a href="/">
            <SecondaryIcon Icon={Snapchat} class="primary-size fill-quaternary"></SecondaryIcon>
          </a>
          <a href="/">
            <SecondaryIcon Icon={Whatsapp} class="primary-size fill-quaternary"></SecondaryIcon>
          </a>
          <a href="/">
            <SecondaryIcon Icon={Twitter} class="primary-size fill-quaternary"></SecondaryIcon>
          </a>
          <a href="/">
            <SecondaryIcon Icon={Discord} class="primary-size fill-quaternary"></SecondaryIcon>
          </a>
          <a href="/">
            <SecondaryIcon Icon={Facebook} class="primary-size fill-quaternary"></SecondaryIcon>
          </a>
        </nav>
      </nav>
      <nav class="grid w-full h-fit gap-3 grid-cols-4 max-secondary:grid-cols-3 max-ternary:grid-cols-2
max-quaternary:grid-cols-1 max-quaternary:gap-y-4">
        {#each [...navigationLinks.header.menu.links, ...navigationLinks.header.other,
          ...navigationLinks.other, ...navigationLinks.menu] as link}
          <PrimaryLink style="width: fit-content; text-align: left"
                       href={link.href}>{language.Shared[link.name]}</PrimaryLink>
        {/each}
      </nav>
    </div>
    <nav class="flex-center gap-x-6 font-normal text-xs text-quaternary max-quaternary:flex-col
max-quaternary:items-start max-quaternary:gap-y-3">
      <h1>© {year} {name}</h1>
      {#each navigationLinks.footer as link}
        <PrimaryLink href={link.href}>{language.Shared[link.name]}</PrimaryLink>
      {/each}
    </nav>
  </div>
</footer>