<script>
  import PrimaryArrow from "$lib/components/svg/PrimaryArrow.svelte";
  import {fade} from "svelte/transition";
  import PrimaryTriangle from "$lib/components/svg/PrimaryTriangle.svelte";
  
  let {currentItem, defaultItem, items, select, ...props} = $props();
  
  let isActive = $state(false);
  let isButtonFocused = $state(false);
  
  function toggle() {
    isActive ? close() : open();
  }
  
  function open() {
    isActive = true;
  }
  
  function close() {
    isActive = false;
  }
  
  function focus() {
    isButtonFocused = true;
  }
  
  function blur() {
    isButtonFocused = false;
  }
  
  function click() {
    if (!isButtonFocused) {
      isActive ? close() : '';
      isActive = false;
    }
  }
</script>

<svelte:window onclick={click}/>

<div {...props} class="{props.class} relative">
  <button onmouseout={blur} onmouseover={focus} onblur={blur} onfocus={focus} onclick={toggle} class="{isActive ? 'border-ternary text-ternary fill-ternary'
    : 'border-quaternary text-quaternary fill-quaternary'} w-full hover:bg-secondary overflow-hidden
    border-2 px-6 py-2.5 rounded-full text-left transition-colors flex items-center justify-between gap-x-4
{currentItem ? 'text-ternary border-ternary fill-ternary' : ''}">
    {currentItem ? currentItem : defaultItem}
    <PrimaryArrow class="min-w-3 max-w-3 transition-transform {isActive ? '' : 'rotate-180'}"/>
  </button>
  {#if isActive}
    <div transition:fade={{duration: 75}} class="absolute mt-2.5 w-full z-10">
      <PrimaryTriangle class="primary-triangle-center secondary-width fill-ternary relative top-px"/>
      <div
          class="overflow-y-scroll border-2 w-full border-ternary bg-primary overflow-hidden max-h-44 scroll rounded-2xl">
        <button onclick={() => {select(null)}} class="transition-colors hover:bg-secondary w-full text-left px-6 py-3
hover:text-ternary {currentItem ? '' : 'text-ternary'}">{defaultItem}</button>
        {#each items as item}
          <button onclick={() => {select(item)}} class="transition-colors hover:bg-secondary w-full text-left
               px-6 py-3 hover:text-ternary {currentItem === item ? 'text-ternary' : ''}">{item}</button>
        {/each}
      </div>
    </div>
  {/if}
</div>

<style lang="postcss">
  .scroll::-webkit-scrollbar {
    @apply w-0;
  }
</style>