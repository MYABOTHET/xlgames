<script>
  import Arrow from "$lib/components/icons/svg/Arrow.svelte";
  
  let {children, ...props} = $props();
</script>

<a {...props} class="{props.class} hover:text-white hover:fill-white fill-xlgames-3 text-xlgames-3
 transition-colors flex gap-x-4 justify-center items-center">
  <span>{@render children?.()}</span>
  <Arrow class="w-3 rotate-90 -z-10"/>
</a>