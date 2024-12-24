<script>
  let {children, ...props} = $props();
</script>

<h1 {...props} class="{props.class} text-red-500">{@render children?.()}</h1>