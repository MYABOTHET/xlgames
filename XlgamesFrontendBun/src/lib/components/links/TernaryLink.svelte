<script>
  import {page} from "$app/state";
  
  const {children, href, ...props} = $props();
  
  let startsWith = $derived(page.url.pathname.startsWith(href));
</script>

<a {href} {...props} class="{props.class} py-4 px-5 transition-colors border-b border-b-(--color-septenary)
{startsWith ? 'text-white bg-(--color-quinary)' : 'hover:text-white text-(--color-quaternary) hover:bg-(--color-quinary)'}">{@render children?.()}</a>