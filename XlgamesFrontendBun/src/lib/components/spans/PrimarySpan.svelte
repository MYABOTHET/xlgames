<script>
  const {children, isActive, ...props} = $props();
</script>

<div {...props} class="{props.class} {isActive ? '!text-ternary' : 'hover:text-ternary'} transition-[color]">
  {@render children?.()}
</div>