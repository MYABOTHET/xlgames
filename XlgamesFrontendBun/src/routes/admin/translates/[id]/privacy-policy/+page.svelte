<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";
  import QuinaryPreset from "$lib/components/presets/QuinaryPreset.svelte";
  
  let language = getContext("language")();
</script>

<SecondaryPage title="Политика конфиденциальности">
  <QuaternarySection title="Важное">
    <PrimaryTextarea bind:value={language.PrivacyPolicy.Title} title="Название страницы"/>
    <PrimaryTextarea bind:value={language.PrivacyPolicy.Head} title="Метаданные"/>
  </QuaternarySection>
  <QuaternarySection title="Остальное">
    <PrimaryTextarea bind:value={language.PrivacyPolicy.Name} title="Заголовок"/>
    <PrimaryTextarea bind:value={language.PrivacyPolicy.Description} title="Описание"/>
    <QuinaryPreset bind:list={language.PrivacyPolicy.PrivacyPolicyCollection} title="Перечисление"/>
  </QuaternarySection>
</SecondaryPage>