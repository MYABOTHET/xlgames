<script>
  import Button from "./Button.svelte";
  
  let {
    on,
    off,
    reboot,
    language,
    state,
    ...props
  } = $props();
</script>

<div {...props} class="{props.class} flex flex-col gap-2">
  {#if state}
    <Button onclick={off} color="red" class="w-full">{language.off_control_panel}</Button>
    <Button onclick={reboot} color="yellow" class="w-full">{language.reboot_control_panel}</Button>
  {:else}
    <Button onclick={on} color="green" class="w-full">{language.on_control_panel}</Button>
  {/if}
</div>