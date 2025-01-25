<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";
  import QuinaryPreset from "$lib/components/presets/QuinaryPreset.svelte";
  import TernaryPreset from "$lib/components/presets/TernaryPreset.svelte";
  
  let language = getContext("language")();
</script>

<SecondaryPage title="Политика «Cookie»">
  <QuaternarySection title="Важное">
    <PrimaryTextarea bind:value={language.CookiePolicy.Title} title="Название страницы"/>
    <PrimaryTextarea bind:value={language.CookiePolicy.Head} title="Метаданные"/>
  </QuaternarySection>
  <QuaternarySection title="Остальное">
    <PrimaryTextarea bind:value={language.CookiePolicy.Name} title="Заголовок"/>
    <PrimaryTextarea bind:value={language.CookiePolicy.Description} title="Описание"/>
    <TernaryPreset title="Банер" bind:object={language.CookiePolicy.CookiePolicyBanner}/>
    <QuinaryPreset bind:list={language.CookiePolicy.CookiePolicyCollection} title="Перечисление"/>
  </QuaternarySection>
</SecondaryPage>