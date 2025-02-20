<script>
  const {payment_method = $bindable(), callback, ...props} = $props();
  
  let count = $state(5);
  
  function click() {
    count--;
    if (count <= 0) {
      callback(payment_method.id);
      count = 5;
    }
  }
</script>

<div {...props} class="{props.class} secondary_block border_block">
  <div class="primary_block">
    <input bind:value={payment_method.bank_name} placeholder="Название банка" readonly>
    <input bind:value={payment_method.card_number} placeholder="Номер карты" readonly>
    <button onclick={click}>Удалить ({count})</button>
  </div>
</div>