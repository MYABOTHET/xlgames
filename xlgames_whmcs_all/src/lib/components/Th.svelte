<script>
  let {children, ...props} = $props();
</script>

<th {...props}>
  {@render children?.()}
</th>

<style lang="postcss">
  :global(th) {
    @apply pr-6 first:pl-6 font-normal text-center;
  }
  
  :global(th span) {
    @apply block py-5 text-nowrap;
  }
</style>