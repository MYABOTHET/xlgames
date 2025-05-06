<script>
  import Button from "../../presets/buttons/Button.svelte";

  let {active, ...props} = $props();
</script>

<Button {...props} class="{props.class} {active ? '' : 'text-gray-500'}"/>