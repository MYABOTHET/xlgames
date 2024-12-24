<script>
  import Section from "../components/Section.svelte";
  import Network from "./components/Network.svelte";
  import System from "./components/System.svelte";
  import Button from "../components/Button.svelte";
  import Select from "../components/Select.svelte";
  import FreezeScreen from "../components/FreezeScreen.svelte";
  import Load from "./components/Load.svelte";
  import Confirm from "./components/Confirm.svelte";
  
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
    current_arch,
    current_version,
    list_os,
    list_arch,
    list_version,
    select_os,
    select_arch,
    select_version,
    reinstall,
    have_confirm,
    close,
    open
  } = $props();
</script>

<FreezeScreen freeze={have_confirm || have_error || loading}>
  <div class="flex flex-col gap-5">
    <System {language} system={info.system} {off} {on} {reboot}/>
    <Section title={language.reinstall_os_title}>
      <div class="flex flex-col gap-2">
        <Select method={select_os} value={current_os} items={list_os}/>
        <Select method={select_arch} value={current_arch} items={list_arch}/>
        <Select method={select_version} value={current_version} items={list_version}/>
        <Button onclick={open} class="w-full" color="sky">{language.reinstall}</Button>
      </div>
    </Section>
    <Network {network_statistics} {language} {can_next} {can_back} {date_next} {date_back} {current_date}/>
  </div>
  {#snippet modal()}
  {#if have_confirm}
    <Confirm {close} {reinstall} {language}/>
  {/if}
  {#if have_error}
    <span class="text-red-500 text-center">{error_message}</span>
  {/if}
  {#if loading}
    <Load {loading_message}/>
  {/if}
  {/snippet}
</FreezeScreen>