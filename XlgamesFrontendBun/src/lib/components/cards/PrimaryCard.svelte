<script>
  const {src, name, description, ...props} = $props();
</script>

<a {...props} class="{props.class} ternary-block relative">
  <img {src} alt={name} class="ternary-size img-filter"/>
  <article class="absolute top-0 left-0 p-4 flex flex-col justify-end size-full gap-y-1">
    <h1 class="text-shadow truncate font-medium">{name}</h1>
    <p class="text-shadow truncate text-sm">{description}</p>
  </article>
</a>

<style lang="postcss">
  .text-shadow {
    text-shadow: 1px 1px rgba(0, 0, 0, 1);
  }
  .img-filter {
    @apply saturate-[.60] brightness-[.60];
  }
</style>