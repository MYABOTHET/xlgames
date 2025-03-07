<script>
  import Button from "../../components/Button.svelte";
  
  let {
    on,
    off,
    language,
    ...props
  } = $props();
</script>

<div {...props} class="{props.class} flex flex-col gap-2">
  <Button onclick={off} color="red" class="w-full">{language.off_control_panel}</Button>
  <Button onclick={on} color="green" class="w-full">{language.on_control_panel}</Button>
</div>