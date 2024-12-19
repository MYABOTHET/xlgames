<script>
  import Header from "$lib/components/Header.svelte";
  import Footer from "$lib/components/Footer.svelte";
  import {global_state, store} from "$lib/state.svelte.js";
  import {onMount} from "svelte";
  
  let {children, data} = $props();
  let {navigation_links, project_titles, languages} = data;
  
  global_state.shared_page = data.shared_page;
  let locale = $state(data.locale);
  
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
  
  function getCookie() {
    return document.cookie.split('; ').reduce((acc, item) => {
      const [name, value] = item.split('=')
      acc[name] = value
      return acc
    }, {})
  }
  
  async function change_language(new_locale) {
    let this_locale = getCookie()['saved-locale'];
    if (this_locale === new_locale) {
      return 0;
    }
    document.cookie = `saved-locale=${new_locale};max-age=${60 * 60 * 24 * 360}`;
    locale = new_locale;
    global_state.shared_page = await (await fetch('?page_id=0')).json();
    store.set({});
  }
  
  onMount(() => {
    let mql = create_is_mobile_mql();
    return () => {mql.removeEventListener('change', change_is_mobile)};
  });
</script>

<Header {navigation_links} {project_titles} {languages} {is_mobile} {locale} {change_language}/>

<main class="flex-1 flex flex-col items-center">
  <div class="min-h-12"></div>
  
  <div class="max-w-screen-xlgames-1 px-4 w-full h-full relative">
    {@render children?.()}
  </div>
  
  <div class="min-h-12"></div>
</main>

<Footer {navigation_links} {project_titles}/>