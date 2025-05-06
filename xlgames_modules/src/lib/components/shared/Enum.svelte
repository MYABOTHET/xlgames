<script>
  import ButtonCopy from "../../presets/buttons/ButtonCopy.svelte";
  import HorizontalLine from "./HorizontalLine.svelte";

  let {title, content, ...props} = $props();
</script>

<article {...props} class="{props.class} flex gap-1"><h1 class="text-nowrap">{title}</h1>
  <HorizontalLine class="w-full min-w-12 ml-2"/>
</article>
<article class="flex gap-3 items-center truncate">
  <h1 class="truncate">{content}</h1>
  <ButtonCopy onclick={() => {navigator.clipboard.writeText(content)}}/>
</article>