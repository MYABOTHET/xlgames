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
    <h1 class="text-nowrap h-fit">{title}</h1>
    <div class="min-w-4 flex-1 secondary-line"></div>
    <address class="break-all not-italic">{description}</address>
  </article>
{/snippet}

<div class="max-w-(--breakpoint-hexadecimal) w-full mx-auto">
  <article class="secondary-section">
    <h1 class="primary-title">{language.Contacts.Name}</h1>
    <p>{language.Contacts.Description}</p>
    {#if true}
      <section class="flex flex-col gap-y-1">
        {#if language.Shared.IP}{@render contact?.(language.Contacts.IP, language.Contacts.FullName)}{/if}
        {#if language.Shared.Email}{@render contact?.(language.Contacts.Email, projectData.Email)}{/if}
        {#if language.Shared.PhoneNumber}{@render contact?.(language.Contacts.PhoneNumber, projectData.PhoneNumber)}{/if}
        {#if language.Shared.INN}{@render contact?.(language.Contacts.INN, projectData.INN)}{/if}
        {#if language.Shared.OGRNIP}{@render contact?.(language.Contacts.OGRNIP, projectData.OGRNIP)}{/if}
      </section>
    {/if}
    <TernarySection class="flex flex-wrap gap-2.5"/>
    <p>{language.Shared.AnyQuestionsStart}<a class="primary-link" href={projectData.Contacts}
                                             rel="nofollow">{language.Shared.AnyQuestionsCenter}</a>{language.Shared.AnyQuestionsEnd}
    </p>
  </article>
</div>