<script>
  const {children, title, ...props} = $props();
</script>

<div {...props} class="{props.class} flex-auto flex overflow-x-hidden" style="color-scheme: dark">
  {@render children?.()}
</div>