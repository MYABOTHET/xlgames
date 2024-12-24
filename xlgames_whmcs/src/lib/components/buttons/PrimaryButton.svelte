<script>
  let {children, ...props} = $props();
</script>

<button {...props} class="{props.class} text-slate-400">
  {@render children?.()}
</button>