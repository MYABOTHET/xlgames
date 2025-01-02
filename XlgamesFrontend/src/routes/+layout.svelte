<script>
  import "../app.css";
  
  let {children} = $props();
</script>

<svelte:head>
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link href="https://fonts.googleapis.com/css2?family=Inter:opsz,wght@14..32,100..900&display=swap" rel="stylesheet">
  <meta content="Лёвин Валерий Дмитриевич" name="author">
</svelte:head>

<main class="flex-auto py-12">
  {@render children?.()}
</main>

<style lang="postcss">
  :global(html) {
    @apply overflow-y-scroll overflow-x-hidden
  }
  :global(html, body) {
    @apply h-dvh w-full
  }
  :global(body) {
    @apply bg-xlgames-primary text-white font-inter tracking-wide font-[350] flex flex-col justify-between
  }
</style>