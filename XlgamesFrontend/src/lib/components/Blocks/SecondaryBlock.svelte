<script>
  const {children, ...props} = $props();
</script>

<div {...props} class="{props.class} transition-[background-color] hover:bg-xlgames-secondary">
  {@render children?.()}
</div>