<script>
  import Header from "$lib/components/Header.svelte";
  import Footer from "$lib/components/Footer.svelte";
  import {onMount} from "svelte";
  
  let {children, data} = $props();
  let {navigation_links, project_titles, languages, language, mobile} = data;
  
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

<Header {navigation_links} {project_titles} {languages} language={language.navigation_links} mobile={is_mobile}/>

<main class="flex-1 flex flex-col items-center">
  <div class="h-12"></div>
  
  <div class="max-w-screen-xlgames-1 px-4 w-full h-full relative">
    {@render children()}
  </div>
  
  <div class="h-12"></div>
</main>

<Footer {navigation_links} {project_titles}/>