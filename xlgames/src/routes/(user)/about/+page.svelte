<script>
  import {global_state} from "$lib/state.svelte.js";
  import Title1 from "$lib/components/titles/Title1.svelte";
  import Img1 from "$lib/components/img/Img1.svelte";
  
  const {data} = $props();
</script>

<div class="max-w-screen-xlgames-3 w-full m-auto">
  <Title1>{global_state.language.pages.about.title}</Title1>
  
  <div class="min-h-12"></div>
  
  <Img1 class="w-full h-64 rounded-2xl overflow-hidden" src="minecraft.png"/>
  
  <div class="min-h-8"></div>
  
  <p class="text-sm whitespace-pre-wrap leading-[22px]">{global_state.language.pages.about.description}</p>
</div>
