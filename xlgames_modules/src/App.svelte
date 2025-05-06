<svelte:options customElement="xlgames-module" />

<script>
  import css from "./app.css?inline";
  import Hetzner from "./lib/modules/presets/Hetzner.svelte";
</script>

{@html `<style>${css}</style>`}

<section class="xlgames-module">
  <Hetzner/>
  <!--  <DeinServerHost/>-->
  <!--  <OVHcloud/>-->
</section>