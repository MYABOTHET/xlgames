<script>
  let {children, active, ...props} = $props();
</script>

<button {...props} class="{active ? '' : 'text-slate-400 hover:!text-slate-500'} font-[350]
transition-colors">
  {@render children?.()}
</button>