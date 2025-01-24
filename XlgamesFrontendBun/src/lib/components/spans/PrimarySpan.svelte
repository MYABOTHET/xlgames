<script>
  const {children, isActive, ...props} = $props();
</script>

<div {...props} class="{props.class} {isActive ? 'text-(--color-ternary)!' : 'hover:text-(--color-ternary)'} transition-[color]">
  {@render children?.()}
</div>