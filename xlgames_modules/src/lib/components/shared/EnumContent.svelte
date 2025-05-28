<script>
  import ButtonCopy from "../../presets/buttons/ButtonCopy.svelte";
  import {fade} from "svelte/transition";

  let {content} = $props();

  let showCopy = $state(false);
  let timeout = $state();
  let hoverCopy = $state(false);
</script>

<svelte:document onclick={() => {
  if (!hoverCopy) {
    if (timeout) clearTimeout(timeout);
    showCopy = false;
  }
}}></svelte:document>

<div class="flex gap-3 flex-nowrap items-center">
  <h1 class="break-all">{content}</h1>
  <div transition:fade={{duration: 50}} class="flex items-center justify-center relative">
    <ButtonCopy onclick={() => {navigator.clipboard.writeText(content);
    showCopy = true;
    if (timeout) clearTimeout(timeout);
    timeout = setTimeout(() => {showCopy = false}, 2000)}}
                onmouseover={() => {hoverCopy = true}} onmouseout={() => {hoverCopy = false}}/>
    {#if showCopy}
      <div
        class="flex items-center flex-nowrap justify-center ml-2 absolute left-full z-50 mb-0.5">
        <div style="clip-path: polygon(50% 0%, 0% 100%, 100% 100%);" class="-rotate-90 size-3 relative
      bg-gray-700 right-[-1px]"></div>
        <div class="text-lg bg-gray-700 px-4 py-1 rounded-sm">{language.copy}</div>
      </div>
    {/if}
  </div>
</div>