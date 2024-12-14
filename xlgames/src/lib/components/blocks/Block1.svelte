<script module>
  let presets = new Map();
  presets.set("left", "mr-auto ml-5");
  presets.set("center", "mx-auto");
  presets.set("right", "ml-auto mr-5");
</script>

<script>
  import Triangle from "$lib/components/icons/svg/Triangle.svelte";
  
  let {children, position = "center", ...props} = $props();
  let style = presets.get(position);
</script>

<div {...props} class="{props.class} w-fit">
  <Triangle class="fill-xlgames-3 h-1 top-[1px] w-fit relative {style}"/>
  <div class="border-xlgames-3 border-2 rounded-3xl overflow-hidden bg-xlgames-1 flex flex-col">
    {@render children?.()}
  </div>
</div>