<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";
  import SaveForm from "$lib/components/SaveForm.svelte";
  import PrimaryCheckbox from "$lib/components/checkbox/PrimaryCheckbox.svelte";
  
  let gameServer = getContext("gameServer")();
  let counter = $derived(getContext("counter")());
  let access = $derived(getContext("access")());
  let error = $derived(getContext("error")());
  let deleteGameServer = getContext("deleteGameServer");
  let updateGameServer = getContext("updateGameServer");
</script>

<SecondaryPage title="Настройки игрового сервера «{gameServer.Name}»">
  <QuaternarySection title="Идентификационные данные">
    <PrimaryTextarea bind:value={gameServer.Name} title="Название игрового сервера"/>
    <PrimaryTextarea bind:value={gameServer.CPU} title="Процессор"/>
    <PrimaryTextarea bind:value={gameServer.RAM} title="Тип ОЗУ"/>
    <PrimaryTextarea bind:value={gameServer.Disk} title="Тип диска"/>
    <PrimaryTextarea bind:value={gameServer.Slots} title="Кол-во слотов (Символ «-» значит 'Неограничено')"/>
  </QuaternarySection>
  <QuaternarySection title="Ссылки">
    <PrimaryTextarea bind:value={gameServer.Link} title="Ссылка на продукт"/>
    <PrimaryTextarea bind:value={gameServer.Src} title="Ссылка на изображение"/>
  </QuaternarySection>
  <QuaternarySection title="Доступы">
    <PrimaryCheckbox bind:value={gameServer.ControlPanel} title="Панель управления"/>
    <PrimaryCheckbox bind:value={gameServer.FTP} title="FTP"/>
  </QuaternarySection>
  <QuaternarySection title="Страны">
    <PrimaryCheckbox bind:value={gameServer.Germany} title="Германия"/>
    <PrimaryCheckbox bind:value={gameServer.Finland} title="Финляндия"/>
    <PrimaryCheckbox bind:value={gameServer.Russia} title="Россия"/>
    <PrimaryCheckbox bind:value={gameServer.USA} title="США"/>
    <PrimaryCheckbox bind:value={gameServer.Singapore} title="Сингапур"/>
  </QuaternarySection>
  <QuaternarySection title="Остальное">
    <PrimaryCheckbox bind:value={gameServer.isPopular} title="Популярен?"/>
  </QuaternarySection>
  <SaveForm {access} class="*:first:min-w-40" {error} onclick={updateGameServer}/>
  <button class="min-w-40 mt-4 px-5 border-2 bg-red-500 border-red-500 rounded
  text-nowrap text-(--color-primary) transition-colors hover:bg-(--color-primary) hover:text-white
  min-h-9 text-sm" onclick={deleteGameServer}>Удалить ({counter})
  </button>
</SecondaryPage>