<script>
  let {children, ...props} = $props();
</script>

<button {...props} class="{props.class} py-2 px-8 w-fit text-2xl border rounded-lg">
  {@render children?.()}
</button>