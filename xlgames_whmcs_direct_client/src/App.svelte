<script>
  import {onMount} from "svelte";
  import Enum from "./lib/Enum.svelte";
  
  let init = $state(false);
  let payment_methods = $state([]);
  let payment_details = $state({
    fio: "",
    phone_number: "",
    bank_name: "",
  });
  let formData = $state({});
  let sbp = $state(true);
  let current_payment_method = $state({});
  let payed = $state(false);
  
  const general_headings = {
    headers: {
      'Content-Type': 'application/json',
    }
  };
  
  function generate_url(action) {
    return `${window.location.href}&action=${action}`;
  }
  
  function set_sbp() {
    sbp = true;
    current_payment_method = {};
  }
  
  function set_bank(payment_method) {
    sbp = false;
    current_payment_method = payment_method;
  }
  
  async function pay() {
    let result = {
      invoice_id: formData.invoice_id,
      fio: decodeURI(formData.first_name) + " " + decodeURI(formData.last_name),
      price: formData.amount,
      date: new Date().getTime().toString(),
      data: "",
      bank: "",
      user_id: formData.user_id,
      postcode: formData.postcode,
    };
    if (sbp) {
      result.data = payment_details.phone_number;
      result.bank = payment_details.bank_name;
    } else {
      result.data = current_payment_method.card_number;
      result.bank = current_payment_method.bank_name;
    }
    let response = await fetch(generate_url("payments"), {
      ...general_headings,
      method: "POST",
      body: JSON.stringify(result)
    });
    if (response.status === 200) {
      payed = true;
    } else {
      alert("Произошла ошибка... " + await response.text());
    }
  }
  
  onMount(() => {
    if (!payed_server) {
      payload.payment_details ? payment_details = payload.payment_details : null;
      payment_methods = payload.payment_methods;
      formData = form;
    } else {
      payed = true;
    }
    init = true;
  })
</script>

{#if init}
  <div class="component">
    {#if payed}
      <div class="messages">
        <h4 class="message">Мы проверяем ваш платёж, подтверждение занимает в средем 20 минут в дневное время, 6 часов в
          ночное время. После подтверждения, статус вашего счёта будет изменен на "Оплачен".</h4>
        <a href="https://xlgames.gg/store/clientarea.php?action=invoices">Проверить платежи</a>
      </div>
    {:else}
      <div class="payments">
        <button class="payment_method" class:active={sbp} onclick={set_sbp}>СБП</button>
        <div class="vertical_line"></div>
        {#each payment_methods as payment_method}
          <button class="payment_method" class:active={current_payment_method.bank_name === payment_method.bank_name}
                  onclick={() => set_bank(payment_method)}>{payment_method.bank_name}</button>
          <div class="vertical_line"></div>
        {/each}
      </div>
      <div class="card">
        <div class="card_line"></div>
        <div class="card_content">
          <Enum title="ФИО">{payment_details.fio}</Enum>
          {#if sbp}
            <Enum title="Номер телефона">{payment_details.phone_number}</Enum>
          {:else}
            <Enum title="Номер карты">{current_payment_method.card_number}</Enum>
          {/if}
          <Enum title="Банк">
            {#if sbp}
              {payment_details.bank_name}
            {:else}
              {current_payment_method.bank_name}
            {/if}
          </Enum>
          <Enum title="Цена">{formData.amount} RUB</Enum>
          <Enum title="Вы">{decodeURI(formData.first_name)} {decodeURI(formData.last_name)}</Enum>
        </div>
      </div>
      <button class="pay" onclick={pay}>Я оплатил</button>
    {/if}
  </div>
{/if}

<style>
  .messages {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
  }
  
  .message {
    text-align: center;
    line-height: 26px;
    margin-bottom: 32px;
  }
  
  .active {
    color: var(--color-xlgames-orange-500) !important;
  }
  
  .component {
    display: flex;
    flex-direction: column;
    align-items: center;
    font-size: 15px;
    gap: 40px;
  }
  
  .card_line {
    margin-top: 22px;
    height: 40px;
    background-color: var(--color-xlgames-dark-600);
  }
  
  .card {
    background-color: var(--color-xlgames-dark-400);
    border-radius: 12px;
    max-width: 400px;
    width: 100%;
  }
  
  .card_content {
    margin-top: 4px;
    padding: 20px 24px;
  }
  
  .payments {
    display: flex;
    gap: 16px;
    justify-content: center;
    flex-wrap: wrap;
  }
  
  .payments > :last-child {
    display: none;
  }
  
  .vertical_line {
    border-right: 1px solid var(--color-xlgames-grey-light-500);
  }
  
  .payment_method {
    background-color: transparent;
    border: none;
    color: var(--color-xlgames-grey-light-500);
    padding: 0;
  }
  
  .payment_method:hover {
    text-decoration: underline;
  }
  
  .pay {
    background-color: var(--color-green-600);
    border: none;
    padding: 6px 24px;
    color: white;
    border-radius: 2px;
  }
  
  .pay:hover {
    background-color: #169645;
  }
</style>