<script>
  let {children, ...props} = $props();
</script>

<div {...props} class="{props.class} text-center px-8 text-nowrap py-3
 hover:bg-xlgames-2 transition-[background-color]">
  {@render children?.()}
</div>