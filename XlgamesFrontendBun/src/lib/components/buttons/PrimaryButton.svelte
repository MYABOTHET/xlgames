<script>
  const {children, ...props} = $props();
</script>

<button {...props} class="{props.class} px-5 border-2 bg-(--color-ternary) border-(--color-ternary) rounded
      text-(--color-primary) transition-colors hover:bg-(--color-primary) hover:text-white w-fit min-h-9 text-sm">{@render children?.()}</button>