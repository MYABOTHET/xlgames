<script>
  import PrimaryPage from "$lib/components/pages/PrimaryPage.svelte";
  import PrimaryNav from "$lib/components/nav/PrimaryNav.svelte";
  import {page} from "$app/state";
  import {getContext, setContext} from "svelte";
  import SaveForm from "$lib/components/SaveForm.svelte";
  import {goto} from "$app/navigation";
  
  let {children, data} = $props();
  
  let language = $state(data.language);
  let links = getContext("links") ;
  let access = $state(null);
  let error = $state(null);
  let init = $state.raw({init: false});
  let counter = $state(20);
  let visible = $derived(page.url.pathname.split("/").length > 4);
  
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
  
  setContext("deleteLanguage", deleteLanguage);
  setContext("language", () => language);
  setContext("counter", () => counter);
</script>

<PrimaryNav links={data.linksOptions}/>

<PrimaryPage class="flex flex-col justify-between">
  {@render children()}
  {#if visible}
    <div class="sticky bottom-0 px-4 py-3 bg-(--color-primary) border-t border-t-(--color-hexadecimal) w-full">
      <SaveForm error={error} access={access} onclick={updateLanguage}/>
    </div>
  {/if}
</PrimaryPage>