<script>
  const {children, ...props} = $props();
</script>

<div {...props} class="{props.class} max-w-screen-xlgames-quinary w-full">
  {@render children?.()}
</div>