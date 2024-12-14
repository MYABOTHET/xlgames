<script>
  import '../app.css';
  import Header from "$lib/components/Header.svelte";
  import {onMount} from "svelte";
  import Footer from "$lib/components/Footer.svelte";

  let {children, data} = $props();
  let {navigation_links, mobile} = data;
  
  let is_mobile = $state(mobile);
  
  onMount(() => {
    const max_width = 950;
    const mql = window.matchMedia(`(max-width: ${max_width}px)`);
    function change(e) {
      is_mobile = e.matches;
    }
    mql.addEventListener("change", change);
    is_mobile = window.innerWidth <= 950;
  });
</script>

<svelte:head>
  <title>XLGAMES.GG</title>
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link href="https://fonts.googleapis.com/css2?family=Inter:opsz,wght@14..32,100..900&display=swap" rel="stylesheet">
</svelte:head>

<Header mobile={is_mobile}/>

<main class="flex-1 flex flex-col items-center">
  <div class="h-12"></div>
  
  <div class="max-w-screen-xlgames-1 px-4 w-full relative">
    {@render children()}
  </div>
  
  <div class="h-28"></div>
</main>

<Footer/>