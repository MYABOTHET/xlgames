<script>
  let {value = $bindable(), ...props} = $props();
</script>

<input bind:value {...props} class="{props.class} placeholder-slate-400 outline-none text-center caret-slate-800
bg-transparent" style="field-sizing: content">

<style>
  input::-webkit-outer-spin-button, input::-webkit-inner-spin-button {
    -webkit-appearance: none;
    margin: 0;
  }
  
  input[type="number"] {
    -moz-appearance: textfield;
  }
</style>