<script>
  import {global_state} from "$lib/state.svelte.js";
  import Title1 from "$lib/components/titles/Title1.svelte";
  
  const {data} = $props();
</script>

<Title1>{global_state.language.pages.privacy_policy.title}</Title1>