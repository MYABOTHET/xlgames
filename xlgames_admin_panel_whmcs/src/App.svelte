<svelte:options customElement={{
  tag: "xlgames-whmcs",
  props: {
    href_style: {type: 'String', attribute: 'href-style'}
  }
}}/>
<svelte:head>
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500&display=swap" rel="stylesheet">
</svelte:head>

<link rel="stylesheet" type="text/css" href={href_style}/>

<!-- Debug start -->
<!--{#key style}-->
<!--  <link rel="stylesheet" type="text/css" href={href_style}/>-->
<!--{/key}-->
<!-- Debug end -->

<script>
  import {onMount} from "svelte";
  import AdminPage from "./lib/pages/AdminPage.svelte";
  
  let {href_style} = $props();
  let parent;
  // let style = $state(false);
  
  onMount(() => {
    let contentarea = document.getElementById("contentarea");
    if (contentarea) {
      let h1_array = contentarea.getElementsByTagName("h1");
      if (h1_array.length > 0) h1_array[0].remove();
    }
    // let observer = new MutationObserver(_ => {
    //   style = !style;
    // });
    // Debug start
    // observer.observe(parent, {
    //   childList: true,
    //   subtree: true,
    // });
    // Debug end
    return () => {
      // observer.disconnect();
    }
  })
</script>

<div style="all: initial;" bind:this={parent}>
  <div class="font-roboto font-light tracking-wide text-3xl">
    <AdminPage />
  </div>
</div>

<div class="min-h-[60rem]"></div>