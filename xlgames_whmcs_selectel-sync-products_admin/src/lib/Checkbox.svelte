<script>
  let { checked = $bindable(), ...props } = $props();
</script>

<input {...props} bind:checked class="{props.class} accent-slate-800 size-6 relative top-0.5 min-w-0"
       type="checkbox">