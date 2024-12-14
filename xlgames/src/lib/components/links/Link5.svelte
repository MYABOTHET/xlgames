<script>
  let {children, ...props} = $props();
</script>

<a {...props} class="{props.class} fill-xlgames-4 stroke-xlgames-4 transition-colors flex justify-center
 items-center hover:fill-xlgames-3 hover:stroke-xlgames-3">
  {@render children?.()}
</a>