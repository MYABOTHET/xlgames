<script>
  import Input from "../components-old/Input.svelte";
  import Button from "../components-old/Button.svelte";
  
  let {
    id = $bindable(),
    price = $bindable(),
    product,
    success_message,
    get_product,
    set_static_price,
    delete_static_price,
    update_static_price,
  } = $props();
</script>

<div class="max-w-[44rem] w-full relative flex flex-col gap-y-2">
  <Input bind:value={id} placeholder="ID продукта" class="w-full" color="sky"/>
  <Button class="w-full" color="green"
          onclick={get_product}>Найти продукт</Button>
  <Button class="w-full" color="yellow" onclick={update_static_price}>Обновить все цены</Button>
  {#if product !== ''}
    {#if product.is_static}
      <h1 class="text-center text-green-500 my-1.5 text-2xl">У продукта установлена статическая цена</h1>
    {:else}
      <h1 class="text-center text-red-500 my-1.5 text-2xl">У продукта установлена автоматическая цена</h1>
    {/if}
    <Input bind:value={product.price} readonly placeholder="Старая цена" class="w-full" color="sky"/>
    <Input bind:value={price} placeholder="Новая цена" class="w-full" color="sky"/>
    <Button class="w-full" color="green"
            onclick={set_static_price}>Установить статическую цену</Button>
    <Button class="w-full" color="red"
            onclick={delete_static_price}>Вернуть автоматическую цену</Button>
  {/if}
</div>
