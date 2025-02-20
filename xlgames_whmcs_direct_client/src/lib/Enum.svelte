<script>
  const {title, children, ...props} = $props();
</script>

<div {...props} class="{props.class} block">
  <div class="enum">
    <div class="title">{title}:</div>
    <div class="line"></div>
  </div>
  <div>{@render children?.()}</div>
</div>

<style>
  .line {
    border-bottom: 1px dotted var(--color-xlgames-grey-light-500);
    width: 100%;
    min-width: 16px;
    margin: 0 4px 2px 4px;
  }
  .enum {
    display: flex;
    height: fit-content;
    width: 100%;
  }
  .block {
    display: flex;
    text-wrap: nowrap;
    margin-bottom: 8px;
  }
</style>