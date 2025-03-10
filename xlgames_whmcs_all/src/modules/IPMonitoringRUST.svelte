<script>
  import Table from "../lib/components/Table.svelte";
  import Tr from "../lib/components/Tr.svelte";
  import Td from "../lib/components/Td.svelte";
  import Th from "../lib/components/Th.svelte";
  import Button from "../lib/components/Button.svelte";
  import LoadingScreen from "../lib/components/LoadingScreen.svelte";
  import Pages from "../lib/components/Pages.svelte";
  import {compare, process} from "../lib/index.js";
  import Input from "../lib/components/Input.svelte";
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
  let ips = $state(payload.ips);
  let ips_sort = $derived(ips.slice().sort((a, b) => compare(a.ip, b.ip)));
  let ip_form = $state({
    ip: ""
  });
  
  async function monitor(ip) {
    load = true;
    const response = await process("monitor", {
      method: "POST",
      body: JSON.stringify({id: ip.id})
    });
    if (response)
      for (let i = 0; i < ips.length; i++)
        if (ips[i].id === ip.id) {
          ips[i] = response;
          break;
        }
    load = false;
  }
  
  async function monitor_all() {
    load = true;
    const response = await process("monitor_all", {
      method: "POST",
    });
    if (response) ips = response;
    load = false;
  }
  
  async function update_config() {
    load = true;
    await process("config", {
      method: "PUT",
      body: JSON.stringify({iter})
    });
    load = false;
  }
  
  async function delete_ip(ip) {
    load = true;
    const response = await process("ips", {
      method: "DELETE",
      body: JSON.stringify({id: ip.id})
    });
    if (response !== undefined) {
      ips = ips.filter(item => item.id !== ip.id);
    }
    load = false;
  }
  
  async function create_ip() {
    if (!ip_form.ip) {
      alert("Укажите IP");
      return;
    }
    if (ips.find(item => item.ip === ip_form.ip)) {
      alert("Этот IP уже занят");
      return;
    }
    load = true;
    const response = await process("ips", {
      method: "POST",
      body: JSON.stringify(ip_form)
    });
    if (response) {
      ips.push(response);
      ip_form = {
        ip: ""
      };
    }
    load = false;
  }
  
  function transform_message(status) {
    if (status === 0)
      return "Не забанен";
    if (status === 1)
      return "Забанен";
    return "Ожидает";
  }
  
  function get_message_style(status) {
    if (status === 0)
      return "text-green-500";
    if (status === 1)
      return "text-red-500";
    return "text-yellow-500";
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
    <Th><span>IP</span></Th>
    <Th><span>Статус</span></Th>
    <Th class="pr-2"><span>Управление</span></Th>
  </Tr>
{/snippet}

{#snippet MonitoringBody()}
  <Tr>
    <Td><span><Input bind:value={ip_form.ip} placeholder="IP"/></span></Td>
    <Td><span>—</span></Td>
    <Td class="pr-2">
      <div class="flex gap-2">
        <Button onclick={create_ip}>Добавить</Button>
        <Button onclick={monitor_all}>Проверить всё</Button>
      </div>
    </Td>
  </Tr>
  {#each ips_sort as ip}
    <Tr>
      <Td><span>{ip.ip}</span></Td>
      <Td><span class={get_message_style(ip.status)}>{transform_message(ip.status)}</span></Td>
      <Td class="pr-2">
        <div class="flex gap-2 *:w-full">
          <Counter onclick={() => {delete_ip(ip)}}>Удалить</Counter>
          <Button onclick={() => {monitor(ip)}}>Проверить</Button>
        </div>
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