<script>
  // import ServerPanelClient from "./lib/pages/ServerPanelClient.svelte";
  // import ServerPanelClientSurvivalHost from "./lib/pages/ServerPanelClientSurvivalHost.svelte";
  import ServerPanelClientReliable from "./lib/pages/ServerPanelClientReliable.svelte";
</script>

<div class="abothet_panels">
  <div class="{light ? 'text-gray-300' : 'text-black'} font-roboto text-start font-light text-base">
<!--     <ServerPanelClient {light}/>-->
<!--     <ServerPanelClientSurvivalHost {light}/> -->
    <ServerPanelClientReliable {light}/>
  </div>
</div>