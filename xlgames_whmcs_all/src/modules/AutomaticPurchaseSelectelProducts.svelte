<script>
  import Table from "../lib/components/Table.svelte";
  import Tr from "../lib/components/Tr.svelte";
  import Td from "../lib/components/Td.svelte";
  import Th from "../lib/components/Th.svelte";
  import Button from "../lib/components/Button.svelte";
  import LoadingScreen from "../lib/components/LoadingScreen.svelte";
  import Pages from "../lib/components/Pages.svelte";
  import {process} from "../lib/index.js";
  import Input from "../lib/components/Input.svelte";
  import Checkbox from "../lib/components/Checkbox.svelte";
  import Counter from "../lib/components/Counter.svelte";
  
  const pages = [
    {
      name: "Мониторинг",
      component: Monitoring
    },
    {
      name: "Конфигурация",
      component: Config
    }
  ];
  
  const payload = JSON.parse(whmcs);
  let current_page = $state(pages[0]);
  let load = $state(false);
  let iter = $state(payload.iter);
  let products = $state(payload.products);
  let product_form = $state({
    selectel_product_name: "",
    can_buy: true
  });
  
  async function update_config() {
    load = true;
    await process("config", {
      method: "PUT",
      body: JSON.stringify({iter})
    });
    load = false;
  }
  
  async function delete_product(product) {
    load = true;
    const response = await process("products", {
      method: "DELETE",
      body: JSON.stringify({id: product.id})
    });
    if (response !== undefined) {
      products = products.filter(item => item.id !== product.id);
    }
    load = false;
  }
  
  async function create_product() {
    if (!product_form.selectel_product_name) {
      alert("Укажите название продукта Selectel");
      return;
    }
    if (products.find(item => item.selectel_product_name === product_form.selectel_product_name)) {
      alert("Этот продукт уже прослушивается");
      return;
    }
    load = true;
    const response = await process("products", {
      method: "POST",
      body: JSON.stringify(product_form)
    });
    if (response) {
      products.push(response);
      product_form = {
        selectel_product_name: "",
        can_buy: true
      };
    }
    load = false;
  }
  
  function transform_message(status) {
    if (status === 0)
      return "Ожидание";
    if (status === 1)
      return "Куплен";
    if (status === 2)
      return "Ошибка";
    return "Найден";
  }
  
  function get_message_style(status) {
    if (status === 0)
      return "text-yellow-500";
    if (status === 1)
      return "text-green-500";
    if (status === 2)
      return "text-red-500";
    return "text-cyan-500";
  }
</script>

{#if load}
  <LoadingScreen/>
{/if}

<Pages {pages} bind:current_page/>

{@render current_page.component()}

{#snippet Config()}
  <Table Head={ConfigHead} Body={ConfigBody} class="w-fit"/>
{/snippet}

{#snippet Monitoring()}
  <Table Head={MonitoringHead} Body={MonitoringBody} class="w-fit"/>
{/snippet}

{#snippet MonitoringHead()}
  <Tr>
    <Th><span>Название</span></Th>
    <Th><span>Покупать?</span></Th>
    <Th><span>Статус</span></Th>
    <Th><span>Сообщение</span></Th>
    <Th class="pr-2"><span>Управление</span></Th>
  </Tr>
{/snippet}

{#snippet MonitoringBody()}
  <Tr>
    <Td><span><Input bind:value={product_form.selectel_product_name} placeholder="Название"/></span></Td>
    <Td>
      <Checkbox bind:checked={product_form.can_buy}/>
    </Td>
    <Td><span>—</span></Td>
    <Td><span>—</span></Td>
    <Td class="pr-2">
      <Button onclick={create_product}>Добавить</Button>
    </Td>
  </Tr>
  {#each products as product}
    <Tr>
      <Td><span>
        {#if product.selectel_product_uuid}
          <a target="_blank" class="text-indigo-500 hover:!underline underline-offset-2" href="https://selectel.ru/services/dedicated/config/?uuid={product.selectel_product_uuid}">{product.selectel_product_name}</a>
        {:else}
          {product.selectel_product_name}
        {/if}
      </span></Td>
      <Td>
        <Checkbox checked={product.can_buy} onclick={(e) => {e.preventDefault()}}/>
      </Td>
      <Td><span class={get_message_style(product.sync_status)}>{transform_message(product.sync_status)}</span></Td>
      <Td><span><Input value={product.sync_status_message} placeholder="Сообщение"
                       class="max-w-96 {get_message_style(product.sync_status)}"/></span></Td>
      <Td class="pr-2">
        <Counter class="w-full" onclick={() => {delete_product(product)}}>Удалить</Counter>
      </Td>
    </Tr>
  {/each}
{/snippet}

{#snippet ConfigHead()}
  <Tr>
    <Th><span>Итератор</span></Th>
    <Th><span>Опрос каждые</span></Th>
    <Th class="pr-2"><span>Управление</span></Th>
  </Tr>
{/snippet}

{#snippet ConfigBody()}
  {@const number = iter * 5}
  {@const minutes = number < 1 ? 5 : number}
  <Tr>
    <Td><span><Input bind:value={iter} type="number" placeholder="Итератор"/></span></Td>
    <Td><span>{minutes} минут</span></Td>
    <Td class="pr-2">
      <Button onclick={update_config}>Сохранить</Button>
    </Td>
  </Tr>
{/snippet}