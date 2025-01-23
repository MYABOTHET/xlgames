<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  
  const {data} = $props();
</script>

<SecondaryPage title="Данные проекта">
  <QuaternarySection title="Общие">
    <div class="flex flex-col gap-y-4 text-sm">
      <input placeholder="Проверка..." spellcheck="false" autocomplete="off"
             class="placeholder-quaternary outline-none bg-secondary px-3.5 py-2 min-w-0 max-w-56 w-full">
      <input placeholder="Проверка..." spellcheck="false" autocomplete="off"
             class="placeholder-quaternary outline-none bg-secondary px-3.5 py-2 min-w-0 max-w-56 w-full">
    </div>
  </QuaternarySection>
</SecondaryPage>