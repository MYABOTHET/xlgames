<script>
  import Link3 from "$lib/components/links/Link3.svelte";
  import Title1 from "$lib/components/titles/Title1.svelte";
  
  let {title, description, href, ...props} = $props();
</script>

<div {...props}
     class="{props.class} hover:bg-xlgames-2 transition-colors border-2
      border-xlgames-4 rounded-2xl px-8 pt-8 pb-6 flex flex-col justify-between gap-y-6">
  <article class="flex flex-col gap-y-8">
    <Title1>{title}</Title1>
    <p>{description}</p>
  </article>
  <Link3 {href}/>
</div>