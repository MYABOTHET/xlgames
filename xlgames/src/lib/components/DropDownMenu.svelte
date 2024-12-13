<script>
  let {button, menu, ...props} = $props();
  
  let menu_visible = $state(false);
  
  function show() {
    menu_visible = true;
  }
  
  function hidden() {
    menu_visible = false;
  }
</script>

<div {...props} class="{props.class} relative flex">
  <button onblur={hidden} onfocus={show}>
    {@render button?.(menu_visible)}
  </button>
  {#if menu_visible}
    {@render menu?.("absolute")}
  {/if}
</div>