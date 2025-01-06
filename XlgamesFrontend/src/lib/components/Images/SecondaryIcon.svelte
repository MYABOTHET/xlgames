<script>
  const {Icon, isActive, ...props} = $props();
</script>

<Icon {...props} class="{props.class} {isActive ? 'fill-xlgames-ternary' : 'hover:fill-xlgames-ternary'}
transition-[fill]"></Icon>