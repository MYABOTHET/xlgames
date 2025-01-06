<script>
  let {name, description, ...props} = $props();
</script>

<article {...props} class="{props.class} flex flex-col gap-y-1.5">
  <h1 class="font-[550] text-xlgames-ternary">{name}</h1>
  <p class="text-[15px]">{description}</p>
</article>