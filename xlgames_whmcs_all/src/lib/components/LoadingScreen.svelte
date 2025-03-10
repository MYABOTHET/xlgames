<script>
  import {fade} from "svelte/transition";
  import Spinner from "./Spinner.svelte";
  
  let {...props} = $props();
</script>

<div transition:fade {...props} class="{props.class} fixed top-0 left-0 w-full h-full z-50
bg-slate-900/40 flex justify-center items-center">
  <Spinner class="stroke-slate-100 size-20"/>
</div>