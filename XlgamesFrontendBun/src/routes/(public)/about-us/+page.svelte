<script>
  import {getContext} from "svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
</script>

<svelte:head>
  <title>{language.AboutUs.Title} - {data.projectData.Name}</title>
  {@html language.AboutUs.Head}
</svelte:head>

<div class="max-w-(--breakpoint-hexadecimal) w-full mx-auto">
  <article class="secondary-section">
    <h1 class="primary-title">{language.AboutUs.Name}</h1>
    <img alt={language.AboutUs.Name} class="rounded-2xl ternary-size quaternary-height"
         src="/images/about-us.webp">
    <p class="text-sm leading-[1.375rem]">
      {language.AboutUs.Description}
    </p>
    <p class="text-sm leading-[1.375rem]">{language.Shared.AnySuggestionsStart}<a class="primary-link"
                                                                                  href="/contacts">{language.Shared.AnySuggestionsCenter}</a>{language.Shared.AnySuggestionsEnd}
    </p>
  </article>
</div>