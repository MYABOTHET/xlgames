<script>
  import StaticPrice from "../skeletons/StaticPrice.svelte";
  
  let url = window.location.href;
  let id = $state('');
  let price = $state('');
  let product = $state('');
  let have_error = $state(false);
  let error_message = $state('');
  let success_message = $state('');
  let loading = $state(false);
  let loading_message = $state('');
  
  function reset() {
    have_error = false;
    loading = false;
    error_message = '';
    success_message = '';
    loading_message = '';
  }
  
  function set_error(body) {
    have_error = true;
    error_message = body.error_message;
  }
  
  function set_success(body) {
    success_message = body.success_message;
  }
  
  async function get_product() {
    product = '';
    price = '';
    if (!id) {
      return;
    }
    reset();
    loading = true;
    loading_message = 'Ищем продукт';
    let response = await fetch(`${url}&operation=product&relid=${id}`);
    let body = await response.json();
    if (response.status === 200) {
      product = body;
    } else {
      set_error(body);
    }
    loading = false;
  }
  
  async function set_static_price() {
    if (!price) {
      return;
    }
    reset();
    loading = true;
    loading_message = 'Устанавливаем статическую цену';
    let formData = new FormData();
    formData.append("relid", id);
    formData.append("price", price);
    let response = await fetch(`${url}&operation=set_static_price`, {
      method: 'POST',
      body: formData
    });
    let body = await response.json();
    if (response.status === 200) {
      product.price = price;
      product.is_static = true;
      set_success(body);
    } else {
      set_error(body);
    }
    loading = false;
  }
  
  async function update_static_price() {
    reset();
    loading = true;
    loading_message = 'Обновляем все цены на заданные нами';
    await fetch(`${url}&operation=update_all_prices`, {
      method: 'POST',
    });
    loading = false;
  }
  
  async function delete_static_price() {
    if (!id) {
      return;
    }
    if (!product.is_static) {
      return;
    }
    reset();
    loading = true;
    loading_message = 'Удаляем статическую цену';
    let formData = new FormData();
    formData.append("relid", id);
    let response = await fetch(`${url}&operation=delete_static_price`, {
      method: 'POST',
      body: formData
    });
    let body = await response.json();
    if (response.status === 200) {
      product.is_static = false;
      set_success(body);
    } else {
      set_error(body);
    }
    loading = false;
  }
  
</script>

<StaticPrice bind:id bind:price {product} {have_error} {error_message} {success_message}
             {get_product} {set_static_price} {delete_static_price} {loading} {loading_message}
             {update_static_price}/>