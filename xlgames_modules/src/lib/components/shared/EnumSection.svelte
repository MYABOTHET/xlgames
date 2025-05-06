<script>
  let {children, ...props} = $props();
</script>

<section {...props}
         class="{props.class} grid grid-cols-[auto_auto] has-[h1]:text-left gap-y-1.5 gap-x-4 h-fit text-white">
  {@render children?.()}
</section>