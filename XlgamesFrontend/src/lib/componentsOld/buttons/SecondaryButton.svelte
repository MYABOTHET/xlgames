<script>
  import PrimaryArrow from "$lib/components/svg/PrimaryArrow.svelte";
  import PrimaryButton from "$lib/componentsOld/buttons/PrimaryButton.svelte";
  
  const {isActive, children, ...props} = $props();
</script>

<PrimaryButton {...props} {isActive}
               class="{props.class} {isActive ? 'fill-ternary text-ternary': 'fill-quaternary'} flex items-center
               justify-between gap-x-1">
  <h1>{@render children?.()}</h1>
  <PrimaryArrow class="ternary-width transition-transform {isActive ? '': 'rotate-180'}"/>
</PrimaryButton>