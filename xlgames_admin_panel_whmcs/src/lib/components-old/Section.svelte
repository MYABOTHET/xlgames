<script>
  let {children, title, ...props} = $props();
</script>

<div {...props} class="{props.class} flex flex-col">
  <h1 class="text-2xl text-start">{title}</h1>
  <div class="h-1.5"></div>
  <div class="border-b border-b-slate-300"></div>
  <div class="h-2.5"></div>
  {@render children?.()}
</div>