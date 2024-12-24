<script>
  import ServerPanelAdmin from "../skeletons/ServerPanelAdmin.svelte";
  import {onMount} from "svelte";
  
  let url = window.location.href;
  let key = $state('');
  let have_error = $state(false);
  let error_message = $state('');
  let success_message = $state('');
  let loading = $state(false);
  let loading_message = $state('');
  let languages = $state([]);
  let new_language = $state('');
  let have_confirm = $state(false);
  let russian_language = $state('');
  
  let language = $state('');
  let current_language = $state('-');
  let language_titles = $state(['-']);
  
  onMount(async () => {
    loading = true;
    try {
      loading_message = 'Получаем ключ';
      key = (await handle(await getKey())).key;
      languages = (await handle(await get_languages()));
      for (let i = 0; i < languages.length; i++) {
        languages[i].language = JSON.parse(languages[i].language);
      }
      if (languages.length > 0) {
        language_titles = [];
        languages.forEach((item) => {
          if (item.name === 'russian') {
            russian_language = item.language;
          }
          language_titles.push(item.name);
        });
        current_language = languages[0].name;
        language = languages[0].language;
      }
    } catch (err) {
      have_error = true;
      error_message = err.message;
    }
    loading = false;
  });
  
  async function handle(response) {
    let body = await response.json();
    if (response.status !== 200) {
      throw new Error(body.error_message);
    }
    return body;
  }
  
  async function setKey() {
    loading = true;
    loading_message = 'Сохраняем ключ';
    let formData = new FormData();
    formData.append('key', key);
    let response = await fetch(`${url}&operation=key`, {
      method: 'POST',
      body: formData
    });
    let body = await response.json();
    if (response.status !== 200) {
      have_error = true;
      error_message = body.error_message;
    }
    loading = false;
  }
  
  async function getKey() {
    return await fetch(`${url}&operation=key`);
  }
  
  async function get_languages() {
    return await fetch(`${url}&operation=languages`);
  }
  
  async function create_new_language() {
  
  }
  
  function select_language(new_language) {
    languages.forEach((item) => {
      if (item.name === new_language) {
        current_language = item.name;
        language = item.language;
      }
    });
  }
  
  async function save_language() {
    console.log(russian_language);
  }
  
  async function delete_language() {
  
  }
  
  function close() {
    have_confirm = false;
  }
  
  function open() {
    have_confirm = true;
  }
</script>

<ServerPanelAdmin bind:key {have_error} {error_message} {success_message} {loading} {loading_message} {setKey}
                  {languages} {new_language} {create_new_language} {select_language} {current_language}
                  {language_titles} {save_language} {delete_language} {have_confirm} {close} {open}
                  {russian_language} {language}/>