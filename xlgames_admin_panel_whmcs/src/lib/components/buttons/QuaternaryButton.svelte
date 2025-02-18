<script>
  import SecondaryButton from "./SecondaryButton.svelte";
  
  let {children, ...props} = $props();
</script>

<SecondaryButton {...props} class="{props.class} border-red-500 text-red-500 hover:bg-red-500
hover:text-white">
  {@render children?.()}
</SecondaryButton>