<script>
  let {title, description, border, ...props} = $props();
</script>

<div {...props} class="flex flex-col gap-y-0.5">
  <h1 class="font-semibold text-xlgames-3">{title}</h1>
  <p class="text-[15px] leading-[22px]">{description}</p>
</div>
{#if border}
  <div class="border-b border-xlgames-2 w-full"></div>
{/if}