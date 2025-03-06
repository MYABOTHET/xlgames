<script>
  let { children, ...props } = $props();
</script>

<button {...props}
        class="{props.class} rounded-md bg-slate-800 text-white px-6 py-3 hover:bg-red-500 transition-colors">{@render children?.()}</button>