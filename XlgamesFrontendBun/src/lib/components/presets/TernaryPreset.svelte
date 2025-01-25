<script>
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  
  let {title, object = $bindable(), ...props} = $props();
</script>

<div {...props} class="{props.class} flex flex-col gap-y-[inherit] border border-(--color-hexadecimal)
w-fit max-w-full px-5 py-4">
  <h1 class="text-base font-normal">{title}</h1>
  <PrimaryTextarea bind:value={object.Name} title="Заголовок"/>
  <PrimaryTextarea bind:value={object.Description} title="Описание"/>
</div>