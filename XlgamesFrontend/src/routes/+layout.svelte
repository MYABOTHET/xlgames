<script>
  import "../app.css";
  import {onMount, setContext} from "svelte";
  import Header from "$lib/components/Header.svelte";
  import configuration from "$lib";
  import Footer from "$lib/components/Footer.svelte";
  import {quartInOut} from "svelte/easing";
  import {fly} from "svelte/transition";
  
  const {children, data} = $props();
  const {headerHeight, author, navigationLinks, projectData, languages} = data;
  
  let language = $state(data.language);
  let languageDto = $state({
    Id: data.language.Id,
    Name: data.language.Name,
    WHMCSName: data.language.WHMCSName,
    OriginalName: data.language.OriginalName,
    Locale: data.language.Locale,
    Lang: data.language.Lang,
  });
  let userOnMobile = $state(data.userOnMobile);
  let agreeCookie = $state(true);
  
  let maxAgeCookie = 60 * 60 * 24 * 360;
  const mobileWidth = data.mobileWidth;
  
  async function setLanguage(value) {
    const userLocale = getCookie()[configuration.savedUserLocale];
    if (value.Locale === userLocale) return;
    languageDto = value;
    setUserLocale(value.Locale);
    setUserLang(value.Lang);
    language = await (await fetch(`/?locale=${value.Locale}`)).json();
  }
  
  function setUserLocale(locale) {
    document.cookie = `${configuration.savedUserLocale}=${locale};max-age=${maxAgeCookie};path=/`;
  }
  
  function setUserLang(lang) {
    document.cookie = `${configuration.savedUserLang}=${lang};max-age=${maxAgeCookie};path=/`;
    document.documentElement.lang = lang;
  }
  
  function getCookie() {
    return document.cookie.split("; ").reduce((acc, item) => {
      const [name, value] = item.split("=")
      acc[name] = value
      return acc
    }, {});
  }
  
  function setUserOnMobile(event) {
    userOnMobile = event.matches;
  }
  
  function createUserOnMobileMQL() {
    const matchMedia = `(max-width: ${mobileWidth}rem)`;
    const mql = window.matchMedia(matchMedia);
    mql.addEventListener("change", setUserOnMobile);
    return mql;
  }
  
  function closeCookieMenu() {
    agreeCookie = true;
    setCookieAgreement();
  }
  
  function setCookieAgreement() {
    document.cookie = `${configuration.cookieAgreement}=true;max-age=${maxAgeCookie};path=/`;
  }
  
  onMount(() => {
    // 1rem = 16px;
    userOnMobile = (window.innerWidth / 16) <= mobileWidth;
    const mql = createUserOnMobileMQL();
    const cookieTimeout = setTimeout(() => {
      const cookieAgreement = getCookie()[configuration.cookieAgreement];
      if (!cookieAgreement) agreeCookie = false;
    }, 5000);
    setUserLocale(languageDto.Locale);
    setUserLang(languageDto.Lang);
    return () => {
      mql.removeEventListener("change", setUserOnMobile);
      clearTimeout(cookieTimeout);
    };
  });
  
  setContext("language", () => language);
  setContext("languageDto", () => languageDto);
</script>

<svelte:head>
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link
      href="https://fonts.googleapis.com/css2?family=Inter:ital,opsz,wght@0,14..32,100..900;1,14..32,100..900&display=swap"
      rel="stylesheet">
  <meta name="author" content={author}>
  {@html language.Shared.Head}
</svelte:head>

<Header {headerHeight} {navigationLinks} {projectData} {languages} {userOnMobile} {setLanguage}/>

<main class="flex-auto primary-px py-14">
  <div class="max-w-screen-primary w-full mx-auto h-full">{@render children?.()}</div>
</main>

<Footer {navigationLinks} {projectData}/>

{#if !agreeCookie}
  <div transition:fly={{x: "-100vw", duration: 375, delay: 0, opacity: 1, easing: quartInOut}}
       class="fixed w-full h-dvh bottom-0 pointer-events-none flex items-end primary-px py-5 z-[5]">
    <article class="pointer-events-auto bg-primary primary-block-default border-ternary py-5 px-6 flex flex-col
  gap-y-4 w-96 text-sm leading-[1.375rem] max-hexadecimal:w-full">
      <p>{language.CookiePolicy.CookiePolicyBanner.Description} <a href="/cookie-policy" class="primary-link">{language.Shared.ReadMore}...</a></p>
      <button onclick={closeCookieMenu} class="quinary-block rounded-none py-2 px-3">
        {language.CookiePolicy.CookiePolicyBanner.Name}
      </button>
    </article>
  </div>
{/if}