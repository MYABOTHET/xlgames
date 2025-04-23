<svelte:options customElement="xlgames-module" />

<script>
  import css from "./app.css?inline";
  import OVHcloud from "./lib/modules/OVHcloud.svelte";

  const style = `<style>${css}</style>`;
</script>

{@html style}

<section>
  <OVHcloud/>
</section>