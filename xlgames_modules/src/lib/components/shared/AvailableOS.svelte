<script>
  import Arrow from "../svgs/Arrow.svelte";
  import Button from "../../presets/buttons/Button.svelte";
  import {fade} from "svelte/transition";

  let {os = $bindable(), available_os = [], reinstall_os, loading_control, ...props} = $props();

  let see = $state(false);
  let reinstallPanel = $state(false);
  let keyWord = $state("");
</script>

<section {...props}
         class="{props.class} text-[15px] grid grid-cols-2 text-nowrap gap-6
max-[700px]:flex! max-[700px]:flex-col max-[700px]:gap-y-4">
  <div class="relative">
    <button
      class="{loading_control ? 'opacity-40 pointer-events-none' : ''} hover:*:fill-white transition-all hover:bg-[#1f242e] w-full flex gap-6 items-center py-3 px-5 border-gray-700/90 border-dotted border"
      onclick={() => {see = !see}}
      title={os}>
      <span class="truncate flex-1">{os}</span>
      <Arrow class="fill-gray-700/90 min-h-2.5 max-h-2.5 {see ? '-rotate-180 fill-white' : ''} transition-all"/>
    </button>
    {#if see && available_os.length}
      <div class="absolute w-full z-5 top-full overflow-hidden overflow-y-scroll scheme-dark max-h-[170px] border-b border-b-gray-700/90 border-dotted">
        <div class="flex flex-col">
          {#each available_os as item}
            <button title={item} onclick={() => {os = item; see = false}}
                    class="last:border-b-0 first:border-t-0 hover:bg-[#1f242e] truncate w-full py-3 px-5 border-gray-700/90 border-dotted border-b border-x bg-[#1b1f28]">
              <span class="truncate">{item}</span>
            </button>
          {/each}
        </div>
      </div>
    {/if}
  </div>
  <Button class={loading_control ? 'opacity-40 pointer-events-none' : ''} onclick={() => reinstallPanel = true}
          title={language.reinstall_os ?? "..."}/>
</section>

{#if reinstallPanel}
  <div transition:fade={{duration: 75}}
       class="z-50 h-full w-full absolute flex justify-center items-center backdrop-blur-[1px]">
    <div class="flex flex-col gap-6 py-6 px-8 bg-(--color-xlgames-dark-400) border border-gray-700/90
border-dotted max-w-4xl">
      <h1 class="text-center">{language.are_you_sure_you_want_to_reinstall_the_os}</h1>
      <h1 class="text-[14px] text-red-500 hyphens-auto">* {language.after_reinstalling_the_os_all_data_will_be_deleted_permanently_without_the_possibility_of_recovery}</h1>
      <div class="flex flex-nowrap gap-6 max-[700px]:grid max-[700px]:grid-rows-3 max-[700px]:gap-y-4">
        <input class="outline-0 border w-full min-w-4 border-dotted border-gray-700/90 px-4 placeholder-gray-500"
               placeholder={language.key_word ?? "..."} bind:value={keyWord}>
        <Button class="w-fit text-[15px] max-[700px]:w-full
                  {language.key_word === keyWord ? '' : 'opacity-40 pointer-events-none text-gray-600'}"
                title={language.accept} onclick={() => {reinstall_os(); reinstallPanel = false}}/>
        <Button class="w-fit text-[15px] max-[700px]:w-full" title={language.close} onclick={() => {reinstallPanel = false}}/>
      </div>
    </div>
  </div>
{/if}