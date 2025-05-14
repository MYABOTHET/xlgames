<svelte:options customElement="xlgames-module" />
<script>
  import css from "./app.css?inline";
  import Module from "./lib/modules/hosting/Module.svelte";
</script>
{@html `<style>${css}</style>`}
<section class="xlgames-module">
  <Module/>
</section>

<!--<svelte:options customElement={{-->
<!--  tag: "schedule-module",-->
<!--  shadow: "none",-->
<!--}}/>-->
<!--<script>import ScheduleModule from "./lib/modules/hosting/ScheduleModule.svelte";</script>-->
<!--<ScheduleModule/>-->