<script>
  let {...props} = $props();
  let array = new Array(3);
</script>

<div {...props}
     class="{props.class} border-2
      border-xlgames-4 rounded-2xl px-8 py-4 flex flex-col gap-y-4">
  {#each array as _, index}
    <div class="flex flex-col gap-y-0.5">
      <h1 class="font-semibold text-xlgames-3">ММТС-9 Москва</h1>
      <p class="leading-5">Крупнейший центр обработки данных ММТС-9 в Москве. Здание оснащено современной инженерной
        инфраструктурой,
        в том числе системами бесперебойного электропитания, климатконтроля, газового пожаротушения, телемониторинга
        и видеонаблюдения.</p>
    </div>
    {#if index !== array.length - 1}
      <div class="border-b border-xlgames-2 w-full"></div>
    {/if}
  {/each}
</div>