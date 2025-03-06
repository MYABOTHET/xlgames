<script>
  import {transformLocale} from "$lib/tools.js";
  import {getContext} from "svelte";
  
  let {Logo, start, center, end, href, ...props} = $props();
  
  let languageDto = $derived(getContext("languageDto")());
</script>

<div class="mx-auto border-(--color-ternary) px-7 py-6 border-2 overflow-hidden rounded-2xl
flex gap-6 justify-center items-center max-w-2xl">
  <Logo class="min-w-12 max-w-12 fill-(--color-ternary)"/>
  <h1>{start}<a
      class="primary-link" href={transformLocale(languageDto.Lang, href)}>{center}</a
  >{end}</h1>
</div>