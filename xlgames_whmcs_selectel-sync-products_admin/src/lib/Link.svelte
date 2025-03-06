<script>
  import { getContext } from "svelte";
  
  let { item, ...props } = $props();
  
  let page = $derived(getContext("page")());
</script>

<button {...props}
        class="{props.class} {page.name === item.name ? '' : 'text-slate-400 hover:text-slate-500'} transition-colors">{item.name}</button>