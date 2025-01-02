<script>
  let {
    children,
    modal,
    freeze,
    ...props
  } = $props();
</script>

<div {...props} class="{props.class} relative">
  <div class="duration-300 {freeze ? 'blur-sm' : 'blur-0'}">
    {@render children?.()}
  </div>
  {#if modal}
    <div class="duration-300 w-full h-full flex justify-center items-center absolute top-0 left-0
{freeze ? 'opacity-100 blur-0' : 'blur-sm opacity-0 pointer-events-none'}">
      {@render modal()}
    </div>
  {/if}
</div>