<script>
  import BottomLine from "./BottomLine.svelte";
  
  let {header, children, ...props} = $props();
</script>

<div {...props} class="{props.class} flex flex-col">
  {@render header?.()}
  <div class="h-4"></div>
  <BottomLine />
  <div class="h-6"></div>
  {@render children?.()}
</div>