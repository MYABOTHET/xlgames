<script>
  import Schedule from "../../components/shared/Schedule.svelte";
  import ButtonActive from "../../components/buttons/ButtonActive.svelte";

  let periods = Object.keys(network ?? {});
  let period = $state(periods[0]);
  let points = $derived((network ?? {})[period]?.content);
</script>

{#if points}
  <div class="flex flex-col gap-6">
    {#if periods.length > 1}
      <section class="grid auto-cols-fr grid-flow-col gap-6 text-[15px]
max-[700px]:flex! max-[700px]:flex-col! max-[700px]:gap-y-4">
        {#each periods as item}
          <ButtonActive active={period === item} onclick={() => {period = item}}
                        title={network[item].title}/>
        {/each}
      </section>
    {/if}
    <Schedule {points}/>
  </div>
{:else}
  <h1 class="text-gray-600">(-_-)</h1>
{/if}