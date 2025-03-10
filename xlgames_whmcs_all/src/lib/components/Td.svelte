<script>
  let {children, ...props} = $props();
</script>

<td {...props}>
  {@render children?.()}
</td>

<style lang="postcss">
  :global(td) {
    @apply pr-6 first:pl-6 font-normal text-center;
  }
  
  :global(td span) {
    @apply block py-5;
  }
</style>