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
    <Button onclick={off} color="red" class="w-full">{language.control_panel.off}</Button>
    <Button onclick={reboot} color="yellow" class="w-full">{language.control_panel.reboot}</Button>
  {:else}
    <Button onclick={on} color="green" class="w-full">{language.control_panel.on}</Button>
  {/if}
</div>