<script>
  let {title, children, ...props} = $props();
</script>

<div {...props} class="{props.class} flex gap-x-3">
  {@render children?.()}
  <span class="text-(--color-quaternary) my-auto font-normal text-nowrap">—</span>
  <h1 class="text-(--color-quaternary) my-auto font-normal text-nowrap">{title}</h1>
</div>