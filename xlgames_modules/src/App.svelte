<svelte:options customElement="xlgames-module" />

<script>
  let { language } = $props();

  language = JSON.parse(language);
</script>

{language.unknown_error}