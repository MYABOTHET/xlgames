<script>
  import { page } from '$app/state';
</script>

<article class="flex-center h-full">
  <h1 class="text-(--color-quaternary) text-4xl font-medium">
    Ошибка | {page.status}
  </h1>
</article>