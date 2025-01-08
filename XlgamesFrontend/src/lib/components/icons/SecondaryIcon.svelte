<script>
  const {Icon, isActive, ...props} = $props();
</script>

<Icon {...props} class="{props.class} {isActive ? '!fill-ternary' : 'hover:fill-ternary'} transition-[fill]"/>