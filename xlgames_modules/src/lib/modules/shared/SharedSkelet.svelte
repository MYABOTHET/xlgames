<script>
  import Information from "../../presets/shared/Information.svelte";
  import AvailableOS from "../../components/shared/AvailableOS.svelte";
  import VerticalLine from "../../components/shared/VerticalLine.svelte";
  import HorizontalLine from "../../components/shared/HorizontalLine.svelte";
  import Controls from "../../presets/shared/Controls.svelte";

  let {
    information,
    on,
    off,
    reboot,
    reinstall_os,
    loading_control,
    os = $bindable(),
    children,
    ...props
  } = $props();
</script>

<section {...props} class="{props.class} flex flex-col gap-6 p-2">
  <section class="flex items-stretch" style="gap: inherit">
    <Controls {loading_control} {off} {on} {reboot} status={information.status}/>
    <VerticalLine/>
    <Information ip={information.ip} login={information.login} os={information.os}
                 password={information.password}/>
    {#if information.available_os.length}
      <div style="display: inherit; gap: inherit; align-items: inherit;" class="ml-auto">
        <VerticalLine/>
        <AvailableOS {loading_control} available_os={information.available_os} {reinstall_os} bind:os/>
      </div>
    {/if}
  </section>
  {#if children}
    <HorizontalLine/>
    {@render children()}
  {/if}
</section>