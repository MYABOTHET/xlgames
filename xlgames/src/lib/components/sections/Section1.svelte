<script>
  import Link2 from "$lib/components/links/Link2.svelte";
  
  let {children, ...props} = $props();
</script>

<section {...props} class="{props.class}">
  <div class="flex justify-between items-end mb-8">
    <h1 class="text-[28px] leading-8 font-semibold">Игровые серверы</h1>
    <Link2 href="/">Ещё</Link2>
  </div>
  {@render children?.()}
</section>