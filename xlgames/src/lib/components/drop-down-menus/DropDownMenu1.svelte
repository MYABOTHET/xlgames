<script>
  let {button, menu, ...props} = $props();
  
  let menu_visible = $state(false);
  let button_focus = $state(false);
  
  function toggle() {
    menu_visible = !menu_visible;
  }
  
  function focus() {
    button_focus = true;
  }
  
  function blur() {
    button_focus = false;
  }
  
  function click() {
    if (!button_focus) {
      menu_visible = false;
    }
  }
</script>

<svelte:window onclick={click}></svelte:window>

<div {...props} class="{props.class} flex justify-center items-center z-50">
  <button onmouseout={blur} onmouseover={focus} onblur={blur} onfocus={focus} onclick={toggle}>
    {@render button?.(menu_visible)}
  </button>
  {#if menu_visible}
    {@render menu?.()}
  {/if}
</div>