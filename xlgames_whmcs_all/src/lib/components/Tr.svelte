<script>
  let {children, ...props} = $props();
</script>

<tr {...props}>
  {@render children?.()}
</tr>

<style lang="postcss">
  :global(thead tr) {
    @apply bg-slate-100;
  }
  
  :global(tbody tr) {
    @apply even:bg-slate-100 !border-t !border-t-slate-300;
  }
</style>