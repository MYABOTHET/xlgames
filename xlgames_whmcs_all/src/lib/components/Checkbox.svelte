<script>
  let {checked = $bindable(), ...props} = $props();
</script>

<input {...props} bind:checked type="checkbox" class="{props.class} accent-slate-800 size-6 relative top-0.5">