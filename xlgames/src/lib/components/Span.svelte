<script>
  let {children, hui, ...props} = $props();
  let s = `text-${hui}-500`;
</script>

<button {...props} class="{props.class} {s}">
  {@render children?.()}
</button>