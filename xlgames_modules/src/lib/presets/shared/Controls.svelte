<script>
  import Button from "../buttons/Button.svelte";

  let {on, off, reboot, status, loading_control, ...props} = $props();
</script>

<section {...props} class="{props.class} flex flex-col text-[15px] gap-4">
  {#if on}
    <Button onclick={on} title={language.on}
    class="border-green-500! text-green-500! {((status !== '-') ? status : false) || loading_control
    ? 'opacity-40 pointer-events-none' : ''}"></Button>
  {/if}
  {#if off}
    <Button onclick={off} title={language.off}
    class="border-red-500! text-red-500! {((status !== '-') ? !status : false) || loading_control
    ? 'opacity-40 pointer-events-none' : ''}"></Button>
  {/if}
  {#if reboot}
    <Button onclick={reboot} title={language.reboot}
    class="border-yellow-400! text-yellow-400! {((status !== '-') ? !status : false) || loading_control
    ? 'opacity-40 pointer-events-none' : ''}"></Button>
  {/if}
</section>