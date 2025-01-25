<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import SaveForm from "$lib/components/SaveForm.svelte";
  import {getContext} from "svelte";
  import {goto} from "$app/navigation";
  
  let language = getContext("language")();
  let access = getContext("access");
  let error = getContext("error");
  let updateLanguage = getContext("updateLanguage");
  let deleteLanguage = getContext("deleteLanguage");
  
  let counter = $state(10);
  
  async function deleteCounter() {
    counter--;
    if (counter <= 0) {
      await deleteLanguage();
      if (access) {
        await goto(`/admin/translates`);
      } else {
        counter = 10;
      }
    }
  }
</script>

<SecondaryPage title="Настройки языка «{language.Name}»">
  <QuaternarySection title="Идентификационные данные">
    <PrimaryTextarea bind:value={language.Name} title="Название на русском"/>
    <PrimaryTextarea bind:value={language.WHMCSName} title="Название в WHMCS"/>
    <PrimaryTextarea bind:value={language.OriginalName} title="Название на этом языке"/>
    <PrimaryTextarea bind:value={language.Locale} title="Локаль"/>
    <PrimaryTextarea bind:value={language.Lang} title="Локаль в HTML"/>
    <PrimaryTextarea bind:value={language.CurrencyId} title="ID валюты в WHMCS"/>
  </QuaternarySection>
  <SaveForm buttonClass="min-w-36" error={error()} access={access()} onclick={updateLanguage}/>
  <button onclick={deleteCounter} class="mt-4 px-5 border-2 bg-red-500 border-red-500 rounded
  text-nowrap text-(--color-primary) transition-colors hover:bg-(--color-primary) hover:text-white min-w-36
  min-h-9 text-sm">Удалить ({counter})</button>
</SecondaryPage>