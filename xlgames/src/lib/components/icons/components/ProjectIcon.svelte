<script>
  let {title, ...props} = $props();
</script>

<div {...props} class="{props.class} border-xlgames-3 border-2 rounded-lg px-1 py-0.5">
  <span class="font-semibold text-[15px]">{title}</span>
</div>