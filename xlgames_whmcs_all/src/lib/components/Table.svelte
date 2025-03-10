<script>
  let {Head, Body, ...props} = $props();
</script>

<div {...props} class="{props.class} border border-slate-300 rounded-md overflow-auto text-xl">
  <table class="h-0 w-full">
    <thead>
    <Head/>
    </thead>
    <tbody>
    <Body/>
    </tbody>
  </table>
</div>