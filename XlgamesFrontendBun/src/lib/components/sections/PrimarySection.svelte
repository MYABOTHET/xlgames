<script>
  import PrimaryArrow from "$lib/components/svg/PrimaryArrow.svelte";
  import {getContext} from "svelte";
  
  const {children, title, href, ...props} = $props();
  
  let language = $derived(getContext("language")());
</script>

<section {...props} class="{props.class} flex flex-col primary-gap-y">
  <article class="flex justify-between items-end">
    <h1 class="primary-title">{title}</h1>
    <a class="flex-center transition-colors gap-x-4 text-(--color-ternary) fill-(--color-ternary)
hover:text-white hover:fill-white relative -top-px" {href}>
      <h1>{language.Shared.More}</h1>
      <PrimaryArrow class="ternary-width rotate-90"/>
    </a>
  </article>
  {@render children?.()}
</section>