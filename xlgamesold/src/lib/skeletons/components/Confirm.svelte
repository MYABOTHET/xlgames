<script>
  import Button from "../../components/Button.svelte";
  import Input from "../../components/Input.svelte";
  
  let {close, reinstall, language} = $props();
  
  let keyword = $state('');
</script>

<div class="py-4 px-6 w-[640px] rounded bg-white border border-sky-500">
  <div>{language.start}«<span class="font-medium text-sky-500">{language.middle}</span>»{language.end} <span class="text-red-500">{language.warning}</span></div>
  <div class="h-3"></div>
  <Input bind:value={keyword} placeholder={language.keyword} color="sky" class="w-full"/>
  <div class="h-2"></div>
  <div class="flex gap-2">
    <Button onclick={() => {keyword = ''; close()}} class="w-full" color="red">{language.cancel}</Button>
    <Button onclick={reinstall} class="w-full
{keyword === language.middle ? '' : 'pointer-events-none opacity-30'}" color="green">
      {language.confirm}</Button>
  </div>
  <div class="h-1"></div>
</div>
