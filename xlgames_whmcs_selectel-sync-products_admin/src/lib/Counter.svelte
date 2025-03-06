<script>
  import Button from "./Button.svelte";
  
  let { children, onclick, ...props } = $props();
  
  let counter = $state(1);
  
  function click() {
    if (counter < 0) {
      onclick();
      counter = 1;
    } else {
      --counter;
    }
  }
</script>

<Button {...props} onclick={click}>{@render children?.()}</Button>