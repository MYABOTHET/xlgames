<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import SaveForm from "$lib/components/SaveForm.svelte";
  import {getContext} from "svelte";
  import {goto} from "$app/navigation";
  
  let links = getContext("links");
  let languageDto = $state({
    Name: "...",
    WHMCSName: "...",
    OriginalName: "...",
    Locale: "...",
    Lang: "...",
    CurrencyId: 0
  });
  let access = $state(null);
  let error = $state(null);
  
  async function createLanguage() {
    if (invalidLocale) return;
    access = null;
    error = null;
    const response = await fetch("/admin/translates/create", {
      method: "POST",
      body: JSON.stringify(languageDto),
      headers: {
        'Content-Type': 'application/json'
      }
    });
    if (response.status === 200) {
      const language = await response.json();
      links.push({
        title: language.Name, href: `/admin/translates/${language.Id}`, id: language.Id
      });
      await goto(`/admin/translates/${language.Id}`);
    } else {
      access = false;
      error = await response.text();
    }
  }
  
  let invalidLocale = $derived.by(() => {
    try {
      new Intl.DateTimeFormat(languageDto.Locale);
      return false;
    } catch {
      return true;
    }
  });
</script>

<SecondaryPage title="Создать язык">
  <QuaternarySection title="Данные языка">
    <PrimaryTextarea bind:value={languageDto.Name} title="Название на русском | Английский"/>
    <PrimaryTextarea bind:value={languageDto.WHMCSName} title="Название в WHMCS | english"/>
    <PrimaryTextarea bind:value={languageDto.OriginalName} title="Название на этом языке | English"/>
    <div class="flex gap-x-4 items-center">
      <PrimaryTextarea bind:value={languageDto.Locale} class="w-fit max-w-full" title="Локаль | en-US"/>
      {#if invalidLocale}
        <h1 class="text-red-600 text-nowrap min-w-fit">- Невалидная локаль -</h1>
      {/if}
    </div>
    <PrimaryTextarea bind:value={languageDto.Lang} title="Локаль в HTML | en"/>
    <PrimaryTextarea bind:value={languageDto.CurrencyId} title="ID валюты в WHMCS | 1"/>
  </QuaternarySection>
  <SaveForm {access} {error} onclick={createLanguage} saved="Успешно" title="Создать язык"/>
</SecondaryPage>