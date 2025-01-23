<script>
  import {page} from "$app/state";
  
  const {children, href, ...props} = $props();
  
  let startsWith = $derived(page.url.pathname.startsWith(href));
</script>

<a {href} {...props} class="{props.class} py-4 px-6 transition-colors border-b border-b-septenary
{startsWith ? 'text-white bg-quinary' : 'hover:text-white text-quaternary hover:bg-quinary'}">{@render children?.()}</a>