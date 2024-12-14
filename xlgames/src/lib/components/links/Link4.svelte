<script>
  let {children, ...props} = $props();
</script>

<a {...props} class="{props.class} bg-xlgames-3 rounded-full transition-colors border-2 border-xlgames-3
hover:bg-transparent flex justify-center items-center text-xlgames-1 hover:text-white py-2 px-6">
  {@render children?.()}
</a>