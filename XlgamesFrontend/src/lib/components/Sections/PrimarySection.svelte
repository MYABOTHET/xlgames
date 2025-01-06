<script>
  import PrimaryTitle from "$lib/components/Titles/PrimaryTitle.svelte";
  import {getContext} from "svelte";
  import SecondaryLink from "$lib/components/Links/SecondaryLink.svelte";
  
  const {children, title, href, ...props} = $props();
  
  const language = $derived(getContext('language')());
</script>

<div {...props} class="{props.class} primary-gap-y flex flex-col">
  <div class="flex justify-between items-end text-nowrap">
    <PrimaryTitle>{title}</PrimaryTitle>
    <SecondaryLink class="relative bottom-[1px]" {href}>{language["Shared"]["More"]}</SecondaryLink>
  </div>
  {@render children?.()}
</div>