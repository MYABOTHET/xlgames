<script>
  const {children, isActive, ...props} = $props();
</script>

<div class="{isActive ? 'text-xlgames-ternary' : 'hover:text-xlgames-ternary'} transition-[color]" {...props}>{@render children?.()}</div>