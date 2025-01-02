<script>
  import Link2 from "$lib/components/links/Link2.svelte";
  import Title1 from "$lib/components/titles/Title1.svelte";
  
  let {children, title, more, href, ...props} = $props();
</script>

<section {...props} class="{props.class}">
  <div class="flex justify-between items-end mb-8">
    <Title1>{title}</Title1>
    <Link2 {href}>{more}</Link2>
  </div>
  {@render children?.()}
</section>