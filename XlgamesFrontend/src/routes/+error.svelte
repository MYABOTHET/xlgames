<script>
  import { page } from '$app/state';
</script>

<article class="flex-center h-full">
  <h1 class="primary-title">{page.status}: {page.error.message}</h1>
</article>