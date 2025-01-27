<script>
  import SaveForm from "$lib/components/SaveForm.svelte";
  
  let props = $props();
</script>

<div class="sticky bottom-0 px-4 py-3 bg-(--color-primary) border-t border-t-(--color-hexadecimal) w-full">
  <SaveForm {...props}/>
</div>