<script>
  const {name, logo, ...props} = $props();
</script>

<!-- 0.03125rem - 0.5px -->
<article {...props} class="{props.class} flex-center gap-x-4 font-medium">
  <h1 class="order-2 relative top-[0.03125rem]">{name}</h1>
  <div class="order-1 secondary-block primary-size border-ternary flex-center">
    <h1 class="relative left-[0.03125rem] top-[0.03125rem]">{logo}</h1>
  </div>
</article>