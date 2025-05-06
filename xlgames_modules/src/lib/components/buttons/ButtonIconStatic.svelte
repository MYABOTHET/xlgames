<script>
  let {children, ...props} = $props();
</script>

<button {...props} class="{props.class} transition-all relative flex justify-center items-center
w-fit">
  {@render children?.()}
</button>