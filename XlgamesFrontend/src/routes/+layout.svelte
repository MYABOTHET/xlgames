<script>
  import "../app.css";
  import {onMount, setContext} from "svelte";
  import Header from "$lib/components/Header.svelte";
  import configuration from "$lib";
  import Footer from "$lib/components/Footer.svelte";
  import {quartInOut} from "svelte/easing";
  import {fly} from "svelte/transition";
  import {getUserLanguageFromCookieClient} from "$lib/tools.js";
  
  const {children, data} = $props();
  const {headerHeight, author, navigationLinks, projectData, languages, mobileWidth} = data;
  
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
  
  function getCookie() {
    return document.cookie.split("; ").reduce((acc, item) => {
      const [name, value] = item.split("=")
      acc[name] = value
      return acc
    }, {});
  }
  
  async function setLanguage(languageItem) {
    const userLanguage = getUserLanguageFromCookieClient(getCookie());
    if (languageItem.Locale === userLanguage.Locale) return;
    setUserLanguage(languageItem);
    languageDto = languageItem;
    language = await (await fetch('/')).json();
  }
  
  function setUserLanguage(language) {
    document.cookie = `${configuration.userLanguage}=${encodeURIComponent(JSON.stringify(language))};max-age=${maxAgeCookie};path=/;priority=high`;
    document.documentElement.lang = language.Lang;
  }
  
  function setCookieAgreement() {
    agreeCookie = true;
    document.cookie = `${configuration.cookieAgreement}=true;max-age=${maxAgeCookie};path=/`;
  }
  
  function setUserOnMobile(event) {
    userOnMobile = event.matches;
  }
  
  onMount(() => {
    // 1rem = 16px;
    userOnMobile = (window.innerWidth / 16) <= mobileWidth;
    const matchMedia = `(max-width: ${mobileWidth}rem)`;
    const mql = window.matchMedia(matchMedia);
    mql.addEventListener("change", setUserOnMobile);
    const cookieTimeout = setTimeout(() => {
      if (!getCookie()[configuration.cookieAgreement]) agreeCookie = false;
    }, 5000);
    const userLanguage = getUserLanguageFromCookieClient(getCookie());
    if (userLanguage.Locale !== languageDto.Locale) setUserLanguage(languageDto);
    return () => {
      mql.removeEventListener("change", setUserOnMobile);
      clearTimeout(cookieTimeout);
    };
  });
  
  setContext("language", () => language);
  setContext("languageDto", () => languageDto);
</script>

<svelte:head>
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
      <p>{language.CookiePolicy.CookiePolicyBanner.Description} <a href="/cookie-policy"
                                                                   class="primary-link">{language.Shared.ReadMore}
        ...</a></p>
      <button onclick={setCookieAgreement}
              class="quinary-block rounded-none py-2 px-3">{language.CookiePolicy.CookiePolicyBanner.Name}</button>
    </article>
  </div>
{/if}