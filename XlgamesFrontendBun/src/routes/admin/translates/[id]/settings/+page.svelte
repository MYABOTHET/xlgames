<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";
  
  let language = getContext("language")();
  let counter = $derived(getContext("counter")());
  let deleteLanguage = getContext("deleteLanguage");
  let invalidLocale = $derived(getContext("invalidLocale")());
</script>

<SecondaryPage title="Настройки языка «{language.Name}»">
  <QuaternarySection title="Идентификационные данные">
    <PrimaryTextarea bind:value={language.Name} title="Название на русском"/>
    <PrimaryTextarea bind:value={language.WHMCSName} title="Название в WHMCS"/>
    <PrimaryTextarea bind:value={language.OriginalName} title="Название на этом языке"/>
    <div class="flex gap-x-4 items-center">
      <PrimaryTextarea bind:value={language.Locale} class="w-fit max-w-full" title="Локаль | en-US"/>
      {#if invalidLocale}
        <h1 class="text-red-600 text-nowrap min-w-fit">- Невалидная локаль -</h1>
      {/if}
    </div>
    <PrimaryTextarea bind:value={language.Lang} title="Локаль в HTML"/>
    <PrimaryTextarea bind:value={language.CurrencyId} title="ID валюты в WHMCS"/>
  </QuaternarySection>
  <button class="px-5 border-2 bg-red-500 border-red-500 rounded min-w-44
  text-nowrap text-(--color-primary) transition-colors hover:bg-(--color-primary) hover:text-white
  min-h-9 text-sm" onclick={deleteLanguage}>Удалить язык ({counter})
  </button>
</SecondaryPage>