<script>
  import {global_state} from "$lib/state.svelte.js";
  import Title1 from "$lib/components/titles/Title1.svelte";
  
  const {data} = $props();
</script>

<Title1>{global_state.language.pages.web_hosting.title}</Title1>

<div class="flex justify-center items-center h-full flex-col gap-y-2">
  <Title1 class="text-xl text-xlgames-4 text-center">{global_state.language.shared.page_temporarily_empty}</Title1>
  <Title1 class="text-xl text-xlgames-4 text-center">{'｡ﾟ･ (>﹏<) ･ﾟ｡ '}</Title1>
</div>