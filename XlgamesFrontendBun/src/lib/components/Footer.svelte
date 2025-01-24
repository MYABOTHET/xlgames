<script>
  import {getContext} from "svelte";
  import PrimaryLink from "$lib/components/links/PrimaryLink.svelte";
  import ProjectData from "$lib/components/ProjectData.svelte";
  import TernarySection from "$lib/components/sections/TernarySection.svelte";
  
  const {navigationLinks, projectData, ...props} = $props();
  const {Name, Logo, Year} = projectData;
  
  let language = $derived(getContext("language")());
</script>

<footer {...props} class="{props.class} flex-center primary-px pb-8 pt-12 border-t border-t-(--color-secondary)">
  <div class="max-w-(--breakpoint-primary) w-full flex-center flex flex-col gap-y-16 max-quaternary:primary-gap-y
max-quaternary:items-start">
    <div class="flex gap-x-14 w-full max-quaternary:flex-col max-quaternary:primary-gap-y">
      <nav class="flex flex-col gap-y-5 min-w-fit">
        <a href="/" class="w-fit">
          <ProjectData name={Name} logo={Logo}/>
        </a>
        <TernarySection {projectData} class="grid grid-cols-4 gap-2.5 w-fit"/>
      </nav>
      <nav class="grid w-full h-fit gap-3.5 grid-cols-4 max-secondary:grid-cols-3 max-ternary:grid-cols-2
max-quaternary:grid-cols-1 max-quaternary:gap-y-4">
        {#each [...navigationLinks.header.menu.links, ...navigationLinks.header.other,
          ...navigationLinks.other] as link}
          <PrimaryLink style="width: fit-content; text-align: left"
                       href={link.href}>{language.Shared[link.name]}</PrimaryLink>
        {/each}
        {#each navigationLinks.menu as link}
          <PrimaryLink style="width: fit-content; text-align: left" rel="nofollow"
                       href={link.href}>{language.Shared[link.name]}</PrimaryLink>
        {/each}
      </nav>
    </div>
    <nav class="flex gap-x-6 gap-y-3 font-normal text-xs text-(--color-quaternary) max-quaternary:flex-col
max-quaternary:items-start flex-wrap">
      <h1>© {Year} {new Date().getFullYear() > Year ? "- " + new Date().getFullYear() : ""} {Name}</h1>
      {#each navigationLinks.footer as link}
        <PrimaryLink href={link.href}>{language.Shared[link.name]}</PrimaryLink>
      {/each}
    </nav>
  </div>
</footer>