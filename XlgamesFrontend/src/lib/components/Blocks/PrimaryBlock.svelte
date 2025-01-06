<script module>
  const presets = new Map();
  presets.set("primary", "border-xlgames-ternary");
  presets.set("secondary", "border-xlgames-quaternary");
  presets.set("ternary", "hover:border-xlgames-ternary transition-[border-color] border-transparent");
</script>

<script>
  const {children, preset, ...props} = $props();
</script>

<div {...props} class="{props.class} {presets.get(preset)} border-2 rounded-2xl bg-xlgames-primary overflow-x-hidden">
  {@render children?.()}
</div>