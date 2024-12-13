<script>
  let {start, center, end, ...props} = $props();
</script>

<header {...props} class="{props.class} h-20 bg-xlgames-2 flex justify-center items-center">
  <div class="mx-4 max-w-screen-xlgames-1 w-full flex items-center flex-nowrap">
    <div class="flex-1 flex justify-start flex-nowrap">
      {@render start?.()}
    </div>
    <div class="flex justify-center flex-nowrap">
      {@render center?.()}
    </div>
    <div class="flex-1 flex justify-end flex-nowrap">
      {@render end?.()}
    </div>
  </div>
</header>