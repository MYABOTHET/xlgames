<script>
  const {items, ...props} = $props();
</script>

<ul {...props} class="{props.class} primary-block py-7 px-8 flex flex-col gap-y-5 border-(--color-ternary) marker:text-(--color-ternary)
marker:text-lg">
  {#each items as item}
    <li class="flex items-center gap-x-7 whitespace-pre-line">
      <div class="min-w-1.5 min-h-1.5 bg-(--color-ternary) rounded-full"></div>{item}</li>
  {/each}
</ul>