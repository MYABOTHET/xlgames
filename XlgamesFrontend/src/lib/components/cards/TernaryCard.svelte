<script>
  const {name, description, ...props} = $props();
</script>

<article {...props} class="{props.class} flex flex-col gap-y-1.5">
  <h1 class="font-medium text-ternary">{name}</h1>
  <p>{description}</p>
</article>