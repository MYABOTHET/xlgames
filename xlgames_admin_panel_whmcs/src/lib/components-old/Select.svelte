<script>
  import Button from "./Button.svelte";
  import Down from "./Down.svelte";
  
  let {
    value,
    items,
    method,
    ...props
  } = $props();
  
  let can_hidden = $state(true);
  let hidden = $state(true);
  
  function detect_can_hidden() {
    if (can_hidden) {
      hidden = true;
    }
  }
</script>

<svelte:window onclick={detect_can_hidden}></svelte:window>

<div {...props} class="{props.class} relative">
  <Button onmouseout={() => {can_hidden = true}} onmouseover={() => {can_hidden = false}}
          onclick={() => {hidden = !hidden}} color="sky"
          class="py-2 w-full {hidden ? '' : 'bg-sky-500 text-white stroke-white'} stroke-sky-500 hover:stroke-white">
    <div class="flex justify-center items-center gap-2 text-2xl">
      <span>{value}</span>
      <Down class="w-4"/>
    </div>
  </Button>
  {#if !hidden}
    <div class="flex flex-col rounded-lg border border-sky-500 text-sky-500 overflow-hidden top-full my-2 w-full
   absolute bg-white z-10">
      {#each items as item}
        <button onclick={() => {method(item); hidden = true}} class="hover:text-white hover:bg-sky-500 py-2 text-2xl bg-white">{item}</button>
      {/each}
    </div>
  {/if}
</div>