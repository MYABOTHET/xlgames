<script>
  import {page} from "$app/state";
  import PrimarySpan from "$lib/components/Spans/PrimarySpan.svelte";
  
  const {children, href, ...props} = $props();
  
  let isThisCurrentPage = $derived(page.url.pathname === href);
</script>

<a {href} {...props}><PrimarySpan isActive={isThisCurrentPage}>{@render children?.()}</PrimarySpan></a>