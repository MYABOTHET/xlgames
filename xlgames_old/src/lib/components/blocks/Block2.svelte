<script>
  let {children, ...props} = $props();
</script>

<div {...props} class="{props.class} text-center px-8 text-nowrap py-3 hover:text-xlgames-3 hover:bg-xlgames-2 transition-colors">
  {@render children?.()}
</div>