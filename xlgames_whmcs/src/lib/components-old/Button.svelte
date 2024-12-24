<script module>
  let colors = new Map();
  let general = "hover:text-white";
  colors.set("black", `${general} border-black text-black hover:bg-black`);
  colors.set("red", `${general} border-red-500 text-red-500 hover:bg-red-500`);
  colors.set("green", `${general} border-green-500 text-green-500 hover:bg-green-500`);
  colors.set("yellow", `${general} border-yellow-400 text-yellow-400 hover:bg-yellow-400`);
  colors.set("sky", `${general} border-sky-500 text-sky-500 hover:bg-sky-500`);
</script>

<script>
  let {children, color, ...props} = $props();
</script>

<button {...props} class="{props.class}
{color ? colors.has(color) ? colors.get(color) : colors.get('black') : props.class ? '' : colors.get('black') + ' px-2'}
 py-2 text-2xl rounded-lg border">
  {@render children?.()}
</button>