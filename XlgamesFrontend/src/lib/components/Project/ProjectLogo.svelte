<script>
  const {children, ...props} = $props();
</script>

<div {...props} class="{props.class} size-8 flex-center border-2 border-xlgames-ternary rounded-lg">
  <span class="relative top-[0.5px] left-[0.5px]">{@render children?.()}</span>
</div>