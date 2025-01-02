<script>
  import Input from "../components/Input.svelte";
  import Button from "../components/Button.svelte";
  import Loading from "../components/Loading.svelte";
  
  let {
    id = $bindable(),
    price = $bindable(),
    product,
    have_error,
    error_message,
    success_message,
    get_product,
    set_static_price,
    delete_static_price,
    loading,
    loading_message,
    update_static_price,
  } = $props();
</script>

<div class="max-w-425 w-full relative">
  <div class="duration-300 flex flex-col gap-2 w-full h-full {loading ? 'blur-sm' : 'opacity-100'}">
    <Input bind:value={id} placeholder="ID продукта" class="w-full" color="sky"/>
    <Button class="w-full" color="green"
            onclick={get_product}>Найти продукт</Button>
    <Button class="w-full" color="yellow" onclick={update_static_price}>Обновить все цены</Button>
    {#if product !== ''}
      {#if product.is_static}
          <h1 class="text-center text-green-500 my-1">У продукта установлена статическая цена</h1>
        {:else}
          <h1 class="text-center text-red-500 my-1">У продукта установлена автоматическая цена</h1>
      {/if}
      <Input bind:value={product.price} readonly placeholder="Старая цена" class="w-full" color="sky"/>
      <Input bind:value={price} placeholder="Новая цена" class="w-full" color="sky"/>
      <Button class="w-full" color="green"
              onclick={set_static_price}>Установить статическую цену</Button>
      <Button class="w-full" color="red"
              onclick={delete_static_price}>Вернуть автоматическую цену</Button>
    {/if}
    {#if have_error}
      <h1 class="text-center text-red-500">{error_message}</h1>
    {/if}
  </div>
  <div class="duration-300 w-full h-full top-0 left-0 absolute flex justify-center items-center flex-col text-sky-500 gap-1
{loading ? 'opacity-100' : 'opacity-0 pointer-events-none'}">
    <Loading class="stroke-sky-500 h-10"/>
    <span class="my-1">{loading_message}</span>
  </div>
</div>
