<script>
  import Load from "$lib/components/icons/svg/Load.svelte";
  
  let {...props} = $props();
  let opacity = $state(true);
  let success = $state(false);
  
  function success_img() {
    opacity = false;
    success = true;
  }
</script>

<a {...props} aria-label="minecraft"
   class="{props.class} hover:border-xlgames-3 border-2 transition-colors duration-200
    border-transparent relative rounded-2xl overflow-hidden min-h-[268px] min-w-[368px]">
  <article class="w-full h-full">
    <img alt=""
         class="{opacity ? 'opacity-0' : 'opacity-100'} absolute
          -z-20 saturate-[.65] brightness-[.70] h-full w-full object-cover"
         onload={success_img} src="farm.jpg"/>
    {#if !success}
      <div class="w-full h-full -z-30 flex absolute justify-center items-center">
        <Load class="h-6 fill-xlgames-2"/>
      </div>
    {/if}
    <article class="flex flex-col w-full h-full justify-end p-4 flex-nowrap">
      <h1 class="font-medium text-shadow-custom truncate">Minecraft</h1>
      <h2 class="text-shadow-custom truncate">От ₽880</h2>
    </article>
  </article>
</a>

<style lang="postcss">
  .text-shadow-custom {
    text-shadow: 1px 1px rgba(0, 0, 0, 0.75);
  }
</style>