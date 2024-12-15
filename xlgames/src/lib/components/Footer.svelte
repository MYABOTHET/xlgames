<script>
  import ProjectLogo from "$lib/components/icons/components/ProjectLogo.svelte";
  import Link1 from "$lib/components/links/Link1.svelte";
  import Link5 from "$lib/components/links/Link5.svelte";
  import VK from "$lib/components/icons/svg/VK.svelte";
  
  let {navigation_links, project_titles, ...props} = $props();
</script>

<footer {...props}
        class="{props.class} mt-auto flex justify-center w-full items-center border-t border-t-xlgames-2">
  <div class="max-w-screen-xlgames-1 gap-y-12 px-4 w-full h-full flex flex-col justify-between items-center pt-12 pb-8
min-h-64">
    <div class="w-full flex gap-x-16 gap-y-8 items-start max-xlgames-2:flex-col">
      <div class="flex flex-col items-start gap-y-4 flex-1">
        <a href="/">
          <ProjectLogo mini_title={project_titles.logo} title={project_titles.title}/>
        </a>
        <div class="flex flex-wrap gap-2">
          {#each new Array(1) as _}
            <Link5 href="/">
              <VK class="size-8"/>
            </Link5>
          {/each}
        </div>
      </div>
      <nav class="grid grid-cols-3 gap-x-4 gap-y-2.5 w-full max-xlgames-2:grid-cols-1">
        {#each [...navigation_links.header.other, ...navigation_links.header.menu.links,
          ...navigation_links.profile, ...navigation_links.other]
            as navigation_link}
          <Link1 href={navigation_link.href} class="w-fit">{navigation_link.title}</Link1>
        {/each}
      </nav>
    </div>
    <div class="flex-wrap w-full justify-center flex gap-x-4 gap-y-2 text-xlgames-4 text-xs max-xlgames-2:flex-col">
      <h1>© {project_titles.year} {project_titles.title}</h1>
      {#each navigation_links.footer as navigation_link}
        <a href={navigation_link.href} class="hover:text-xlgames-3 transition-colors">{navigation_link.title}</a>
      {/each}
    </div>
  </div>
</footer>