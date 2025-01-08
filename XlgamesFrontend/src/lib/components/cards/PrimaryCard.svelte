<script>
  const {src, name, description, ...props} = $props();
</script>

<a {...props} class="{props.class} ternary-block relative">
  <img {src} alt={name} class="absolute ternary-size primary-filter"/>
  <article class="relative p-4 flex flex-col justify-end size-full gap-y-1">
    <h1 class="primary-text-shadow truncate font-medium">{name}</h1>
    <p class="primary-text-shadow truncate text-sm">{description}</p>
  </article>
</a>