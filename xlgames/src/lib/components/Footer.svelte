<script>
  import ProjectLogo from "$lib/components/icons/components/ProjectLogo.svelte";
  import Link1 from "$lib/components/links/Link1.svelte";
  import Link5 from "$lib/components/links/Link5.svelte";
  import VK from "$lib/components/icons/svg/VK.svelte";
  
  let {...props} = $props();
</script>

<footer {...props}
        class="{props.class} mt-auto flex justify-center w-full items-center border-t border-t-xlgames-2">
  <div class="max-w-screen-xlgames-1 gap-y-8 px-4 w-full h-full flex flex-col justify-between items-center pt-12 pb-8
min-h-64">
    <div class="w-full flex gap-x-14 items-start">
      <div class="flex flex-col gap-y-4 flex-1">
        <a href="/">
          <ProjectLogo mini_title="XL" title="XLGAMES.GG"/>
        </a>
        <div class="flex flex-wrap gap-2">
          {#each new Array(1) as _}
            <Link5 href="/">
              <VK class="size-8"/>
            </Link5>
          {/each}
        </div>
      </div>
      <nav class="grid grid-cols-3 gap-x-4 gap-y-2 w-full">
        <Link1 class="w-fit" href="/games">Игровые серверы</Link1>
        <Link1 class="w-fit" href="/dedicated">Сервера</Link1>
        <Link1 class="w-fit" href="/gpu-servers">Сервера для ИИ</Link1>
        <Link1 class="w-fit" href="/vps">VPS</Link1>
        <Link1 class="w-fit" href="/web-hosting">Веб хостинг</Link1>
        <Link1 class="w-fit" href="/vpn">VPN</Link1>
        <Link1 class="w-fit" href="/vpn">Контакты</Link1>
        <Link1 class="w-fit" href="/vpn">О нас</Link1>
        <Link1 class="w-fit" href="/vpn">Новости</Link1>
        <Link1 class="w-fit" href="/vpn">Центр обработки данных</Link1>
      </nav>
    </div>
    <div class="w-full justify-center flex gap-x-4 text-xlgames-4 text-xs">
      <h1>© 2024 XLGAMES.GG</h1>
      <a class="hover:text-xlgames-3 transition-colors" href="/">Условия обслуживания</a>
      <a class="hover:text-xlgames-3 transition-colors" href="/">Политика конфиденциальности</a>
    </div>
  </div>
</footer>