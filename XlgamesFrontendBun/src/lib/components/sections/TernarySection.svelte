<script>
  import Vk from "$lib/components/svg/messengers/Vk.svelte";
  import Whatsapp from "$lib/components/svg/messengers/Whatsapp.svelte";
  import Discord from "$lib/components/svg/messengers/Discord.svelte";
  import Instagram from "$lib/components/svg/messengers/Instagram.svelte";
  import Snapchat from "$lib/components/svg/messengers/Snapchat.svelte";
  import Telegram from "$lib/components/svg/messengers/Telegram.svelte";
  import Twitter from "$lib/components/svg/messengers/Twitter.svelte";
  import Facebook from "$lib/components/svg/messengers/Facebook.svelte";
  import {getContext} from "svelte";
  import SecondaryIcon from "$lib/components/icons/SecondaryIcon.svelte";
  
  const {projectData, ...props} = $props();
  
  let language = $derived(getContext("language")());
</script>

{#snippet icon(Icon, href)}
  <a class="w-fit" {href} rel="nofollow">
    <SecondaryIcon {Icon} class="primary-size fill-(--color-quaternary)"></SecondaryIcon>
  </a>
{/snippet}

{#if
    language.Shared.Vk
    || language.Shared.Whatsapp
    || language.Shared.Discord
    || language.Shared.Instagram
    || language.Shared.Snapchat
    || language.Shared.Telegram
    || language.Shared.Twitter
    || language.Shared.Facebook
}
  <nav {...props} class="{props.class}">
    {#if language.Shared.Vk}{@render icon?.(Vk, projectData.Vk)}{/if}
    {#if language.Shared.Whatsapp}{@render icon?.(Whatsapp, projectData.Whatsapp)}{/if}
    {#if language.Shared.Discord}{@render icon?.(Discord, projectData.Discord)}{/if}
    {#if language.Shared.Instagram}{@render icon?.(Instagram, projectData.Instagram)}{/if}
    {#if language.Shared.Snapchat}{@render icon?.(Snapchat, projectData.Snapchat)}{/if}
    {#if language.Shared.Telegram}{@render icon?.(Telegram, projectData.Telegram)}{/if}
    {#if language.Shared.Twitter}{@render icon?.(Twitter, projectData.Twitter)}{/if}
    {#if language.Shared.Facebook}{@render icon?.(Facebook, projectData.Facebook)}{/if}
  </nav>
{/if}