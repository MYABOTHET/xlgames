<script>
  const {title, children, ...props} = $props();
</script>

<div {...props} class="{props.class} primary_block">
  <h1>{title}</h1>
  <div class="horizontal_line"></div>
  {@render children?.()}
</div>