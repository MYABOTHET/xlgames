<script>
  let { value = $bindable(), ...props } = $props();
</script>

<input {...props} bind:value
       class="{props.class} placeholder-slate-400 outline-none text-center
          caret-slate-800 max-w-48 bg-transparent" style="field-sizing: content;">

<style>
  input::-webkit-outer-spin-button, input::-webkit-inner-spin-button {
    -webkit-appearance: none;
    margin: 0;
  }
  
  input[type="number"] {
    -moz-appearance: textfield;
  }
</style>