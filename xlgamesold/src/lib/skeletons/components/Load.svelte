<script>
  import Loading from "../../components/Loading.svelte";
  
  let {loading_message} = $props();
</script>

<div class="flex flex-col text-center">
  <Loading class="stroke-sky-500 h-12"/>
  <div class="h-2"></div>
  <div class="text-sky-500">{loading_message}</div>
</div>