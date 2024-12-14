<script>
  let {active, children, ...props} = $props();
  let style = $derived(active ? "stroke-xlgames-3 fill-xlgames-3" : "fill-white stroke-white hover:stroke-xlgames-3 hover:fill-xlgames-3");
</script>

<div {...props} class="{props.class} transition-colors {style}">
  {@render children?.()}
</div>