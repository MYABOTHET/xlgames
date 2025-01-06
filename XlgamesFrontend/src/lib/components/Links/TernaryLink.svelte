<script>
  import PrimaryArrow from "$lib/components/Images/Svg/PrimaryArrow.svelte";
  import PrimaryTitle from "$lib/components/Titles/PrimaryTitle.svelte";
  
  let {children, ...props} = $props();
</script>

<a {...props} class="{props.class} flex gap-x-8 items-center transition-colors hover:text-xlgames-ternary
hover:fill-xlgames-ternary fill-white text-white">
  <PrimaryArrow class="min-w-3 max-w-3 -rotate-90"/>
  <PrimaryTitle>{@render children?.()}</PrimaryTitle>
</a>