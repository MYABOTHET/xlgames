<script>
  import "../app.css";
  import PrimaryHeader from "$lib/components/Headers/PrimaryHeader.svelte";
  import PrimaryScreen from "$lib/components/Screens/PrimaryScreen.svelte";
  import {onMount, setContext} from "svelte";
  import PrimaryFooter from "$lib/components/Footers/PrimaryFooter.svelte";
  
  const {children, data} = $props();
  const {links, project, languages} = data;
  
  let language = $state(data.language);
  let isMobile = $state(data.isMobile);
  const mobileWidth = 1056;
  
  function getCookie() {
    return document.cookie.split('; ').reduce((acc, item) => {
      const [name, value] = item.split('=')
      acc[name] = value
      return acc
    }, {})
  }
  
  async function setLanguage(newLanguage) {
    const locale = newLanguage["Locale"];
    const thisLocale = getCookie()['saved-user-locale'];
    if (thisLocale === locale) return 0;
    document.cookie = `saved-user-locale=${locale};max-age=${60 * 60 * 24 * 360};path=/`;
    const url = new URL(location.origin);
    url.searchParams.set("locale", locale);
    language = await (await fetch(url)).json();
  }
  
  function setIsMobile(event) {
    isMobile = event.matches;
  }
  
  function createIsMobileMQL() {
    const mql = window.matchMedia(`(max-width: ${mobileWidth}px)`);
    mql.addEventListener('change', setIsMobile);
    isMobile = window.innerWidth <= mobileWidth;
    return mql;
  }
  
  onMount(() => {
    const mql = createIsMobileMQL();
    return () => {
      mql.removeEventListener('change', setIsMobile)
    };
  });
  
  setContext('language', () => language);
</script>

<svelte:head>
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link href="https://fonts.googleapis.com/css2?family=Inter:opsz,wght@14..32,100..900&display=swap" rel="stylesheet">
  <meta content="Лёвин Валерий Дмитриевич" name="author">
</svelte:head>

<PrimaryHeader height="80px" {links} {project} {languages} {setLanguage} {isMobile}/>

<main class="flex-auto py-14 primary-x-padding flex justify-center">
  <PrimaryScreen>
    {@render children?.()}
  </PrimaryScreen>
</main>

<PrimaryFooter {links} {project}/>

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
  
  :global {
    .news-description :global {
      @apply text-sm leading-[1.375rem] text-wrap;
      
      h1, h2, h3, h4, h5, h6, strong {
        @apply font-medium;
      }
      
      h1, h2, h3, h4, h5, h6 {
        @apply text-lg;
      }
      
      li {
        @apply list-disc;
      }
      
      a {
        @apply transition-[color] hover:text-xlgames-quaternary text-xlgames-ternary;
      }
    }
  }
</style>