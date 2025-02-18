<script>
  let {title, children, ...props} = $props();
</script>

<div {...props} class="{props.class} flex text-xl">
  <div class="flex flex-auto min-w-[164px] max-w-[164px] h-fit">
    <div class="truncate">{title}</div>
    <div>:</div>
    <div class="flex-auto border-b-slate-400 border-b border-dotted min-w-2 my-1 mx-1"></div>
  </div>
  <div class="text-wrap">{@render children?.()}</div>
</div>