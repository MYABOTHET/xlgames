<script>
  import PrimaryArrow from "$lib/components/Images/Svg/PrimaryArrow.svelte";
  
  let {children, ...props} = $props();
</script>

<a {...props} class="{props.class} flex gap-x-4 items-center transition-colors hover:text-white
hover:fill-white fill-xlgames-ternary text-xlgames-ternary">
  {@render children?.()}
  <PrimaryArrow class="min-w-3 max-w-3 rotate-90"/>
</a>