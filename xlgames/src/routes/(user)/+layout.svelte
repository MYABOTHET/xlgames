<script>
  import Header from "$lib/components/Header.svelte";
  import Footer from "$lib/components/Footer.svelte";
  import {global_state} from "$lib/state.svelte.js";
  import {onMount} from "svelte";
  
  let {children, data} = $props();
  let {navigation_links, project_titles, languages} = data;
  
  global_state.language = data.language;
  
  const max_width = 950;
  let is_mobile = $state(data.is_mobile);
  
  function change_is_mobile(e) {
    is_mobile = e.matches;
  }
  
  function create_is_mobile_mql() {
    const mql = window.matchMedia(`(max-width: ${max_width}px)`);
    mql.addEventListener("change", change_is_mobile);
    is_mobile = window.innerWidth <= max_width;
    return mql;
  }
  
  onMount(() => {
    let mql = create_is_mobile_mql();
    return () => {mql.removeEventListener('change', change_is_mobile)};
  });
</script>

<Header {navigation_links} {project_titles} {languages} {is_mobile}/>

<main class="flex-1 flex flex-col items-center">
  <div class="min-h-12"></div>
  
  <div class="max-w-screen-xlgames-1 px-4 w-full h-full relative">
    {@render children?.()}
  </div>
  
  <div class="min-h-12"></div>
</main>

<Footer {navigation_links} {project_titles}/>