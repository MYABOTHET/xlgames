<script>
  import Arrow from "../svgs/Arrow.svelte";
  import HorizontalLine from "./HorizontalLine.svelte";
  import Button from "../../presets/buttons/Button.svelte";

  let {os = $bindable(), available_os = [], reinstall_os, loading_control, ...props} = $props();
  let see = $state(false);
</script>

<section {...props}
         class="{props.class} text-[15px] flex flex-col justify-between text-nowrap w-100">
  <HorizontalLine/>
  <div class="relative">
    <button
      class="{loading_control ? 'opacity-40 pointer-events-none' : ''} hover:*:fill-white transition-all hover:bg-[#1f242e] w-full flex gap-6 items-center py-3 px-5 border-gray-700/90 border-dotted border"
      onclick={() => {see = !see}}
      title={os}>
      <span class="truncate flex-1">{os}</span>
      <Arrow class="fill-gray-700/90 min-h-2.5 max-h-2.5 {see ? '-rotate-180 fill-white' : ''} transition-all"/>
    </button>
    {#if see}
      <div class="absolute w-full z-5 top-full overflow-hidden overflow-y-scroll scheme-dark h-[288px] border-b border-b-gray-700/90 border-dotted">
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
  <Button class={loading_control ? 'opacity-40 pointer-events-none' : ''} onclick={reinstall_os}
          title={language.reinstall_os ?? "..."}/>
</section>