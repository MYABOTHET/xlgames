<script>
  import PrimaryCheckbox from "$lib/components/checkbox/PrimaryCheckbox.svelte";
  
  let {value = $bindable(), title, children, off = () => {}, ...props} = $props();
  
  let visible = $derived(value);
  
  $effect(() => {
    value ? '' : off();
  });
</script>

<div class="flex flex-col gap-y-4">
  <PrimaryCheckbox bind:value {title}/>
  <div class="flex flex-col gap-y-[inherit] {visible ? '' : 'pointer-events-none opacity-35'}">
    {@render children?.()}
  </div>
</div>