<script>
  import {getContext} from "svelte";
  import PrimaryInfo from "$lib/components/svg/PrimaryInfo.svelte";
  import TernarySection from "$lib/components/sections/TernarySection.svelte";
  import PrimaryEmail from "$lib/components/svg/PrimaryEmail.svelte";
  import TernaryIcon from "$lib/components/icons/TernaryIcon.svelte";
  
  let props = $props();
  
  let language = $derived(getContext("language")());
</script>

<div {...props} class="{props.class} mx-auto border-(--color-ternary) px-7 py-6 border-2 overflow-hidden rounded-2xl
flex flex-col gap-5 justify-center items-center max-w-2xl">
  <div class="flex gap-6 justify-center items-center">
    <PrimaryInfo class="min-w-12 max-w-12"/>
    <h1>{language.Shared.HelpMessage}</h1>
  </div>
  <TernarySection IconPreset={TernaryIcon} class="flex flex-wrap gap-2.5 justify-center items-center" icons={[{
    Icon: PrimaryEmail,
    name: "Email",
    link: "/store/contact.php",
  }]} iconClass="fill-(--color-ternary)"/>
</div>