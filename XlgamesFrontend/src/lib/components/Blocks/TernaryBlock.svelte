<script>
  const {children, ...props} = $props();
</script>

<div {...props} class="{props.class} rounded-full border-2 border-xlgames-ternary bg-xlgames-ternary
hover:bg-transparent overflow-hidden transition-colors">
  {@render children?.()}
</div>