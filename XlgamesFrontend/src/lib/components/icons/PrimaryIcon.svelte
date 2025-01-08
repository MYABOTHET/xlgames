<script>
  const {Icon, isActive, ...props} = $props();
</script>

<Icon {...props} class="{props.class} {isActive ? '!stroke-ternary' : 'hover:stroke-ternary'} transition-[stroke]"/>