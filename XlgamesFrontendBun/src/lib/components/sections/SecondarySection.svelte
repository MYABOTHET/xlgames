<script>
  import TernaryCard from "$lib/components/cards/TernaryCard.svelte";
  
  const {items, ...props} = $props();
</script>

<section {...props} class="{props.class} gap-y-5 flex flex-col">
  {#each items as item, index}
    <TernaryCard name={item.Name} description={item.Description}/>
    {#if items.length - 1 !== index}
      <div class="primary-line"></div>
    {/if}
  {/each}
</section>