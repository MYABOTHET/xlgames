<script>
  import SecondaryButton from "./SecondaryButton.svelte";
  
  let {children, ...props} = $props();
</script>

<SecondaryButton {...props} class="{props.class} border-green-500 text-green-500 hover:bg-green-500
hover:text-white">
  {@render children?.()}
</SecondaryButton>