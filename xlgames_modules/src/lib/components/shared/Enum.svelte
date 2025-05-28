<script module>
  export {Status, Password, PasswordDeleted};
</script>

<script>
  import HorizontalLine from "./HorizontalLine.svelte";
  import EnumContent from "./EnumContent.svelte";

  let {children, title, ...props} = $props();
</script>

{#snippet Status(content, status)}
  <h1 class="{status ? 'text-green-500' : 'text-red-500'}">{content}</h1>
{/snippet}

{#snippet PasswordDeleted()}
  <h1 class="text-gray-600">{language.password_deleted}</h1>
{/snippet}

{#snippet Password(content, show)}
  <div class="flex flex-col gap-1">
    <EnumContent {content}/>
    <h1 class="text-lg text-red-500">* {language.password_deleted_soon}</h1>
  </div>
{/snippet}

<article {...props} class="{props.class} flex gap-1 items-start">
  <div class="flex gap-5 items-center">
    <div class="size-2 rounded-full bg-gray-700/90"></div>
    <h1 class="text-nowrap">{title}</h1>
  </div>
  <HorizontalLine class="w-full min-w-12 ml-2 min-h-8"/>
</article>
<article class="flex gap-3 items-center">
  {@render children?.()}
</article>