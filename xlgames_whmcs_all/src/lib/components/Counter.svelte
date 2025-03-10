<script>
  import Button from "./Button.svelte";
  
  let {onclick, children, ...props} = $props();
  
  let counter = $state(3);
  
  function click() {
    counter--;
    if (counter < 1) {
      onclick();
      counter = 3;
    }
  }
</script>

<Button {...props} onclick={click}>{@render children?.()}</Button>