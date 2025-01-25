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
  <button class="{isActive ? 'border-(--color-ternary) text-(--color-ternary) fill-(--color-ternary)'
    : 'border-(--color-quaternary) text-(--color-quaternary) fill-(--color-quaternary)'} w-full hover:bg-(--color-secondary) overflow-hidden
    border-2 px-6 py-2.5 rounded-full text-left transition-colors flex items-center justify-between gap-x-4
{currentItem ? 'text-(--color-ternary) border-(--color-ternary) fill-(--color-ternary)' : ''}" onblur={blur} onclick={toggle} onfocus={focus} onmouseout={blur} onmouseover={focus}>
    {currentItem ? currentItem : defaultItem}
    <PrimaryArrow class="min-w-3 max-w-3 transition-transform {isActive ? '' : 'rotate-180'}"/>
  </button>
  {#if isActive}
    <div transition:fade={{duration: 75}} class="absolute mt-2.5 w-full z-10">
      <PrimaryTriangle class="z-5 primary-triangle-center secondary-width fill-(--color-ternary) relative top-px"/>
      <div class="relative flex justify-center items-center">
        <div
            class="relative z-5 overflow-y-scroll border-2 w-full border-(--color-ternary) bg-(--color-primary) overflow-hidden max-h-44 scroll rounded-2xl">
          <button onclick={() => {select(null)}} class="transition-colors hover:bg-(--color-secondary) w-full text-left px-6 py-3
hover:text-(--color-ternary) {currentItem ? '' : 'text-(--color-ternary)'}">{defaultItem}</button>
          {#each items as item}
            <button onclick={() => {select(item)}} class="transition-colors hover:bg-(--color-secondary) w-full text-left
               px-6 py-3 hover:text-(--color-ternary) {currentItem === item ? 'text-(--color-ternary)' : ''}">{item}</button>
          {/each}
        </div>
        <div class="z-3 absolute w-full h-full box-content rounded-[19px] border-[3px] border-(--color-primary)"></div>
      </div>
    </div>
  {/if}
</div>

<style>
  @reference "tailwindcss/theme";
  
  .scroll::-webkit-scrollbar {
    @apply w-0;
  }
</style>