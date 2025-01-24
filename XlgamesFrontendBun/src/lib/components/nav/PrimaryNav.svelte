<script>
  import TernaryLink from "$lib/components/links/TernaryLink.svelte";
  
  const {links, ...props} = $props();
</script>

<nav {...props} class="{props.class} w-fit h-full flex flex-col bg-(--color-secondary) border-r border-r-(--color-hexadecimal) text-center
max-w-52 overflow-y-auto min-w-fit">
  {#each links as link}
    <TernaryLink href={link.href}>{link.title}</TernaryLink>
  {/each}
</nav>

<style>
  @reference "tailwindcss/theme";
  
  nav::-webkit-scrollbar {
    @apply w-0;
  }
</style>