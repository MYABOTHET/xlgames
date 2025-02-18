<script>
  import TernaryText from "./texts/TernaryText.svelte";
  import Loader from "./svg/Loader.svelte";
  
  let {children, ...props} = $props();
</script>

<div {...props} class="{props.class} flex gap-x-4 items-center">
  <Loader class="h-7 fill-green-500"/>
  <TernaryText>{@render children?.()}</TernaryText>
</div>