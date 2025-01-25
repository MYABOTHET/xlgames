<script>
  import PrimaryPage from "$lib/components/pages/PrimaryPage.svelte";
  import PrimaryNav from "$lib/components/nav/PrimaryNav.svelte";
  import {page} from "$app/state";
  import {getContext, setContext} from "svelte";
  
  let {children, data} = $props();
  
  let language = $state(data.language);
  let links = getContext("links") ;
  let access = $state(null);
  let error = $state(null);
  let init = $state.raw({init: false});
  
  async function updateLanguage() {
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
  }
  
  async function deleteLanguage() {
    access = null;
    error = null;
    const response = await fetch(`/admin/translates/${page.params.id}`, {
      method: "DELETE"
    });
    if (response.status === 200) {
      access = true;
      const index = links.findIndex(link => link.id === language.Id);
      links.splice(index, 1);
    } else {
      access = false;
      error = await response.text();
    }
  }
  
  $effect(() => {
    data.language;
    if (init.init) {
      language = data.language;
      access = null;
      error = null;
    } else {
      init.init = true;
    }
  });
  
  setContext("updateLanguage", updateLanguage);
  setContext("deleteLanguage", deleteLanguage);
  setContext("language", () => language);
  setContext("access", () => access);
  setContext("error", () => error);
</script>

<PrimaryNav links={data.linksOptions}/>

<PrimaryPage>
  {@render children?.()}
</PrimaryPage>