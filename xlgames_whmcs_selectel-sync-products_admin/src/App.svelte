<script>
  import { setContext } from "svelte";
  import Line from "./lib/Line.svelte";
  import Link from "./lib/Link.svelte";
  import Button from "./lib/Button.svelte";
  import Counter from "./lib/Counter.svelte";
  import Input from "./lib/Input.svelte";
  import Checkbox from "./lib/Checkbox.svelte";
  import { fade } from "svelte/transition";
  import Load from "./lib/Load.svelte";
  
  const payload = JSON.parse(whmcs);
  let config = $state(payload.config);
  let products = $state(payload.products);
  let products_sorted = $derived(products.slice().sort((a, b) => compare(parseInt(a.whmcs_product_id), parseInt(b.whmcs_product_id))));
  let langs = $state(payload.langs);
  let langs_sorted = $derived(langs.slice().sort((a, b) => compare(a.language, b.language)));
  const pages = [
    {
      name: "Продукты",
      component: products_page
    },
    {
      name: "Переводы",
      component: langs_page
    },
    {
      name: "Конфигурация",
      component: config_page
    }
  ];
  let page = $state(pages[0]);
  let load = $state(false);
  let default_product = {
    whmcs_product_id: "",
    selectel_product_name: "",
    hide: true,
    set_quantity: true,
    set_hours: true,
    hours_install_if_any: "",
    hours_install_if_not: "",
    sync: true
  };
  let default_lang = {
    language: "",
    keyword: "",
    line_start: "",
    line_end: ""
  };
  let product_form = $state(default_product);
  let lang_form = $state(default_lang);
  const origin = {
    headers: {
      "Content-Type": "application/json"
    }
  };
  
  function compare(a, b) {
    if (a > b) return 1;
    if (a === b) return 0;
    if (a < b) return -1;
  }
  
  function change_page(item) {
    page = item;
  }
  
  async function process(action, options) {
    const response = await fetch(`${window.location.href}&action=${action}`, {
      ...origin,
      ...options
    });
    if (response.ok) return response.json();
    else alert(await response.text());
    return false;
  }
  
  async function products_add() {
    if (!product_form.whmcs_product_id) {
      alert("Укажите ID продукта WHMCS");
      return;
    }
    if (!product_form.selectel_product_name) {
      alert("Укажите название продукта Selectel");
      return;
    }
    product_form.selectel_product_name = product_form.selectel_product_name.trim();
    if (products.find(product => product.whmcs_product_id.toString() === product_form.whmcs_product_id.toString())) {
      alert("ID продукта WHMCS уже используются");
      return;
    }
    if (products.find(product => product.selectel_product_name === product_form.selectel_product_name)) {
      alert("Название продукта Selectel уже используются");
      return;
    }
    load = true;
    const result = await process("products", {
      method: "POST",
      body: JSON.stringify(product_form)
    });
    if (result) {
      products.push(result);
      reset_product();
    }
    load = false;
  }
  
  function reset_product() {
    product_form = default_product;
  }
  
  function reset_lang() {
    lang_form = default_lang;
  }
  
  async function products_delete(product) {
    load = true;
    const result = await process("products", {
      method: "DELETE",
      body: JSON.stringify({ id: product.id })
    });
    if (result === null) {
      products = products.filter(item => item.id !== product.id);
    }
    load = false;
  }
  
  async function products_update(product) {
    if (products.find(item => item.whmcs_product_id.toString() === product.whmcs_product_id.toString() && item.id !== product.id)) {
      alert("ID продукта WHMCS уже используются");
      return;
    }
    if (products.find(item => item.selectel_product_name === product.selectel_product_name && item.id !== product.id)) {
      alert("Название продукта Selectel уже используются");
      return;
    }
    load = true;
    const result = await process("products", {
      method: "PUT",
      body: JSON.stringify(product)
    });
    if (result)
      for (let i = 0; i < products.length; i++)
        if (products[i].id === product.id) {
          products[i] = result;
          break;
        }
    load = false;
  }
  
  async function langs_add() {
    if (!lang_form.language) {
      alert("Укажите название языка");
      return;
    }
    if (langs.find(lang => lang.language === lang_form.language)) {
      alert("Это название языка уже используется");
      return;
    }
    load = true;
    const result = await process("langs", {
      method: "POST",
      body: JSON.stringify(lang_form)
    });
    if (result) {
      langs.push(result);
      reset_lang();
    }
    load = false;
  }
  
  async function langs_delete(lang) {
    load = true;
    const result = await process("langs", {
      method: "DELETE",
      body: JSON.stringify({ id: lang.id })
    });
    if (result === null) {
      langs = langs.filter(item => item.id !== lang.id);
    }
    load = false;
  }
  
  async function langs_update(lang) {
    if (langs.find(item => item.language === lang.language && item.id !== lang.id)) {
      alert("Это название языка уже используется");
      return;
    }
    load = true;
    const result = await process("langs", {
      method: "PUT",
      body: JSON.stringify(lang)
    });
    if (result)
      for (let i = 0; i < langs.length; i++)
        if (langs[i].id === langs.id) {
          langs[i] = result;
          break;
        }
    load = false;
  }
  
  async function config_update() {
    load = true;
    await process("config", {
      method: "PUT",
      body: JSON.stringify({ iter: config.iter })
    });
    load = false;
  }
  
  async function sync(product) {
    load = true;
    const result = await process("sync", {
      method: "POST",
      body: JSON.stringify({ id: product.id })
    });
    if (result)
      for (let i = 0; i < products.length; i++)
        if (products[i].id === product.id) {
          products[i] = result;
          break;
        }
    load = false;
  }
  
  async function sync_all() {
    load = true;
    const result = await process("sync_all", {
      method: "POST"
    });
    if (result) products = result;
    load = false;
  }
  
  function get_status_message(status) {
    switch (status) {
      case 0:
        return "Неудачно";
      case 1:
        return "Успешно";
      case 2:
        return "Не синхр.";
      default:
        return "Неизвестно";
    }
  }
  
  function get_status_style(status) {
    switch (status) {
      case 0:
        return "text-red-500";
      case 1:
        return "text-green-500";
      case 2:
        return "";
      default:
        return "text-yellow-500";
    }
  }
  
  setContext("page", () => page);
</script>

<div class="tailwindcss">
  <div class="font-roboto font-[350] tracking-wide text-slate-800">
    {#if load}
      <div transition:fade class="fixed top-0 left-0 w-full h-full z-50 bg-black/40 flex justify-center items-center">
        <Load />
      </div>
    {/if}
    <div class="flex gap-6 text-[120%]">
      {#each pages as item}
        <Link onclick={() => change_page(item)} {item} />
      {/each}
    </div>
    <Line />
    <div class="text-xl">
      {@render page.component()}
    </div>
  </div>
</div>

{#snippet products_page()}
  <div class="table-border">
    <table class="w-full table-full">
      <thead>
      <tr>
        <th>ID</th>
        <th>Название</th>
        <th>Скр./Пок.?</th>
        <th>Уст. кол.?</th>
        <th>Уст. время?</th>
        <th>Время уст. в нал.</th>
        <th>Время уст. НЕ в нал.</th>
        <th>Синхр.?</th>
        <th>Статус</th>
        <th>Сообщение</th>
        <th>Управление</th>
      </tr>
      </thead>
      <tbody>
      <tr>
        <td><Input type="number" placeholder="ID" bind:value={product_form.whmcs_product_id} /></td>
        <td><Input placeholder="Название" bind:value={product_form.selectel_product_name} /></td>
        <td class="tools">
          <Checkbox bind:checked={product_form.hide} />
        </td>
        <td class="tools">
          <Checkbox bind:checked={product_form.set_quantity} />
        </td>
        <td class="tools">
          <Checkbox bind:checked={product_form.set_hours} />
        </td>
        <td><Input placeholder="Время уст. в нал." bind:value={product_form.hours_install_if_any} /></td>
        <td><Input placeholder="Время уст. не в нал." bind:value={product_form.hours_install_if_not} /></td>
        <td class="tools">
          <Checkbox bind:checked={product_form.sync} />
        </td>
        <td>—</td>
        <td>—</td>
        <td class="tools w-0">
          <div class="flex gap-2">
            <Button onclick={products_add} class="w-full">Добавить</Button>
            <Button onclick={sync_all} class="w-full">Синхр. всё</Button>
          </div>
        </td>
      </tr>
      {#each products_sorted as product (product.id)}
        <tr>
          <td><Input type="number" placeholder="ID" bind:value={product.whmcs_product_id} /></td>
          <td><Input placeholder="Название" bind:value={product.selectel_product_name} /></td>
          <td class="tools">
            <Checkbox bind:checked={product.hide} />
          </td>
          <td class="tools">
            <Checkbox bind:checked={product.set_quantity} />
          </td>
          <td class="tools">
            <Checkbox bind:checked={product.set_hours} />
          </td>
          <td><Input bind:value={product.hours_install_if_any} placeholder="Время уст. в нал." /></td>
          <td><Input bind:value={product.hours_install_if_not} placeholder="Время уст. не в нал." /></td>
          <td class="tools">
            <Checkbox bind:checked={product.sync} />
          </td>
          <td><span class={get_status_style(product.sync_status)}>{get_status_message(product.sync_status)}</span></td>
          <td><Input class={get_status_style(product.sync_status)} value={product.sync_status_message}
                     placeholder="Cообщение" /></td>
          <td class="tools w-0">
            <div class="flex gap-2">
              <Button onclick={() => {products_update(product)}}>Сохранить</Button>
              <Counter onclick={() => {products_delete(product)}}>Удалить</Counter>
              <Button onclick={() => {sync(product)}}>Синхр.</Button>
            </div>
          </td>
        </tr>
      {/each}
      </tbody>
    </table>
  </div>
{/snippet}

{#snippet langs_page()}
  <div class="table-border w-fit">
    <table class="table-no-full">
      <thead>
      <tr>
        <th>Язык</th>
        <th>Ключевое слово</th>
        <th>Начало строки</th>
        <th>Конец строки</th>
        <th>Управление</th>
      </tr>
      </thead>
      <tbody>
      <tr>
        <td><Input class="max-w-60" bind:value={lang_form.language} placeholder="Язык" /></td>
        <td><Input class="max-w-60" bind:value={lang_form.keyword} placeholder="Ключевое слово" /></td>
        <td><Input class="max-w-60" bind:value={lang_form.line_start} placeholder="Начало строки" /></td>
        <td><Input class="max-w-60" bind:value={lang_form.line_end} placeholder="Конец строки" /></td>
        <td class="tools w-0">
          <Button class="w-full" onclick={langs_add}>Добавить</Button>
        </td>
      </tr>
      {#each langs_sorted as lang (lang.id)}
        <tr>
          <td><Input class="max-w-60" bind:value={lang.language} placeholder="Язык" /></td>
          <td><Input class="max-w-60" bind:value={lang.keyword} placeholder="Ключевое слово" /></td>
          <td><Input class="max-w-60" bind:value={lang.line_start} placeholder="Начало строки" /></td>
          <td><Input class="max-w-60" bind:value={lang.line_end} placeholder="Конец строки" /></td>
          <td class="tools w-0">
            <div class="flex gap-2">
              <Button onclick={() => {langs_update(lang)}}>Сохранить</Button>
              <Counter onclick={() => {langs_delete(lang)}}>Удалить</Counter>
            </div>
          </td>
        </tr>
      {/each}
      </tbody>
    </table>
  </div>
{/snippet}

{#snippet config_page()}
  <div class="table-border w-fit">
    <table class="table-no-full">
      <thead>
      <tr>
        <th>Итератор</th>
        <th>Крон каждые</th>
        <th>Управление</th>
      </tr>
      </thead>
      <tbody>
      <tr>
        <td><Input type="number" placeholder="Итератор" bind:value={config.iter} /></td>
        <td>{(config.iter ?? 1) * 5 < 1 ? 5 : (config.iter ?? 1) * 5} минут</td>
        <td class="tools w-0">
          <Button onclick={config_update}>Сохранить</Button>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
{/snippet}

<style lang="postcss">
  .table-border {
    @apply border border-slate-300 rounded-md overflow-hidden overflow-x-auto;
  }
  
  table {
    @apply h-0 text-nowrap;
  }
  
  th, td {
    @apply text-center font-normal;
  }
  
  .table-full {
    th, td {
      @apply pr-6 py-5 first:pl-6 last:pr-2;
    }
  }
  
  .table-no-full {
    th, td {
      @apply pr-8 py-5 first:pl-8 last:pr-2;
    }
  }
  
  tbody tr {
    @apply border-t border-t-slate-300;
  }
  
  th {
    @apply font-normal;
  }
  
  thead tr {
    @apply bg-slate-100;
  }
  
  tbody tr {
    @apply even:bg-slate-100;
  }
  
  .tools {
    @apply !py-1 font-[350];
  }
</style>