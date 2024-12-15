<script>
  import {page} from '$app/stores';
</script>

<article class="flex justify-center max-[430px]:flex-col items-center h-full font-semibold gap-x-2 gap-y-3">
  <h1 class="text-7xl">{$page.status}</h1>
  <h1 class="text-5xl max-[430px]:hidden">|</h1>
  <h1 class="text-4xl">{$page.error.message}</h1>
</article>