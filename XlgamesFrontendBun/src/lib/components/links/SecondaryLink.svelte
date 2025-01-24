<script>
  import PrimaryArrow from "$lib/components/svg/PrimaryArrow.svelte";
  const {name, ...props} = $props();
</script>

<a {...props} class="{props.class} flex-center transition-colors gap-x-6 text-white fill-white
hover:text-(--color-ternary) hover:fill-(--color-ternary) w-fit">
  <h1 class="order-2 primary-title">{name}</h1>
  <PrimaryArrow class="ternary-width -rotate-90 order-1"/>
</a>