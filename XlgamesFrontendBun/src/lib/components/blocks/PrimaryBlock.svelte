<script>
  import PrimaryTriangle from "$lib/components/svg/PrimaryTriangle.svelte";
  
  const {children, position, ...props} = $props();
</script>

<PrimaryTriangle class="{position} secondary-width fill-(--color-ternary) relative top-px"/>
<nav {...props} class="{props.class} primary-block bg-(--color-primary) border-(--color-ternary) flex flex-col">
  {@render children?.()}
</nav>