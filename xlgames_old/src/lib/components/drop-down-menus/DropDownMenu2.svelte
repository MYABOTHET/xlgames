<script>
  import {onDestroy} from "svelte";
  
  let {button, menu, visible, ...props} = $props();
  
  let menu_visible = $state(false);
  
  function toggle() {
    menu_visible = !menu_visible;
    visible(menu_visible);
  }
  
  function close_menu() {
    menu_visible = false;
    visible(false);
  }
  
  onDestroy(() => {
    close_menu();
  })
  
</script>

<div {...props} class="{props.class} flex justify-center items-center">
  <button onclick={toggle}>
    {@render button?.(menu_visible)}
  </button>
  {#if menu_visible}
    {@render menu?.(close_menu)}
  {/if}
</div>