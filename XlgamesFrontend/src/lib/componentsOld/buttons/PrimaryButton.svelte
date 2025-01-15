<script>
  const {isActive, children, ...props} = $props();
</script>

<div {...props} class="{props.class} {isActive ? 'border-ternary text-ternary' : 'border-quaternary text-quaternary'}
quaternary-p h-fit primary-block-default rounded-full primary-bg truncate">{@render children?.()}</div>