<script>
  import {onMount} from "svelte";
  
  const {children, button, open = () => {}, close = () => {}, ...props} = $props();
  
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
  <button style="width: inherit; height: inherit" onmouseout={blur} onmouseover={focus} onblur={blur} onfocus={focus} onclick={toggle}>
    {@render button?.(isMenuVisible)}
  </button>
  {#if isMenuVisible}
    {@render children?.()}
  {/if}
</div>