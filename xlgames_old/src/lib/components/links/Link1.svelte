<script>
  import {page} from "$app/stores";
  
  let {children, href, ...props} = $props();
  let style = $derived($page.url.pathname === href ? "text-xlgames-3" : "hover:text-xlgames-3");
</script>

<a {...props} {href} class="{props.class} transition-[color] {style}">
  {@render children?.()}
</a>