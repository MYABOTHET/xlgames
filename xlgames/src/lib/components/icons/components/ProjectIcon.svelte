<script>
  let {title, ...props} = $props();
</script>

<div {...props} class="{props.class} flex justify-center items-center
 border-xlgames-3 border-2 rounded-lg w-fit min-w-8 min-h-8 max-h-8 font-semibold text-[16px]">
  {title}
</div>