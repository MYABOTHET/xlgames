<script>
  import Line from "./Line.svelte";
  import Link from "./Link.svelte";
  
  let {pages, current_page = $bindable(), ...props} = $props();
</script>

<div {...props} class="{props.class} flex gap-6">
  {#each pages as page}
    <Link onclick={() => {current_page = page}} active={current_page.name === page.name}>{page.name}</Link>
  {/each}
</div>

<Line/>