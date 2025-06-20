<script>
  import Section from "../components/Section.svelte";
  import Button from "../components/Button.svelte";
  import Select from "../components/Select.svelte";
  import FreezeScreen from "../components/FreezeScreen.svelte";
  import Load from "./components/Load.svelte";
  import NetworkStatisticsReliable from "./reliable/NetworkStatisticsReliable.svelte";
  import SystemReliable from "./reliable/SystemReliable.svelte";
  import ConfirmReliable from "./reliable/ConfirmReliable.svelte";
  import SelectReliable from "./reliable/SelectReliable.svelte";
  
  let {
    language,
    loading,
    loading_message,
    have_error,
    error_message,
    info,
    on,
    off,
    network_statistics,
    current_os,
    list_os,
    select_os,
    reinstall,
    have_confirm,
    close,
    open,
    light,
    select_time,
    current_time,
    list_time,
    key = $bindable()
  } = $props();
</script>

<FreezeScreen freeze={have_confirm || have_error || loading}>
  <div class="flex flex-col gap-5 bg-[var(--color-xlgames-dark-400)] px-5 pt-4 pb-5">
    <SystemReliable {language} system={info} {off} {on}/>
    <Section title={language.reinstall_os_title}>
      <div class="flex flex-col gap-2">
        <Select {light} method={select_os} value={current_os} items={list_os}/>
        <Button onclick={open} class="w-full" color="sky">{language.reinstall}</Button>
      </div>
    </Section>
    {#if network_statistics.item_count}
      <Section title={language.network_statistics_title}>
        <SelectReliable class="w-40 ml-auto mb-1" {language} {light} method={select_time} value={current_time} items={list_time}/>
        <NetworkStatisticsReliable {current_time} {light} {network_statistics} {language}/>
      </Section>
    {/if}
  </div>
  {#snippet modal()}
  {#if have_confirm}
    <ConfirmReliable bind:key {light} {close} {reinstall} {language}/>
  {/if}
  {#if have_error}
    <span class="text-red-500 text-center">{error_message}</span>
  {/if}
  {#if loading}
    <Load {loading_message}/>
  {/if}
  {/snippet}
</FreezeScreen>
<div class="min-h-8"></div>