<script>
  const {Icon, isActive, ...props} = $props();
</script>

<Icon {...props} class="{props.class} {isActive ? 'stroke-xlgames-ternary' : 'hover:stroke-xlgames-ternary'}
transition-[stroke]"></Icon>