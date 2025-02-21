<script>
  import Enum from "./Enum.svelte";
  
  const {payment, paid, unpaid, ...props} = $props();
  
  let count_paid = $state(5);
  let count_unpaid = $state(5);
  
  function this_paid() {
    count_paid--;
    if (count_paid <= 0) {
      paid(payment.id);
      count_paid = 5;
    }
  }
  
  function this_unpaid() {
    count_unpaid--;
    if (count_unpaid <= 0) {
      unpaid(payment.id);
      count_unpaid = 5;
    }
  }
  
  let formatter = new Intl.DateTimeFormat("ru", {
    month: "long",
    day: "numeric",
    hour: "numeric",
    minute: "numeric",
  });
  
  function get_time(date) {
    try {
      return formatter.format(new Date(parseInt(date)));
    } catch {
      return "Ошибка";
    }
  }
</script>

<div {...props} class="{props.class} border_block">
  <Enum title="Invoice ID">
    <a title="Ссылка на счёт" href="https://xlgames.gg/store/admin/invoices.php?action=edit&id={payment.invoice_id}"
    >{payment.invoice_id}</a>
  </Enum>
  <Enum title="Клиент">{payment.fio} - <a href="https://xlgames.gg/store/admin/clientssummary.php?userid={payment.user_id}">{payment.user_id}</a></Enum>
  <Enum title="Куда">{payment.data}</Enum>
  <Enum title="Метод">{payment.bank}</Enum>
  <Enum title="Цена">≈ {payment.price} RUB</Enum>
  <Enum title="Время">≈ {get_time(payment.date)}</Enum>
  <div class="control">
    <button onclick={this_paid}>Оплачено ({count_paid})</button>
    <button onclick={this_unpaid}>Удалить ({count_unpaid})</button>
  </div>
</div>

<style>
  .control {
    margin-top: 8px;
    display: flex;
    gap: 8px;
  }
  button {
    width: 100%;
    text-wrap: nowrap;
  }
</style>