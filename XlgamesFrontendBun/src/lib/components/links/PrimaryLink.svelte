<script>
  import {page} from "$app/state";
  import PrimarySpan from "$lib/components/spans/PrimarySpan.svelte";
  
  const {children, href, style, ...props} = $props();
  
  let equals = $derived(page.url.pathname === href);
</script>

<a {href} {style} class="text-center h-fit"><PrimarySpan {...props} isActive={equals}>{@render children?.()}</PrimarySpan></a>