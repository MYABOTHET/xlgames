<script>
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import SaveForm from "$lib/components/SaveForm.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";
  import HexadecimalPreset from "$lib/components/presets/HexadecimalPreset.svelte";
  import {page} from "$app/state";
  import PrimaryCheckbox from "$lib/components/checkbox/PrimaryCheckbox.svelte";
  
  let {data} = $props();
  
  let gameServer = getContext("gameServer")();
  let translate = $state(data.translate);
  let access = $state(null);
  let error = $state(null);
  let init = $state.raw({init: false});
  let timeout = $state(null);
  
  $effect(() => {
    data.translate;
    if (init.init) {
      translate = data.translate;
      access = null;
      error = null;
    } else {
      init.init = true;
    }
  });
  
  async function updateGameServerData() {
    clearTimeout(timeout);
    access = null;
    error = null;
    const response = await fetch(`/admin/game-servers/${page.params.id}/${page.params.translateId}`, {
      method: "PUT",
      body: JSON.stringify(translate),
      headers: {
        'Content-Type': 'application/json'
      }
    });
    if (response.status === 200) {
      access = true;
    } else {
      access = false;
      error = await response.text();
    }
    timeout = setTimeout(() => {
      access = null;
      error = null;
    }, 5000);
  }
</script>

<SecondaryPage title="Перевод игрового сервера «{gameServer.Name}» на «{data.languageList
    .find(language => language.Id === translate.LanguageId).Name}» языке">
  <QuaternarySection title="Данные">
    <PrimaryTextarea bind:value={translate.Head} title="Метаданные"/>
    <PrimaryTextarea bind:value={translate.Price} title="Цена"/>
    <PrimaryTextarea bind:value={translate.Description} title="Описание"/>
    <HexadecimalPreset bind:list={translate.GameServerDataPoints} title="Перечисление"/>
  </QuaternarySection>
  <QuaternarySection title="Страны и континенты">
    <PrimaryCheckbox bind:value={translate.Germany} title="Германия"/>
    <PrimaryCheckbox bind:value={translate.Finland} title="Финляндия"/>
    <PrimaryCheckbox bind:value={translate.Russia} title="Россия"/>
    <PrimaryCheckbox bind:value={translate.USA} title="США"/>
    <PrimaryCheckbox bind:value={translate.Singapore} title="Сингапур"/>
    <PrimaryCheckbox bind:value={translate.France} title="Франция"/>
    <PrimaryCheckbox bind:value={translate.UnitedKingdom} title="Великобритания"/>
    <PrimaryCheckbox bind:value={translate.Poland} title="Польша"/>
    <PrimaryCheckbox bind:value={translate.Canada} title="Канада"/>
    <PrimaryCheckbox bind:value={translate.Europe} title="Европа"/>
  </QuaternarySection>
  <SaveForm {access} {error} onclick={updateGameServerData}/>
</SecondaryPage>