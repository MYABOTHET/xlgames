<script module>
  let language = $state(null);
  let languageCaches = new Map();
</script>

<script>
  import PrimaryPage from "$lib/components/pages/PrimaryPage.svelte";
  import PrimaryNav from "$lib/components/nav/PrimaryNav.svelte";
  import {page} from "$app/state";
  import {getContext, onMount, setContext} from "svelte";
  import {goto} from "$app/navigation";
  import SaveFormPreset from "$lib/components/SaveFormPreset.svelte";
  
  let {children, data} = $props();
  let links = getContext("links");
  language = data.language;
  let access = $state(null);
  let error = $state(null);
  let init = $state.raw({init: false});
  let counter = $state(20);
  let visible = $derived(page.url.pathname.split("/").length > 4);
  let timeout = $state(null);
  
  async function updateLanguage() {
    if (invalidLocale) return;
    clearTimeout(timeout);
    access = null;
    error = null;
    const response = await fetch(`/admin/translates/${page.params.id}`, {
      method: "PUT",
      body: JSON.stringify(language),
      headers: {
        'Content-Type': 'application/json'
      }
    });
    if (response.status === 200) {
      access = true;
      links.find(link => link.id === language.Id).title = language.Name;
    } else {
      access = false;
      error = await response.text();
    }
    timeout = setTimeout(() => {
      access = null;
      error = null;
    }, 5000);
  }
  
  async function deleteLanguage() {
    access = null;
    error = null;
    counter--;
    if (counter <= 0) {
      const response = await fetch(`/admin/translates/${page.params.id}`, {
        method: "DELETE"
      });
      if (response.status === 200) {
        const index = links.findIndex(link => link.id === language.Id);
        links.splice(index, 1);
        await goto(`/admin/translates`);
      } else {
        counter = 20;
        access = false;
        error = await response.text();
      }
    }
  }
  
  $effect(() => {
    data.language;
    if (init.init) {
      language = data.language;
      access = null;
      error = null;
      counter = 20;
    } else {
      init.init = true;
    }
  });
  
  let invalidLocale = $derived.by(() => {
    try {
      new Intl.DateTimeFormat(language.Locale);
      return false;
    } catch {
      return true;
    }
  });
  
  onMount(() => {
    return () => {
      // console.log('asd');
    };
  });
  
  setContext("deleteLanguage", deleteLanguage);
  setContext("language", () => language);
  setContext("counter", () => counter);
  setContext("invalidLocale", () => invalidLocale);
</script>

<PrimaryNav links={data.linksOptions}/>

<PrimaryPage class="flex flex-col justify-between">
  {@render children()}
  {#if visible}
    <SaveFormPreset error={error} access={access} onclick={updateLanguage}/>
  {/if}
</PrimaryPage>