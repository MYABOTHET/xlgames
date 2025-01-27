<script>
  import {onMount} from "svelte";
  
  const {
    children, button, open = () => {
    }, close = () => {
    }, ...props
  } = $props();
  
  let isMenuVisible = $state(false);
  let isButtonFocused = $state(false);
  
  onMount(() => {
    return () => {
      close();
    }
  });
  
  function toggle() {
    isMenuVisible = !isMenuVisible;
    isMenuVisible ? open() : close();
  }
  
  function focus() {
    isButtonFocused = true;
  }
  
  function blur() {
    isButtonFocused = false;
  }
  
  function click() {
    if (!isButtonFocused) {
      isMenuVisible ? close() : '';
      isMenuVisible = false;
    }
  }
</script>

<svelte:window onclick={click}/>

<div {...props} class={props.class}>
  <button aria-label="Menu" onblur={blur} onclick={toggle} onfocus={focus} onmouseout={blur} onmouseover={focus}>
    {@render button?.(isMenuVisible)}
  </button>
  {#if isMenuVisible}
    {@render children?.()}
  {/if}
</div>