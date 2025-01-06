<script>
  import SecondaryBlock from "$lib/components/Blocks/SecondaryBlock.svelte";
  import SecondaryArrow from "$lib/components/Images/Svg/SecondaryArrow.svelte";
  import TernaryBlock from "$lib/components/Blocks/TernaryBlock.svelte";
  import PrimaryBlock from "$lib/components/Blocks/PrimaryBlock.svelte";
  import PrimaryTitle from "$lib/components/Titles/PrimaryTitle.svelte";
  
  let {name, description, href, ...props} = $props();
</script>

<PrimaryBlock {...props} preset="secondary" class="{props.class} flex-[1_1_100%] md:flex-[1_1_35%]
xlgames-primary:flex-[1_1_25%]">
  <SecondaryBlock class="w-full h-full">
    <article class="py-7 px-8 flex flex-col gap-y-7 h-full w-full">
      <PrimaryTitle>{name}</PrimaryTitle>
      <p>{description}</p>
      <TernaryBlock class="size-12 mt-auto *:hover:fill-white *:fill-xlgames-primary">
        <a {href} class="flex-center w-full h-full">
          <SecondaryArrow class="rotate-90 size-3"/>
        </a>
      </TernaryBlock>
    </article>
  </SecondaryBlock>
</PrimaryBlock>