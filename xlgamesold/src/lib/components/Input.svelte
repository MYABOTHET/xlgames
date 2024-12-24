<script module>
  let colors = new Map();
  colors.set("black", "border-black text-black placeholder-black");
  colors.set("sky", "border-sky-500 text-sky-500 placeholder-sky-500");
</script>

<script>
  let { value = $bindable(), color, ...props } = $props();
</script>

<input bind:value {...props} class="{props.class}
{color ? colors.has(color) ? colors.get(color) : colors.get('black') : props.class ? '' : colors.get('black')}
 outline-none py-1 px-2 border rounded">