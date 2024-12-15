<script>
  import '../app.css';
  
  let {children} = $props();
</script>

<svelte:head>
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link href="https://fonts.googleapis.com/css2?family=Inter:opsz,wght@14..32,100..900&display=swap" rel="stylesheet">
</svelte:head>

{@render children?.()}

<style lang="postcss">
  :global(body) {
    overflow-y: scroll;
    overflow-x: hidden;
  }
  
  :global(.custom-scroll::-webkit-scrollbar) {
    width: 0;
  }
  
  :global(.custom-scroll::-webkit-scrollbar-track) {
    background-color: transparent;
  }
  
  :global(.custom-scroll::-webkit-scrollbar-thumb) {
    background-color: theme(colors.xlgames-2);
  }
  
  :global(.custom-scroll2::-webkit-scrollbar) {
    height: 6px;
  }
  
  :global(.custom-scroll2::-webkit-scrollbar-track) {
    background-color: transparent;
  }
  
  :global(.custom-scroll2::-webkit-scrollbar-thumb) {
    background-color: theme(colors.xlgames-2);
    border-radius: 1000px;
  }
</style>