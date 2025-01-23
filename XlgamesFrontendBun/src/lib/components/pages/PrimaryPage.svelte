<script>
  const {children, title, ...props} = $props();
</script>

<div {...props} class="{props.class} overflow-y-auto flex-auto" style="color-scheme: dark">
  {@render children?.()}
</div>