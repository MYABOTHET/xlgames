<script module>
  let projectDataCache = null;
</script>

<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import SaveForm from "$lib/components/SaveForm.svelte";
  import {onMount} from "svelte";
  
  const {data} = $props();
  let projectData = $state(data.projectData);
  
  let access = $state(null);
  let error = $state(null);
  
  async function save() {
    access = null;
    error = null;
    const response = await fetch("/admin/project", {
      method: "PUT",
      body: JSON.stringify(projectData),
      headers: {
        'Content-Type': 'application/json'
      }
    });
    if (response.status === 200) {
      access = true;
    } else {
      access = false;
      error = await response.text();
    }
  }
  
  onMount(() => {
    projectDataCache ? projectData = projectDataCache : null;
    return () => {
      projectDataCache = projectData;
    };
  });
</script>

<SecondaryPage title="Данные проекта">
  <QuaternarySection title="Общие">
    <PrimaryTextarea bind:value={projectData.Logo} title="Логотип"/>
    <PrimaryTextarea bind:value={projectData.Name} title="Наименование"/>
    <PrimaryTextarea bind:value={projectData.Year} title="Год создания"/>
    <PrimaryTextarea bind:value={projectData.Head} title="Метаданные"/>
  </QuaternarySection>
  <QuaternarySection title="Контакты">
    <PrimaryTextarea bind:value={projectData.Email} title="Почта"/>
    <PrimaryTextarea bind:value={projectData.PhoneNumber} title="Номер телефона"/>
    <PrimaryTextarea bind:value={projectData.OGRNIP} title="ОГРНИП"/>
    <PrimaryTextarea bind:value={projectData.INN} title="ИНН"/>
  </QuaternarySection>
  <QuaternarySection title="Другие ссылки">
    <PrimaryTextarea bind:value={projectData.Contacts} title="Контакты"/>
    <PrimaryTextarea bind:value={projectData.PersonalAccount} title="Персональный аккаунт"/>
    <PrimaryTextarea bind:value={projectData.GameHosting} title="Игровой хостинг"/>
  </QuaternarySection>
  <SaveForm {access} {error} onclick={save}/>
</SecondaryPage>