<script>
  import TernaryLink from "$lib/components/links/TernaryLink.svelte";
  import SecondaryNav from "$lib/components/nav/SecondaryNav.svelte";
  
  const {links, ...props} = $props();
</script>

<SecondaryNav {...props}>
  {#each links as link (link.title)}
    <TernaryLink href={link.href}>{link.title}</TernaryLink>
  {/each}
</SecondaryNav>