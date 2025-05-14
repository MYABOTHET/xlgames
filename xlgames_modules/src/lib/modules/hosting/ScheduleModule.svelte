<script>
  import Schedule from "../../components/shared/Schedule.svelte";
  import ButtonActive from "../../components/buttons/ButtonActive.svelte";

  let periods = Object.keys(information.network);
  let period = $state(periods[0]);
  let points = $derived(information.network[period].content);
</script>

{#if periods.length > 1}
  <section class="flex text-[15px]" style="gap: inherit">
    {#each periods as item}
      <ButtonActive active={period === item} onclick={() => {period = item}}
                    title={information.network[item].title}/>
    {/each}
  </section>
{/if}
<Schedule {points}/>