<script>
  import {onMount, setContext} from "svelte";
  import Header from "$lib/components/Header.svelte";
  import configuration from "$lib";
  import Footer from "$lib/components/Footer.svelte";
  import {quartInOut} from "svelte/easing";
  import {fly} from "svelte/transition";
  import {page} from "$app/state";
  import {replaceState} from "$app/navigation";
  import {generateUrl, transformLocale} from "$lib/tools.js";
  
  const {children, data} = $props();
  const {headerHeight, author, projectData, navigationLinks, languages, mobileWidth} = data;
  
  let language = $state.raw(data.language);
  let languageDto = $state.raw({
    Id: data.language.Id,
    Name: data.language.Name,
    WHMCSName: data.language.WHMCSName,
    OriginalName: data.language.OriginalName,
    Locale: data.language.Locale,
    Lang: data.language.Lang,
    CurrencyId: data.language.CurrencyId
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
    document.cookie = `${configuration.userLanguage}=${encodeURIComponent(JSON.stringify(languageItem))};max-age=${maxAgeCookie};path=/;priority=high`;
    if (languageItem.Locale === languageDto.Locale) return;
    document.documentElement.lang = languageItem.Lang;
    let url = page.url.pathname.split("/");
    url = url.filter(url => url !== '');
    if (languageDto.Locale === "en-US") {
      url.unshift('');
    }
    url.splice(0, 1);
    if (languageItem.Locale !== "en-US") {
      url.unshift(languageItem.Lang);
    }
    replaceState('/' + url.join('/'));
    page.url.pathname = '/' + url.join('/');
    languageDto = languageItem;
    language = await (await fetch(`/?id=${languageItem.Id}`)).json();
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
    return () => {
      mql.removeEventListener("change", setUserOnMobile);
      clearTimeout(cookieTimeout);
    };
  });
  
  setContext("language", () => language);
  setContext("languageDto", () => languageDto);
</script>

<svelte:head>
  <meta content="width=device-width, initial-scale=1" name="viewport"/>
  <meta content={author} name="author">
  {#each languages as translate}
    <link rel="alternate" hreflang={translate.Lang}
          href={generateUrl(translate.Lang, page.url.pathname, languageDto)}/>
  {/each}
  <link rel="alternate" hreflang="x-default" href={generateUrl("en", page.url.pathname, languageDto)}/>
  {@html projectData.Head}
  {@html language.Shared.Head}
</svelte:head>

<Header {headerHeight} {languages} {navigationLinks} {projectData} {setLanguage} {userOnMobile}/>

<main class="flex-auto primary-px py-14">
  <div class="max-w-(--breakpoint-primary) w-full mx-auto h-full">{@render children?.()}</div>
</main>

<Footer {navigationLinks} {projectData}/>

{#if !agreeCookie}
  <div transition:fly={{x: "-100vw", duration: 375, delay: 0, opacity: 1, easing: quartInOut}}
       class="fixed w-full h-dvh bottom-0 pointer-events-none flex items-end primary-px py-5 z-30">
    <article class="pointer-events-auto bg-(--color-primary) primary-block-default border-(--color-ternary) py-5 px-6 flex flex-col
  gap-y-4 w-96 text-sm leading-[1.375rem] max-hexadecimal:w-full">
      <p>{language.CookiePolicy.CookiePolicyBanner.Description} <a href={transformLocale(languageDto.Lang, "/cookie-policy")}
                                                                   class="primary-link">{language.Shared.ReadMore + "..."}</a>
      </p>
      <button onclick={setCookieAgreement}
              class="quinary-block rounded-none py-2 px-3">{language.CookiePolicy.CookiePolicyBanner.Name}</button>
    </article>
  </div>
{/if}

<style>
  @reference "tailwindcss/theme";
  
  :global(html) {
    @apply overflow-y-scroll overflow-x-hidden;
  }
  
  :global(body) {
    @apply flex flex-col justify-between;
  }
</style>