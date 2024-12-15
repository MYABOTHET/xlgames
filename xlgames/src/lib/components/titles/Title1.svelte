<script>
  let {children, ...props} = $props();
</script>

<h1 {...props} class="{props.class} text-[28px] leading-8 font-semibold">{@render children?.()}</h1>