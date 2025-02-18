<script>
  import AdminTemplate from "../templates/AdminTemplate.svelte";
  import Admin from "../services/Admin.js";
  import Tools from "../services/Tools.js";
  import {onMount} from "svelte";
  
  let keys = $state({
    selectel: {
      name: "Selectel",
      key: ""
    },
    survivalhost: {
      name: "SurvivalHost",
      key: ""
    },
  });
  let saving = $state(false);
  let saving_message = $state("Выполняется сохранение данных...");
  let error = $state(false);
  let error_message = $state("Произошла ошибка");
  let loading = $state(true);
  let loading_message = $state("Загрузка ключей...");
  let loading_error_message = $state("Произошла ошибка");
  let loading_status = $state(true);
  let links = [
    {
      name: "Ключи",
      href: "keys"
    },
    {
      name: "Языки",
      href: "languages"
    },
    {
      name: "Статические цены",
      href: "static_price"
    }
  ];
  let current_link = $state(links[0].href);
  let languages = $state([]);
  let current_language = $state('Выберите язык');
  let language_content = $state('');
  let name_new_language = $state('');
  
  async function change_language(new_language) {
    set_error('');
    if (current_language === new_language) return;
    language_content = '';
    loading = true;
    loading_message = "Меняем язык...";
    let res = await Admin.get_language(new_language);
    let body = await res.json();
    language_content = body;
    current_language = new_language;
    loading = false;
  }
  
  async function save_language() {
    set_error('');
    if (saving) return;
    saving_on();
    saving_message = "Сохраняем язык..."
    try {
      let res = await Admin.update_language($state.snapshot(language_content), true);
      let body = await res.json();
      if (res.status !== 200) {
        set_error(Tools.parse_error(body));
      }
    } catch (e) {
      set_error("На сервере произошла неизвестная ошибка");
    }
    saving_off();
  }
  
  async function delete_language() {
    set_error('');
    loading = true;
    loading_message = "Удаляем язык...";
    let old_language_content = language_content;
    let old_current_language = current_language;
    language_content = '';
    current_language = 'Выберите язык';
    let res = await Admin.delete_language(old_current_language);
    let body = await res.json();
    if (res.status !== 200) {
      set_error(Tools.parse_error(body));
      language_content = old_language_content;
      current_language = old_current_language;
    } else {
      languages = languages.filter(l => l !== old_current_language);
    }
    loading = false;
  }
  
  async function create_new_language() {
    set_error('');
    if (name_new_language === "" || languages.includes(name_new_language)) return;
    language_content = '';
    loading = true;
    loading_message = "Создаем новый язык...";
    let copy_name = name_new_language;
    name_new_language = "";
    try {
      let language_eng = await (await Admin.get_language('Английский')).json();
      language_eng.name = copy_name;
      language_eng.original_name = "";
      language_eng.id = "";
      language_eng.original_name = null;
      let res = await Admin.update_language(language_eng);
      let body = await res.json();
      if (res.status !== 200) {
        set_error(Tools.parse_error(body));
        loading = false;
        return;
      }
      languages.push(copy_name)
      language_content = language_eng;
      current_language = copy_name;
    } catch (e) {
      set_error("На сервере произошла неизвестная ошибка");
    }
    loading = false;
  }
  
  onMount(async () => {
    try {
      let res = await Admin.get_keys();
      let body = await res.json();
      if (res.status !== 200) {
        loading_error_message = Tools.parse_error(body);
        loading_status = false;
      } else {
        keys = body;
      }
      loading_message = "Загрузка языков...";
      res = await Admin.get_languages();
      body = await res.json();
      if (res.status !== 200) {
        loading_error_message = Tools.parse_error(body);
        loading_status = false;
      } else {
        languages = body;
      }
    } catch (e) {
      loading_error_message = "Сервер отдал сломанные данные...";
      loading_status = false;
    }
    loading = false;
  });
  
  async function save_keys() {
    set_error('');
    if (saving) return;
    saving_on();
    saving_message = "Выполняется сохранение данных...";
    try {
      let res = await Admin.save_keys($state.snapshot(keys));
      let body = await res.json();
      if (res.status !== 200) {
        set_error(Tools.parse_error(body));
      }
    } catch (e) {
      set_error("Произошла неизвестная ошибка на сервере");
    }
    saving_off();
  }
  
  function saving_on() {
    saving = true;
    error = false;
  }
  
  function saving_off() {
    saving = false;
  }
  
  function set_error(message) {
    error = true;
    error_message = message;
  }
  
  // Static price (Start)
  let url = window.location.href;
  let id = $state('');
  let price = $state('');
  let product = $state('');
  let success_message = $state('');
  
  function reset() {
    error = false;
    loading = false;
    error_message = '';
    success_message = '';
    loading_message = '';
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
    let response = await fetch(`${url}&method=product&relid=${id}`);
    let body = await response.json();
    if (response.status === 200) {
      product = body;
    } else {
      set_error(Tools.parse_error(body));
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
    let response = await fetch(`${url}&method=set_static_price`, {
      method: 'POST',
      body: formData
    });
    let body = await response.json();
    if (response.status === 200) {
      product.price = price;
      product.is_static = true;
      set_success(body);
    } else {
      set_error(Tools.parse_error(body));
    }
    loading = false;
  }
  
  async function update_static_price() {
    reset();
    product = '';
    price = '';
    id = '';
    loading = true;
    loading_message = 'Обновляем все цены на заданные нами';
    await fetch(`${url}&method=update_all_prices`, {
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
    let response = await fetch(`${url}&method=delete_static_price`, {
      method: 'POST',
      body: formData
    });
    let body = await response.json();
    if (response.status === 200) {
      product.is_static = false;
      set_success(body);
    } else {
      set_error(Tools.parse_error(body));
    }
    loading = false;
  }
  // Static price (end)
</script>

<AdminTemplate bind:keys bind:current_link {links} {saving} {saving_message} {save_keys} {error} {error_message}
               {loading} {loading_status} {loading_error_message} {loading_message} {languages} {change_language}
               {current_language} {create_new_language} bind:name_new_language bind:language_content
               {save_language} {delete_language}
               
               bind:id bind:price {product} {success_message} {get_product} {set_static_price}
               {delete_static_price} {update_static_price}
/>