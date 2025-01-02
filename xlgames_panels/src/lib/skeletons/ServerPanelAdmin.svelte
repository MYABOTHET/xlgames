<script>
  import Section from "../components/Section.svelte";
  import Input from "../components/Input.svelte";
  import Button from "../components/Button.svelte";
  import FreezeScreen from "../components/FreezeScreen.svelte";
  import Load from "./components/Load.svelte";
  import Select from "../components/Select.svelte";
  import ConfirmAdmin from "./components/ConfirmAdmin.svelte";
  
  let {
    key = $bindable(),
    setKey,
    loading,
    loading_message,
    have_error,
    error_message,
      new_language,
      create_new_language,
      languages,
      select_language,
      current_language,
      language_titles,
      save_language,
      have_confirm,
      close,
      delete_language,
      open,
      language,
      russian_language,
  } = $props();
</script>

<FreezeScreen class="max-w-425 w-full" freeze={have_confirm || have_error || loading}>
  <div class="flex flex-col gap-5">
    <Section title="Конфигурация">
      <div class="flex flex-col gap-2">
        <Input bind:value={key} placeholder="X-Token" color="sky"/>
        <Button class="w-full" color="green"
                onclick={setKey}>Сохранить ключ</Button>
      </div>
    </Section>
    <Section title="Добавить язык">
      <div class="flex flex-col gap-2">
        <Input bind:value={new_language} placeholder="Название языка" color="sky" />
        <Button color="green" onclick={create_new_language}>Добавить новый язык</Button>
      </div>
    </Section>
    {#if languages.length > 0}
      <Section title="Настройка переводов">
        <div class="flex flex-col gap-2">
          <Select method={select_language} value={current_language} items={language_titles}/>
          <Button color="green" onclick={save_language}>Сохранить язык</Button>
          <Button color="red" onclick={open}>Удалить язык</Button>
          {#each Object.entries(language) as item}
            {#each Object.entries(item[1]) as word}
              <Input color="black" class="placeholder-gray-600"
                     bind:value={language[item[0]][word[0]]}
                     placeholder={russian_language[item[0]][word[0]]}/>
            {/each}
          {/each}
          <!--{#each Object.entries(russian_language) as item}-->
          <!--  {#each Object.entries(item) as i}-->
          <!--    <Input bind:value={language[item][i][0]} placeholder={russian_language[item][i][1]}/>-->
          <!--  {/each}-->
          <!--{/each}-->
        </div>
      </Section>
    {/if}
  </div>
  {#snippet modal()}
  <div class="w-full h-full flex justify-center">
    <div class="h-fit my-40">
      {#if have_confirm}
        <ConfirmAdmin {close} {delete_language}/>
      {/if}
      {#if have_error}
        <span class="text-red-500 text-center">{error_message}</span>
      {/if}
      {#if loading}
        <Load {loading_message}/>
      {/if}
    </div>
  </div>
  {/snippet}
</FreezeScreen>
