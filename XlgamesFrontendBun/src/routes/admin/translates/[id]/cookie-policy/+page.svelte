<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";
  
  let language = getContext("language")();
</script>

<SecondaryPage title="Общий перевод">
  <QuaternarySection title="...">
    <PrimaryTextarea bind:value={language.Name} title="..."/>
  </QuaternarySection>
</SecondaryPage>