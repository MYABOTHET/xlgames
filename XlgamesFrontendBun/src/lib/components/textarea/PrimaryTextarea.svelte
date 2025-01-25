<script>
  let {value = $bindable(), title, ...props} = $props();
</script>

<div  {...props} class="{props.class} flex gap-x-3">
  <textarea name={value} bind:value spellcheck="false" autocomplete="off" class="outline-none bg-(--color-octal)
      field-sizing-fixed px-3.5 py-2 w-xs resize rounded h-9 min-h-9 max-w-full min-w-20"></textarea>
  <span class="text-(--color-quaternary) py-2 font-normal text-nowrap">—</span>
  <h1 class="text-(--color-quaternary) py-2 font-normal text-nowrap">{title}</h1>
</div>

<style>
  @reference "tailwindcss/theme";
  
  textarea::-webkit-resizer {
    @apply bg-(--color-octal) bg-[url(/images/ugol.svg)] bg-no-repeat bg-right-bottom;
    background-size: 0.5rem;
  }
  
  textarea::-webkit-scrollbar {
    @apply w-2;
  }
  
  textarea::-webkit-scrollbar-track {
    @apply bg-transparent;
  }
  
  textarea::-webkit-scrollbar-thumb {
    @apply bg-(--color-quaternary) rounded-full;
  }
</style>