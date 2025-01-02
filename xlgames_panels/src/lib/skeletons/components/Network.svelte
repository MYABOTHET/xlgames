<script>
  import NetworkStatistics from "../../components/NetworkStatistics.svelte";
  import Button from "../../components/Button.svelte";
  import Section from "../../components/Section.svelte";
  
  let {
    language,
    network_statistics,
    date_next,
    date_back,
    current_date,
    can_back,
    can_next,
    light
  } = $props();
</script>

<Section title={language.network_statistics_title}>
  <div class="flex flex-col gap-1">
    <div class="flex justify-end items-center gap-2 max-sm:flex-col">
      <div>{current_date}</div>
      <Button onclick={date_back} color={light ? 'white' : 'black'}
              class="w-24 max-sm:w-full select-none {can_back ? '' : 'opacity-30 pointer-events-none'}"
      >{language.back}</Button>
      <Button onclick={date_next} color={light ? 'white' : 'black'}
              class="w-24 max-sm:w-full select-none {can_next ? '' : 'opacity-30 pointer-events-none'}"
      >{language.next}</Button>
    </div>
    <NetworkStatistics {light} {network_statistics} {language}/>
  </div>
</Section>