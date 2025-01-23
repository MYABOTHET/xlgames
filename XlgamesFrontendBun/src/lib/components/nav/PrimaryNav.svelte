<script>
  import TernaryLink from "$lib/components/links/TernaryLink.svelte";
  
  const {links, ...props} = $props();
</script>

<nav {...props} class="{props.class} w-fit h-full flex flex-col bg-secondary border-r border-r-hexadecimal text-center
max-w-52">
  {#each links as link}
    <TernaryLink href={link.href}>{link.title}</TernaryLink>
  {/each}
</nav>