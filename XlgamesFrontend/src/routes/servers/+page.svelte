<script>
  import {getContext} from "svelte";
  import SecondaryButton from "$lib/componentsOld/buttons/SecondaryButton.svelte";
  import PrimaryDropdownMenu from "$lib/components/dropdown-menus/PrimaryDropdownMenu.svelte";
  import PrimaryBlock from "$lib/components/blocks/PrimaryBlock.svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
</script>

<svelte:head>
  <title>{language.ServersWithoutGPU.Title} - {data.projectData.Name}</title>
  {@html language.ServersWithoutGPU.Head}
</svelte:head>

<article class="secondary-section">
  <h1 class="primary-title">{language.ServersWithoutGPU.Title}</h1>
  <p>{language.ServersWithoutGPU.Description}</p>
  <div class="flex flex-wrap gap-4">
    <PrimaryDropdownMenu class="septenary:hexadecimal-width w-full">
      {#snippet button(isMenuVisible)}
      <SecondaryButton isActive={isMenuVisible}>{language.Shared.AnyCPU}</SecondaryButton>
      {/snippet}
      <div class="primary-block-default border-ternary flex flex-col">
        <div class="primary-bg primary-p">a</div>
        <div class="primary-bg primary-p">b</div>
      </div>
    </PrimaryDropdownMenu>
  </div>
  <table>
    <thead>
    <tr>
      <th>syka</th>
    </tr>
    </thead>
    <tbody>
    <tr>
      <td>blyat</td>
    </tr>
    </tbody>
  </table>
</article>