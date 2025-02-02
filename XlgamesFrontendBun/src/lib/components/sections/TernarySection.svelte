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
  
  const props = $props();
  
  let language = $derived(getContext("language")());
</script>

{#snippet icon(Icon, href, aria)}
  <a aria-label={aria} class="w-fit" {href} rel="nofollow">
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
  <nav {...props}>
    {#if language.Shared.Vk}{@render icon?.(Vk, language.Shared.VkLink, "Vk")}{/if}
    {#if language.Shared.Whatsapp}{@render icon?.(Whatsapp, language.Shared.WhatsappLink, "Whatsapp")}{/if}
    {#if language.Shared.Discord}{@render icon?.(Discord, language.Shared.DiscordLink, "Discord")}{/if}
    {#if language.Shared.Instagram}{@render icon?.(Instagram, language.Shared.InstagramLink, "Instagram")}{/if}
    {#if language.Shared.Snapchat}{@render icon?.(Snapchat, language.Shared.SnapchatLink, "Snapchat")}{/if}
    {#if language.Shared.Telegram}{@render icon?.(Telegram, language.Shared.TelegramLink, "Telegram")}{/if}
    {#if language.Shared.Twitter}{@render icon?.(Twitter, language.Shared.TwitterLink, "Twitter")}{/if}
    {#if language.Shared.Facebook}{@render icon?.(Facebook, language.Shared.FacebookLink, "Facebook")}{/if}
  </nav>
{/if}