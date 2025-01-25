<script>
  const {children, title, ...props} = $props();
</script>

<div {...props} class="{props.class} mb-7 last:mb-0">
  <div class="border-t border-t-(--color-hexadecimal)"></div>
  <h1 class="text-2xl font-medium pt-7 pb-7">{title}</h1>
  <div class="flex flex-col gap-y-4 text-sm">
    {@render children?.()}
  </div>
</div>