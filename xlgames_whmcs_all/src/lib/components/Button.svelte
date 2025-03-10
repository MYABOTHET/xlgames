<script>
  let {children, ...props} = $props();
</script>

<button {...props} class="{props.class} hover:!bg-red-500 bg-slate-800 text-white transition-colors
rounded-md px-6 py-3 font-[350]">
  {@render children?.()}
</button>