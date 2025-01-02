<script>
  import Item from "../../components/Item.svelte";
  
  let {system, language, ...props} = $props();
</script>

<div {...props} class="{props.class} flex flex-col gap-1">
  <Item title={language.status}>
    {#if system.status}
      <span class="text-green-500">{language.on}</span>
    {:else}
      <span class="text-red-500">{language.off}</span>
    {/if}
  </Item>
  <Item title={language.os}>{system.os}</Item>
  <Item title={language.ip}>{system.ip}</Item>
  <Item title={language.login}>{system.login}</Item>
  <Item title={language.password}>
    {#if system.password}
      <div class="flex flex-col gap-1">
        <span class="text-wrap break-all">{system.password}</span>
        <span class="text-red-500 text-sm text-wrap break-all">* {language.note}</span>
      </div>
    {:else}
      <span class="text-slate-500 text-wrap break-all">{language.not_available}</span>
    {/if}
  </Item>
</div>