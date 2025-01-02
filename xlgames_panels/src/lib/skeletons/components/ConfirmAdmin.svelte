<script>
  import Button from "../../components/Button.svelte";
  import Input from "../../components/Input.svelte";
  
  let {close, delete_language} = $props();
  
  let keyword = $state('');
  let word = 'Да';
</script>

<div class="bg-white p-4 rounded border border-sky-500 w-80 flex flex-col gap-2">
  <span>Введите «<span class="text-sky-500 font-medium">{word}</span>», чтобы удалить язык</span>
  <Input bind:value={keyword} color="sky" placeholder="Ключевое слово"/>
  <div class="flex gap-2">
    <Button class="w-full" color="red"
            onclick={close}>Отмена</Button>
    <Button class="w-full {word === keyword ? '' : 'pointer-events-none opacity-30'}" color="green"
            onclick={() => {close(); delete_language()}}>Подвердить</Button>
  </div>
</div>