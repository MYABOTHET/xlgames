<script>
  import PrimaryButton from "$lib/components/buttons/PrimaryButton.svelte";
  
  const {access, buttonClass, title = "Сохранить", saved = "Сохранено", error = "Произошла ошибка", onclick, ...props} = $props();
</script>

<div {...props} class="{props.class} flex items-center gap-x-6">
  <PrimaryButton class={buttonClass} {onclick}>{title}</PrimaryButton>
  {#if access !== null}
    <h1 class="{access ? 'text-green-600' : 'text-red-600'} text-sm">{access ? saved : error}...</h1>
  {/if}
</div>