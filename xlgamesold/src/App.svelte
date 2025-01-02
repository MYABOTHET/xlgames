<svelte:options customElement={{
  tag: "xlgames-component",
  props: {
    css: {reflect: true, type: 'String'},
    light_theme: {reflect: true, type: 'String'}
  }
}} />

<svelte:head>
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400&display=swap" rel="stylesheet">
</svelte:head>

<link rel="stylesheet" type="text/css" href="{css}"/>

<script>
  // import ServerPanelAdmin from "./lib/pages/ServerPanelAdmin.svelte";
  import ServerPanelClient from "./lib/pages/ServerPanelClient.svelte";
  // import ServerPanelClientSurvivalHost from "./lib/pages/ServerPanelClientSurvivalHost.svelte";
  
  let {css, light_theme} = $props();
  
  let light = light_theme === "yes";
</script>

<div class="{light ? 'text-gray-300' : 'text-black'} font-roboto text-start font-light text-base">
<!--  <ServerPanelAdmin />-->
  <ServerPanelClient {light}/>
<!--  <ServerPanelClientSurvivalHost {light}/>-->
</div>