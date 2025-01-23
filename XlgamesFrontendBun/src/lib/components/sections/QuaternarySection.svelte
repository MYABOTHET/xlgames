<script>
  const {children, title, ...props} = $props();
</script>

<div>
  <div class="border-t border-t-hexadecimal"></div>
  <h1 class="text-2xl font-medium pt-7 pb-7">{title}</h1>
  {@render children?.()}
</div>