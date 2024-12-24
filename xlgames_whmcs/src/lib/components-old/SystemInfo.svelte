<script>
  import Item from "./Item.svelte";
  
  let {system, language, ...props} = $props();
</script>

<div {...props} class="{props.class} flex flex-col gap-1">
  <Item title={language.system_info.state}>
    {#if system.state}
      <span class="text-green-500">{language.system_info.on}</span>
    {:else}
      <span class="text-red-500">{language.system_info.off}</span>
    {/if}
  </Item>
  <Item title={language.system_info.os}>{system.os}</Item>
  <Item title={language.system_info.ip}>{system.ip}</Item>
  <Item title={language.system_info.login}>{system.login}</Item>
  <Item title={language.system_info.password}>
    {#if system.password}
      <div class="flex flex-col gap-1">
        <span class="text-wrap break-all">{system.password}</span>
        <span class="text-red-500 text-sm text-wrap break-all">* {language.system_info.note}</span>
      </div>
    {:else}
      <span class="text-slate-500 text-wrap break-all">{language.system_info.not_available}</span>
    {/if}
  </Item>
</div>