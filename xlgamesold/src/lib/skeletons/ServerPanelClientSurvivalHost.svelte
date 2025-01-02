<script>
  import Section from "../components/Section.svelte";
  import Button from "../components/Button.svelte";
  import Select from "../components/Select.svelte";
  import FreezeScreen from "../components/FreezeScreen.svelte";
  import Load from "./components/Load.svelte";
  import Confirm from "./components/Confirm.svelte";
  import SystemSurvival from "./SurvivalHost/SystemSurvival.svelte";
  import NetworkStatistics from "../components/NetworkStatistics.svelte";
  
  let {
    language,
    loading,
    loading_message,
    have_error,
    error_message,
    success_message,
    info,
    on,
    off,
    reboot,
    network_statistics,
    current_date,
    date_next,
    date_back,
    can_next,
    can_back,
    current_os,
    list_os,
    select_os,
    reinstall,
    have_confirm,
    close,
    open,
    light
  } = $props();
</script>

<FreezeScreen freeze={have_confirm || have_error || loading}>
  <div class="flex flex-col gap-5">
    <SystemSurvival {language} system={info} {off} {on} {reboot}/>
    <Section title={language.reinstall_os_title}>
      <div class="flex flex-col gap-2">
        <Select {light} method={select_os} value={current_os} items={list_os}/>
        <Button onclick={open} class="w-full" color="sky">{language.reinstall}</Button>
      </div>
    </Section>
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
        <div class="relative overflow-auto {light ? 'network' : ''}">
          {@html network_statistics}
        </div>
      </div>
    </Section>
  </div>
  {#snippet modal()}
  {#if have_confirm}
    <Confirm {light} {close} {reinstall} {language}/>
  {/if}
  {#if have_error}
    <span class="text-red-500 text-center">{error_message}</span>
  {/if}
  {#if loading}
    <Load {loading_message}/>
  {/if}
  {/snippet}
</FreezeScreen>

<style lang="postcss">
  .network :global {
    use {
      fill: theme(colors.gray.300);
    }
  }
</style>