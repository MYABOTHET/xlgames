<script>
  import SecondaryArrow from "$lib/components/svg/SecondaryArrow.svelte";
  
  const {name, description, href, ...props} = $props();
</script>

<article {...props} class="{props.class} ternary-p flex flex-col secondary-gap-y
primary-block primary-bg border-(--color-quaternary)">
  <h1 class="primary-title">{name}</h1>
  <p>{description}</p>
  <a aria-label="Link" class="quaternary-block flex-center size-12 fill-(--color-primary) hover:fill-white mt-auto" {href}>
    <SecondaryArrow class="rotate-90 size-3"/>
  </a>
</article>