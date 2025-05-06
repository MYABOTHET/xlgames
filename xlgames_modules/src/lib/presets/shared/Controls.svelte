<script>
  import ButtonPowerGreen from "../buttons/ButtonPowerGreen.svelte";
  import ButtonPowerRed from "../buttons/ButtonPowerRed.svelte";
  import ButtonReboot from "../buttons/ButtonReboot.svelte";

  let {on, off, reboot, status, loading_control, ...props} = $props();
</script>

<section {...props} class="{props.class} flex flex-col justify-between">
  {#if on}
    <ButtonPowerGreen onclick={on} status={status || loading_control}/>
  {/if}
  {#if off}
    <ButtonPowerRed onclick={off} status={!status || loading_control}/>
  {/if}
  {#if reboot}
    <ButtonReboot onclick={reboot} status={!status || loading_control}/>
  {/if}
</section>