<script>
  const {Icon, isActive, ...props} = $props();
</script>

<Icon {...props}
      class="{props.class} {isActive ? 'stroke-(--color-ternary)!' : 'hover:stroke-(--color-ternary)'} transition-[stroke]"/>