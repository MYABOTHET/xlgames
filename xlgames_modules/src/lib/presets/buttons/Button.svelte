<script>
  let {title, ...props} = $props();
</script>

<button {...props}
        class="{props.class} transition-all hover:bg-[#1f242e] z-0 w-full py-3 px-5 border-gray-700/90 border-dotted border truncate"
        title={title}>
  <span class="truncate">{title}</span></button>