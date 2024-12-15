<script>
  import {global_state} from "$lib/state.svelte.js";
  import Title1 from "$lib/components/titles/Title1.svelte";
  
  const {data} = $props();
</script>

<Title1>{global_state.language.pages.gpu_dedicated_servers.title}</Title1>

<div class="min-h-12"></div>

<p>{global_state.language.pages.gpu_dedicated_servers.description}</p>

<div class="min-h-8"></div>