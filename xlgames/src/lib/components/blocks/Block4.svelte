<script>
  import Link3 from "$lib/components/links/Link3.svelte";
  import Title1 from "$lib/components/titles/Title1.svelte";
  
  let {...props} = $props();
</script>

<div {...props}
     class="{props.class} hover:bg-xlgames-2 transition-colors border-2
      border-xlgames-4 rounded-2xl px-8 pt-8 pb-5 flex flex-col gap-y-8">
  <Title1>Выделенный сервер</Title1>
  <p>Выделенный сервер, это вид хостинга, при котором клиенту выделяется весь физический сервер и ресурсы,
    с полным удаленным доступом, подходит для высоконагруженных проектов</p>
  <Link3 href="/"/>
</div>