<script>
  let {href, children, ...props} = $props();
</script>

<a {...props} class="{props.class} hover:text-xlgames-3" href={href}>
  {@render children?.()}
</a>