<script>
  import PrimaryInput from "./PrimaryInput.svelte";
  
  let {value = $bindable(), ...props} = $props();
</script>

<PrimaryInput bind:value {...props} class="{props.class} border-indigo-500 placeholder-indigo-300 text-indigo-500"/>