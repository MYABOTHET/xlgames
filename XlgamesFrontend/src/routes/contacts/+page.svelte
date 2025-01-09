<script>
  import {getContext} from "svelte";
  import TernarySection from "$lib/components/sections/TernarySection.svelte";
  
  const {data} = $props();
  const {projectData} = data;
  
  let language = $derived(getContext("language")());
</script>

<svelte:head>
  <title>{language.Contacts.Title} - {data.projectData.Name}</title>
  {@html language.Contacts.Head}
</svelte:head>

{#snippet contact(title, description)}
<article class="flex">
  <h1 class="text-nowrap h-fit mt-auto">{title}:</h1>
  <div class="min-w-4 relative -top-1 ml-1.5 mr-2 border-b border-b-quaternary border-dotted flex-1"></div>
  <p class="break-all">{description}</p>
</article>
{/snippet}

<div class="max-w-screen-hexadecimal w-full mx-auto">
  <article class="w-full flex flex-col ternary-gap-y">
    <h1 class="primary-title">{language.Contacts.Name}</h1>
    <p>{language.Contacts.Description}</p>
    
    <section class="flex flex-col gap-y-3.5">
      {@render contact?.("ИП", "Лёвин Валерий Дмитриевич")}
      {@render contact?.("ИП", "Лёвин Валерий Дмитриевич")}
      {@render contact?.("ИП", "Лёвин Валерий Дмитриевич")}
      {@render contact?.("ИП", "Лёвин Валерий Дмитриевич")}
      {@render contact?.("ИП", "Лёвин Валерий Дмитриевич")}
    </section>
    
    <TernarySection {projectData} class="flex flex-wrap gap-2.5"/>
    <p>{language.Shared.AnyQuestionsStart}<a href="/store/contact.php" class="primary-link">{language.Shared.AnyQuestionsCenter}</a>{language.Shared.AnyQuestionsEnd}</p>
  </article>
</div>