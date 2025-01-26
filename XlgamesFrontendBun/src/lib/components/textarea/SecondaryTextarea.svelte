<script>
  let {value = $bindable(), title, ...props} = $props();
</script>

<textarea {...props} autocomplete="off" bind:value class="{props.class} outline-none bg-(--color-octal)
      field-sizing-fixed px-3.5 py-2 w-xs resize rounded h-9 min-h-9 max-w-full min-w-xs" name={title}
          spellcheck="false"></textarea>

<style>
  @reference "tailwindcss/theme";
  
  textarea {
    @apply font-light;
  }
  
  textarea::-webkit-resizer {
    @apply bg-(--color-octal) bg-[url(/assets/ugol.svg)] bg-no-repeat bg-right-bottom;
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