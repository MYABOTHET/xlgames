<script>
  import {page} from "$app/state";
  
  const {children, href, ...props} = $props();
  let splitHref = $derived(href.split("/"));
  let splitPath = $derived(page.url.pathname.split("/"));
  let startsWith = $derived.by(() => {
    let result = null;
    for (let i = 0; i < splitHref.length; i++) {
      result = splitHref[i] === splitPath[i];
    }
    return result;
  });
</script>

<a {...props} class="{props.class} py-3.5 px-5 transition-colors border-b border-b-(--color-septenary) max-w-52
{startsWith ? 'text-white bg-(--color-quinary)' : 'hover:text-white text-(--color-quaternary) hover:bg-(--color-quinary)'}"
   {href}>
  {@render children?.()}</a>