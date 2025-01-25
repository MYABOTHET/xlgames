<script>
  import {page} from "$app/state";
  import PrimarySpan from "$lib/components/spans/PrimarySpan.svelte";
  
  const {children, href, style, ...props} = $props();
  
  let equals = $derived(page.url.pathname === href);
</script>

<a class="text-center h-fit" {href} rel={props.rel} {style}>
  <PrimarySpan {...props} isActive={equals}>{@render children?.()}</PrimarySpan>
</a>