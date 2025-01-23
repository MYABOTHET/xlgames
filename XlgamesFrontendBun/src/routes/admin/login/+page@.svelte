<script>
  import {enhance} from '$app/forms';
  
  let {form} = $props();
</script>

<div class="mx-auto h-full px-5 flex items-center justify-center gap-y-14 flex-col text-center">
  <div class="flex-1"></div>
  <div class="flex items-center justify-center gap-y-14 flex-col w-full">
    <h1 class="text-4xl font-medium">Вход в аккаунт</h1>
    <form spellcheck="false" method="POST" action="/admin/login" class="flex flex-col gap-y-6 max-w-[22rem] w-full"
          use:enhance>
      <input autocomplete="off" name="login" placeholder="Логин" type="text" class="bg-transparent border-2 border-quaternary min-w-0 py-3 px-6
    outline-none placeholder-quaternary rounded-full">
      <input autocomplete="off" name="password" placeholder="Пароль" type="password"
             class="bg-transparent border-2 border-quaternary min-w-0 py-3 px-6
    outline-none placeholder-quaternary rounded-full">
      <button class="mt-8 px-8 py-3 border-2 bg-ternary border-ternary w-fit rounded-full mx-auto text-primary
transition-colors hover:bg-primary hover:text-white">Выполнить вход
      </button>
    </form>
  </div>
  <div class="flex-1">
    {#if form?.success === false}
      <div class="text-red-600 flex flex-col gap-y-2 items-center">
        {#each form.errors as error}<span>{error}</span>{/each}
      </div>
    {/if}
  </div>
</div>