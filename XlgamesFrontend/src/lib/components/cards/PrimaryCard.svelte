<script>
  const {src, name, description, ...props} = $props();
</script>

<a {...props} class="{props.class} ternary-block relative">
  <img {src} alt={name} class="ternary-size primary-filter"/>
  <article class="absolute top-0 left-0 p-4 flex flex-col justify-end size-full gap-y-1">
    <h1 class="primary-text-shadow truncate font-medium">{name}</h1>
    <p class="primary-text-shadow truncate text-sm">{description}</p>
  </article>
</a>