<script>
  const {children, ...props} = $props();
</script>

<h1 {...props} class="{props.class} font-medium text-3xl">{@render children?.()}</h1>