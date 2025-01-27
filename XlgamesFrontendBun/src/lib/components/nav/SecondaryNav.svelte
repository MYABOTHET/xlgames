<script>
  let {children, ...props} = $props();
</script>

<nav {...props} class="{props.class} w-fit h-full flex flex-col bg-(--color-secondary) border-r
border-r-(--color-hexadecimal) text-center overflow-y-auto min-w-fit overflow-x-hidden">
  {@render children?.()}
</nav>

<style>
  @reference "tailwindcss/theme";
  
  nav::-webkit-scrollbar {
    @apply w-0;
  }
</style>