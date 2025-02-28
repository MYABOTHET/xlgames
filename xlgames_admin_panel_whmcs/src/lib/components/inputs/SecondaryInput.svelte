<script>
  import PrimaryInput from "./PrimaryInput.svelte";
  
  let {value = $bindable(), ...props} = $props();
</script>

<PrimaryInput bind:value {...props} class="{props.class} border-sky-500 placeholder-sky-500 text-sky-500"/>