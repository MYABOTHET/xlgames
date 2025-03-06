<script>
  const {Icon, isActive, ...props} = $props();
</script>

<Icon {...props}
      class="{props.class} {isActive ? 'fill-(--color-quaternary)!' : 'hover:fill-(--color-quaternary)'} transition-[fill]"/>