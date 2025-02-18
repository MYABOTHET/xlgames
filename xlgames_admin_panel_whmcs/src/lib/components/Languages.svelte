<script>
  import Select from "../components-old/Select.svelte";
  import TernaryButton from "./buttons/TernaryButton.svelte";
  import QuaternaryButton from "./buttons/QuaternaryButton.svelte";
  import SecondaryInput from "./inputs/SecondaryInput.svelte";
  import SecondaryEnum from "./enums/SecondaryEnum.svelte";
  
  let {languages, language_content = $bindable(), value, items, method, create_new_language,
    name_new_language = $bindable(), save_language, delete_language, ...props} = $props();
  
  let counter = $state(5);
  
  $effect(() => {
    language_content;
    counter = 5;
  })
  
  function delete_lang() {
    counter--;
    if (counter <= 0) {
      delete_language();
    }
  }
</script>

<div {...props} class="{props.class} flex flex-col gap-y-2">
  <div class="max-w-[44rem] gap-y-2 flex flex-col">
    <SecondaryInput bind:value={name_new_language} placeholder="Новый язык..."></SecondaryInput>
    <TernaryButton class="w-full" onclick={create_new_language}>Добавить новый язык</TernaryButton>
    <Select {value} {items} {method}/>
  </div>
  {#if language_content !== ''}
    <div class="max-w-[44rem] flex gap-x-2">
      <TernaryButton class="w-full" onclick={save_language}>Сохранить</TernaryButton>
      <QuaternaryButton class="w-full" onclick={delete_lang}>Удалить ({counter})</QuaternaryButton>
    </div>
    <div class="flex flex-col gap-y-2">
      <SecondaryEnum placeholder="Язык в WHMCS" bind:value={language_content.original_name}>- Язык в WHMCS (Пример: russian)</SecondaryEnum>
      <SecondaryEnum placeholder="Информация о системе" bind:value={language_content.system_info_title}>- Информация о системе</SecondaryEnum>
      <SecondaryEnum placeholder="Переустановка операционной системы" bind:value={language_content.reinstall_os_title}>- Переустановка операционной системы</SecondaryEnum>
      <SecondaryEnum placeholder="Сетевая статистика" bind:value={language_content.network_statistics_title}>- Сетевая статистика</SecondaryEnum>
      <SecondaryEnum placeholder="Состояние" bind:value={language_content.status}>- Состояние</SecondaryEnum>
      <SecondaryEnum placeholder="Система" bind:value={language_content.os}>- Система</SecondaryEnum>
      <SecondaryEnum placeholder="IP" bind:value={language_content.ip}>- IP</SecondaryEnum>
      <SecondaryEnum placeholder="Логин" bind:value={language_content.login}>- Логин</SecondaryEnum>
      <SecondaryEnum placeholder="Пароль" bind:value={language_content.password}>- Пароль</SecondaryEnum>
      <SecondaryEnum placeholder="Пароль скоро будет недоступен" bind:value={language_content.note}>- Пароль скоро будет недоступен</SecondaryEnum>
      <SecondaryEnum placeholder="Недоступен" bind:value={language_content.not_available}>- Недоступен</SecondaryEnum>
      <SecondaryEnum placeholder="Включен" bind:value={language_content.on}>- Включен</SecondaryEnum>
      <SecondaryEnum placeholder="Выключен" bind:value={language_content.off}>- Выключен</SecondaryEnum>
      <SecondaryEnum placeholder="Включить" bind:value={language_content.on_control_panel}>- Включить</SecondaryEnum>
      <SecondaryEnum placeholder="Выключить" bind:value={language_content.off_control_panel}>- Выключить</SecondaryEnum>
      <SecondaryEnum placeholder="Перезагрузить" bind:value={language_content.reboot_control_panel}>- Перезагрузить</SecondaryEnum>
      <SecondaryEnum placeholder="Переустановить систему" bind:value={language_content.reinstall}>- Переустановить систему</SecondaryEnum>
      <SecondaryEnum placeholder="Подтвердить" bind:value={language_content.confirm}>- Подтвердить</SecondaryEnum>
      <SecondaryEnum placeholder="Отмена" bind:value={language_content.cancel}>- Отмена</SecondaryEnum>
      <SecondaryEnum placeholder="Напишите|Пробел|" bind:value={language_content.start}>- Напишите|Пробел|</SecondaryEnum>
      <SecondaryEnum placeholder="Я согласен" bind:value={language_content.middle}>- Я согласен</SecondaryEnum>
      <SecondaryEnum placeholder="Ключевое слово" bind:value={language_content.keyword}>- Ключевое слово</SecondaryEnum>
      <SecondaryEnum placeholder=", чтобы подтвердить переустановку операционной системы." bind:value={language_content.end}>-|Пробел|, чтобы подтвердить переустановку операционной системы.</SecondaryEnum>
      <SecondaryEnum placeholder="После переустановки операционной системы ВСЕ данные будут удалены НАВСЕГДА!" bind:value={language_content.warning}>- После переустановки операционной системы ВСЕ данные будут удалены НАВСЕГДА!</SecondaryEnum>
      <SecondaryEnum placeholder="Входящая" bind:value={language_content.in}>- Входящая</SecondaryEnum>
      <SecondaryEnum placeholder="Исходящая" bind:value={language_content.out}>- Исходящая</SecondaryEnum>
      <SecondaryEnum placeholder="Бит" bind:value={language_content.bit}>- Бит</SecondaryEnum>
      <SecondaryEnum placeholder="Кбит" bind:value={language_content.kbit}>- КБит</SecondaryEnum>
      <SecondaryEnum placeholder="Мбит" bind:value={language_content.mbit}>- МБит</SecondaryEnum>
      <SecondaryEnum placeholder="Гбит" bind:value={language_content.gbit}>- ГБит</SecondaryEnum>
      <SecondaryEnum placeholder="Тбит" bind:value={language_content.tbit}>- ТБит</SecondaryEnum>
      <SecondaryEnum placeholder="с (Секунда)" bind:value={language_content.second}>- с (Секунда)</SecondaryEnum>
      <SecondaryEnum placeholder="Вперед" bind:value={language_content.next}>- Вперед</SecondaryEnum>
      <SecondaryEnum placeholder="Назад" bind:value={language_content.back}>- Назад</SecondaryEnum>
      <SecondaryEnum placeholder="Загрузка данных" bind:value={language_content.data}>- Загрузка данных</SecondaryEnum>
      <SecondaryEnum placeholder="Загрузка сетевой статистики" bind:value={language_content.network_statistics}>- Загрузка сетевой статистики</SecondaryEnum>
      <SecondaryEnum placeholder="Включаем систему" bind:value={language_content.on_loading}>- Включаем систему</SecondaryEnum>
      <SecondaryEnum placeholder="Выключаем систему" bind:value={language_content.off_loading}>- Выключаем систему</SecondaryEnum>
      <SecondaryEnum placeholder="Перезагружаем систему" bind:value={language_content.reboot_loading}>- Перезагружаем систему</SecondaryEnum>
      <SecondaryEnum placeholder="Выполняется переустановка операционной системы" bind:value={language_content.reinstall_loading}>- Выполняется переустановка операционной системы</SecondaryEnum>
      <SecondaryEnum placeholder="Операция не найдена" bind:value={language_content.operation_not_found}>- Операция не найдена</SecondaryEnum>
      <SecondaryEnum placeholder="Ключ не найден" bind:value={language_content.key_not_found}>- Ключ не найден</SecondaryEnum>
      <SecondaryEnum placeholder="Невалидный ключ" bind:value={language_content.invalid_key}>- Невалидный ключ</SecondaryEnum>
      <SecondaryEnum placeholder="Вам не выдали сервер" bind:value={language_content.server_not_assigned}>- Вам не выдали сервер</SecondaryEnum>
      <SecondaryEnum placeholder="Сервер не найден" bind:value={language_content.server_not_found}>- Сервер не найден</SecondaryEnum>
      <SecondaryEnum placeholder="Неизвестная ошибка" bind:value={language_content.unknown}>- Неизвестная ошибка</SecondaryEnum>
    </div>
  {/if}
</div>