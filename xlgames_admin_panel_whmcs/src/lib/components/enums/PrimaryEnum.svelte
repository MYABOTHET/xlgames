<script>
  let {children, ...props} = $props();
</script>

<div {...props} class="{props.class} flex items-center gap-x-6">
  {@render children?.()}
</div>