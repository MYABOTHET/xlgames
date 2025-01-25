<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import SaveForm from "$lib/components/SaveForm.svelte";
  import {getContext} from "svelte";
  
  let language = getContext("language")();
  let access = getContext("access");
  let error = getContext("error");
  let updateLanguage = getContext("updateLanguage");
</script>

<SecondaryPage title="Общий перевод">
  <QuaternarySection title="...">
    <PrimaryTextarea bind:value={language.Name} title="..."/>
  </QuaternarySection>
  <SaveForm error={error()} access={access()} onclick={updateLanguage}/>
</SecondaryPage>