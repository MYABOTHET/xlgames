<script>
  const {Icon, isActive, ...props} = $props();
</script>

<Icon {...props} class="{props.class} {isActive ? 'fill-(--color-ternary)!' : 'hover:fill-(--color-ternary)'} transition-[fill]"/>