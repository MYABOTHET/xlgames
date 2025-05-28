<script>
  let {title, ...props} = $props();
</script>

<button {...props}
        class="{props.class}  transition-all hover:bg-[#1f242e] z-0 py-3 px-6 border-gray-700/90 border-dotted border">
  <span class="truncate">{title}</span></button>