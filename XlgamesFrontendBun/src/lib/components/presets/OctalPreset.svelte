<script>
  import PrimaryArrow from "$lib/components/svg/PrimaryArrow.svelte";
  
  let {children, index, up, down, deleteItem, length, ...props} = $props();
  
  let counter = $state(3);
  
  function del() {
    counter--;
    if (counter < 1) {
      deleteItem(index);
      counter = 3;
    }
  }
</script>

<div {...props} class="{props.class} flex flex-col gap-y-[inherit] border border-(--color-hexadecimal)
w-fit max-w-full px-5 py-4">
  {@render children?.()}
  <div class="flex gap-x-2">
    {#if index !== 0}
      <button onclick={() => {up(index)}} class="border border-(--color-hexadecimal) h-8 w-12 rounded-full flex items-center
    justify-center transition-colors hover:bg-(--color-quaternary)/10">
        <PrimaryArrow class="min-w-3 max-w-3 fill-(--color-quaternary)"/>
      </button>
    {/if}
    {#if index !== length - 1}
      <button onclick={() => {down(index)}} class="border border-(--color-hexadecimal) h-8 w-12 rounded-full flex items-center
    justify-center transition-colors hover:bg-(--color-quaternary)/10">
        <PrimaryArrow class="min-w-3 max-w-3 fill-(--color-quaternary) rotate-180"/>
      </button>
    {/if}
    <button class="font-normal border border-(--color-hexadecimal) h-8 w-32 rounded-full flex items-center
    justify-center transition-colors hover:bg-(--color-quaternary)/10 text-(--color-quaternary)" onclick={del}>
      <span>Удалить ({counter})</span>
    </button>
  </div>
</div>