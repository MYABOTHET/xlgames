<script>
  import {page} from '$app/state';
</script>

<article class="flex-center h-full mx-auto">
  <h1 class="text-(--color-quaternary) text-4xl font-medium mx-auto">
    {page.error.message} | {page.status}
  </h1>
</article>