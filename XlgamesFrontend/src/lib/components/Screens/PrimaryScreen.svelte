<script>
  const {children, ...props} = $props();
</script>

<div {...props} class="{props.class} max-w-screen-xlgames-primary w-full">
  {@render children?.()}
</div>