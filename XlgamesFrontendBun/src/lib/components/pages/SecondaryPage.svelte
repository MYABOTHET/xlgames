<script>
  const {children, title, ...props} = $props();
</script>

<div {...props} class="{props.class} px-10 py-7 w-full overflow-y-auto overflow-x-hidden">
  <h1 class="text-3xl font-medium pb-7">{title}</h1>
  {@render children?.()}
</div>