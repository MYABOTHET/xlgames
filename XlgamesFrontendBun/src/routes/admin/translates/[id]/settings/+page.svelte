<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";

  let language = getContext("language")();
  let counter = $derived(getContext("counter")());
  let deleteLanguage = getContext("deleteLanguage");
  let updateTranslate = getContext("updateTranslate");
  let invalidLocale = $derived(getContext("invalidLocale")());

  let newTranslate = $state("");

  let {data} = $props();
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
    <button class="max-w-48 px-5 border-2 bg-red-500 border-red-500 rounded min-w-44
  text-nowrap text-(--color-primary) transition-colors hover:bg-(--color-primary) hover:text-white
  min-h-9 text-sm" onclick={deleteLanguage}>Удалить язык ({counter})
    </button>
  </QuaternarySection>
  <QuaternarySection title="Система переводов">
    <a class="flex max-w-48 justify-center items-center px-5 border-2 bg-yellow-500 border-yellow-500 rounded min-w-44
  text-nowrap text-(--color-primary) transition-colors hover:bg-(--color-primary) hover:text-white
  min-h-9 text-sm" href="/admin/translates/{language.Id}/translate.json" download>Скачать перевод</a>
    <PrimaryTextarea bind:value={newTranslate} title="Новый перевод"/>
    <button class="max-w-48 px-5 border-2 bg-green-500 border-green-500 rounded min-w-44
  text-nowrap text-(--color-primary) transition-colors hover:bg-(--color-primary) hover:text-white
  min-h-9 text-sm" onclick={() => updateTranslate(newTranslate)}>Отправить перевод</button>
  </QuaternarySection>
</SecondaryPage>