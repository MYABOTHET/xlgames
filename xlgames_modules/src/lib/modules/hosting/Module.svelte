<script>
  import Information from "../../presets/shared/Information.svelte";
  import HorizontalLine from "../../components/shared/HorizontalLine.svelte";
  import Controls from "../../presets/shared/Controls.svelte";
  import {process} from "../../index.js";
  import AvailableOS from "../../components/shared/AvailableOS.svelte";
  import ButtonActive from "../../components/buttons/ButtonActive.svelte";
  import Spinner from "../../components/svgs/Spinner.svelte";
  import {onMount} from "svelte";
  import Button from "../../presets/buttons/Button.svelte";
  import {fade} from "svelte/transition";

  let information = $state.raw({
    ip: "127.0.0.1",
    login: "Default",
    password: "Default",
    available_os: [],
    os: "Windows 11",
    status: false,
    network: [],
    on: true,
    off: true,
    reboot: true
  });
  let status = $state(true);
  let loading_control = $state(false);
  let os = $state("Windows 11");
  let routes = [
    {
      title: language.info,
      Component: Info,
    },
    {
      title: language.reinstall_os_link,
      Component: ReinstallOS,
    },
    {
      title: language.reverse_dns,
      Component: ReverseDNS,
    },
    ...customRoutes
  ];
  let current_route = $state(routes[0].title);
  let route = $derived(routes.find(route => current_route === route.title).Component);
  let spinner = $state(true);
  let messagePanel = $state(false);
  let message = $state("");
  let gap = "gap-6";
  let dns = $state("");

  onMount(async () => {
    const response = await process("information");
    if (response.ok) {
      information = await response.json();
      status = information.status;
      os = information.available_os[0];
      network = information.network;
      dns = information.dns;
      spinner = false;
    } else {
      alert(await response.text());
      location.reload();
    }
  });

  function execute_action(action, complete = () => {
  }) {
    execute_loading(async () => {
      const result = await process(action, {
        method: "POST"
      });
      if (result.ok) complete();
      return result;
    });
  }

  async function execute_loading(callback) {
    loading_control = true;
    let res = await callback();
    if (!res.ok) {
      messagePanel = true;
      message = await res.text();
    }
    loading_control = false;
  }

  function reinstall_os() {
    execute_loading(async () => {
      const result = await process("reinstall", {
        method: "POST",
        body: JSON.stringify({os})
      });
      if (result !== false) location.reload();
    });
  }

  function reverse_dns() {
    execute_loading(() => {
      return process("dns", {
        method: "PUT",
        body: JSON.stringify({dns})
      });
    });
  }

  function setMessage(messageProp) {
    messagePanel = true;
    message = messageProp;
  }
</script>

{#if messagePanel}
  <div transition:fade={{duration: 75}}
       class="z-50 h-full w-full absolute flex justify-center items-center backdrop-blur-[1px]">
    <div class="flex flex-col gap-6 py-6 px-8 bg-(--color-xlgames-dark-400) border border-gray-700/90
border-dotted">
      <h1>{message}</h1>
      <Button class="w-fit mx-auto text-[15px]" title={language.close} onclick={() => {messagePanel = false}}/>
    </div>
  </div>
{/if}

{#snippet Info()}
  <section class="flex items-stretch {gap} max-[700px]:flex-col">
    <Information ip={information.ip} login={information.login} os={information.os}
                 password={information.password} status={status} class="mr-auto"/>
    <Controls {loading_control} class="ml-auto max-[700px]:ml-0"
              on={information.on ? () => {execute_action("on", () => {if (status !== "-") status = true})} : null}
              off={information.off ? () => {execute_action("off", () => {if (status !== "-") status = false})} : null}
              reboot={information.reboot ? () => {execute_action("reboot", () => {
                setMessage(language.copy_message);
              })} : null} {status}/>
  </section>
{/snippet}

{#snippet ReinstallOS()}
  {@html reinstall_html}
  <AvailableOS {loading_control} available_os={information.available_os} {reinstall_os} bind:os/>
{/snippet}

{#snippet ReverseDNS()}
  {@html reverse_dns_html}
  <div class="grid grid-cols-2 gap-6 text-nowrap max-[700px]:grid-rows-2 max-[700px]:grid-cols-1">
    <input class="outline-0 border border-dotted border-gray-700/90 px-4 placeholder-gray-500"
           placeholder={language.dns ?? "..."} bind:value={dns}>
    <Button class={loading_control ? 'opacity-40 pointer-events-none' : ''}
            onclick={reverse_dns} title={language.reverse_dns ?? "..."}/>
  </div>
{/snippet}

{#if spinner}
  <div class="absolute flex justify-center items-center size-full gap-6 flex-col">
    <Spinner class="w-16 fill-(--color-xlgames-orange-500)"/>
  </div>
{/if}

<section class="flex flex-col {gap} {spinner ? 'pointer-events-none opacity-0' : 'opacity-100'}">
  <section class="grid auto-cols-fr grid-flow-col text-[15px]
  max-[700px]:flex! max-[700px]:flex-col! {gap} gap-y-4">
    {#each routes as route}
      <ButtonActive class="truncate" title={route.title ?? "..."} onclick={() => {current_route = route.title}}
                    active={current_route === route.title}/>
    {/each}
  </section>
  <HorizontalLine/>
  {#if typeof route === "function"}
    {@render route()}
  {:else}
    {@html route}
  {/if}
</section>