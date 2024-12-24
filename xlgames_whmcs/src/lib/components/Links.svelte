<script>
  import PrimaryButton from "./buttons/PrimaryButton.svelte";
  
  let {current_link = $bindable(), links, ...props} = $props();
</script>

<div {...props} class="{props.class} flex gap-x-6">
  {#each links as link}
    <PrimaryButton class={current_link === link.href ? 'text-slate-900' : 'hover:text-slate-600'}
                   onclick={() => { current_link = link.href }}>{link.name}</PrimaryButton>
  {/each}
</div>