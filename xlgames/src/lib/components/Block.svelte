<script>
  let {children, ...props} = $props();
</script>

<div {...props} class="{props.class} bg-xlgames-1 rounded-3xl border-2 border-xlgames-3 flex flex-col overflow-hidden">
  {@render children?.()}
</div>