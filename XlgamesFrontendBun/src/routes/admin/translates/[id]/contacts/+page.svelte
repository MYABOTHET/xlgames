<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";
  import PrimaryCheckbox from "$lib/components/checkbox/PrimaryCheckbox.svelte";
  
  let language = getContext("language")();
</script>

<SecondaryPage title="Контакты">
  <QuaternarySection title="Важное">
    <PrimaryTextarea bind:value={language.Contacts.Title} title="Название страницы"/>
    <PrimaryTextarea bind:value={language.Contacts.Head} title="Метаданные"/>
  </QuaternarySection>
  <QuaternarySection title="Остальное">
    <PrimaryTextarea bind:value={language.Contacts.Name} title="Заголовок"/>
    <PrimaryTextarea bind:value={language.Contacts.Description} title="Описание"/>
    <PrimaryTextarea bind:value={language.Contacts.FullName} title="ФИО"/>
    <PrimaryTextarea bind:value={language.Contacts.PhoneNumber} title="Номер телефона"/>
    <PrimaryTextarea bind:value={language.Contacts.Email} title="Почта"/>
    <PrimaryTextarea bind:value={language.Contacts.OGRNIP} title="ОГРНИП"/>
    <PrimaryTextarea bind:value={language.Contacts.INN} title="ИНН"/>
    <PrimaryTextarea bind:value={language.Contacts.IP} title="ИП"/>
    <PrimaryTextarea bind:value={language.Contacts.SubTitle} title="Подзаголовок"/>
    <PrimaryCheckbox bind:value={language.Contacts.SubTitleShow} title="Показывать подзаголовок?"/>
  </QuaternarySection>
</SecondaryPage>