<script>
  import Arrow2 from "$lib/components/icons/svg/Arrow2.svelte";
  
  let {...props} = $props();
</script>

<a {...props} class="{props.class} bg-xlgames-3 rounded-full transition-colors size-12 border-2 border-xlgames-3
hover:bg-transparent flex justify-center items-center fill-xlgames-1 hover:fill-white">
  <Arrow2 class="w-3"/>
</a>