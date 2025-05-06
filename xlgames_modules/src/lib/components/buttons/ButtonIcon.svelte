<script>
  let {children, status, ...props} = $props();
</script>

<button {...props} class="{props.class} transition-all relative flex justify-center items-center
w-fit h-fit {status ? 'opacity-30 pointer-events-none' : ''}">
  {@render children?.()}
</button>