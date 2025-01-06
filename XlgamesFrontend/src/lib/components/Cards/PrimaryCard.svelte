<script>
  import PrimaryBlock from "$lib/components/Blocks/PrimaryBlock.svelte";
  
  let {src, alt, fetchpriority = 'auto', name, href, title, ...props} = $props();
</script>

<PrimaryBlock {...props} preset="ternary" class="{props.class} box-content">
  <a {href}>
    <div class="relative h-full w-full">
      <img {fetchpriority} {src} {alt} class="primary-img primary-filter absolute">
      <div class="flex flex-col relative p-4 justify-end h-full gap-y-1.5">
        <h1 class="font-[550] primary-text-shadow truncate">{name}</h1>
        <h1 class="text-sm primary-text-shadow truncate">{title}</h1>
      </div>
    </div>
  </a>
</PrimaryBlock>