<script>
  import TitleLineBlock from "./lib/TitleLineBlock.svelte";
  import {onMount} from "svelte";
  import PaymentMethod from "./lib/PaymentMethod.svelte";
  import Payment from "./lib/Payment.svelte";
  
  let payment_methods = $state([]);
  let payments = $state([]);
  let payment_details = $state({
    fio: "",
    phone_number: "",
    bank_name: "",
  });
  let loading = $state(false);
  let payment_method = $state({
    bank_name: "",
    card_number: "",
  });
  let init = $state(false);
  
  const general_headings = {
    headers: {
      'Content-Type': 'application/json',
    }
  };
  
  onMount(() => {
    payload.payment_details ? payment_details = payload.payment_details : null;
    payment_methods = payload.payment_methods;
    payments = payload.payments;
    init = true;
  });
  
  function generate_url(action) {
    return `${window.location.href}&action=${action}`;
  }
  
  async function call(callback, params = {}) {
    loading = true;
    const body = await process(await callback(params));
    loading = false;
    return body;
  }
  
  async function process(response) {
    if (response.status !== 200) {
      let message = "Произошла ОБРАБОТАННАЯ ошибка...";
      if (response.status === 404) message = "Метод не найден..."
      else
        try {
          message = await response.text();
          if (!message) message = "Произошла ошибка на стороне сервера";
        } catch {
          message = "Произошла НЕОБРАБОТАННАЯ ошибка...";
        }
      alert(message);
      return new Promise((resolve) => {resolve(null)});
    }
    return await response.json() ?? {};
  }
  
  async function add_payment_method() {
    if (!payment_method.card_number || !payment_method.bank_name) return;
    if (payment_methods.find(item =>
        item.card_number === payment_method.card_number ||
        item.bank_name === payment_method.bank_name)) {
      alert("Введите уникальные данные...");
      return;
    }
    const body = await call(() => {
      return fetch(generate_url("payment_methods"), {
        ...general_headings,
        method: "POST",
        body: JSON.stringify(payment_method)
      })
    });
    if (body !== null) {
      payment_methods.push(payment_method);
      payment_method = {
        bank_name: "",
        card_number: "",
      };
    }
  }
  
  async function delete_payment_method(params) {
    const {id} = params;
    const body = await call(() => {
      return fetch(generate_url("payment_methods"), {
        ...general_headings,
        method: "DELETE",
        body: JSON.stringify({id})
      })
    });
    if (body !== null) payment_methods = payment_methods.filter(item => item.id !== id);
  }
  
  function save_payment_details() {
    return fetch(generate_url("payment_details"), {
      ...general_headings,
      method: "POST",
      body: JSON.stringify(payment_details)
    });
  }
  
  async function paid(id) {
    const body = await call(() => {
      return fetch(generate_url("payments"), {
        ...general_headings,
        method: "POST",
        body: JSON.stringify({id})
      })
    });
    if (body !== null) payments = payments.filter(item => item.id !== id);
  }
  
  async function unpaid(id) {
    const body = await call(() => {
      return fetch(generate_url("payments"), {
        ...general_headings,
        method: "DELETE",
        body: JSON.stringify({id})
      })
    });
    if (body !== null) payments = payments.filter(item => item.id !== id);
  }
</script>


<div class="component">
  {#if loading}
    <div class="quaternary_block">
      <div class="quinary_block">
        <h1>Загрузка...</h1>
      </div>
    </div>
  {/if}
  {#if init}
    <div class="content" class:filter={loading}>
      <div class="configuration" style="width: 100%">
        <TitleLineBlock title="Настройка данных для СБП и методов оплаты">
          <div class="primary_block">
            <input bind:value={payment_details.fio} placeholder="ФИО">
            <input bind:value={payment_details.phone_number} placeholder="Номер телефона для СПБ">
            <input bind:value={payment_details.bank_name} placeholder="Банк для СПБ">
            <button onclick={() => call(save_payment_details)}>Сохранить данные</button>
          </div>
        </TitleLineBlock>
        {#if payment_methods.length}
          <TitleLineBlock title="Методы оплаты">
            <div class="ternary_block">
              {#each payment_methods as _, index}
                <PaymentMethod callback={(id) => delete_payment_method({id})} bind:payment_method={payment_methods[index]}/>
              {/each}
            </div>
          </TitleLineBlock>
        {/if}
        <TitleLineBlock title="Добавить новый метод оплаты">
          <div class="primary_block">
            <input bind:value={payment_method.bank_name} placeholder="Название банка">
            <input bind:value={payment_method.card_number} placeholder="Номер карты">
            <button onclick={add_payment_method}>Добавить</button>
          </div>
        </TitleLineBlock>
      </div>
      {#if payments.length}
        <div class="vertical_line"></div>
        <div style="width: 100%">
          <TitleLineBlock title="Платежи">
            <div class="ternary_block">
              {#each payments as payment}
                <Payment {payment} {paid} {unpaid}/>
              {/each}
            </div>
          </TitleLineBlock>
        </div>
      {/if}
    </div>
  {/if}
</div>