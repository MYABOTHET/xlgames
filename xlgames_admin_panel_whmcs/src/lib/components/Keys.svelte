<script>
  import SecondaryEnum from "./enums/SecondaryEnum.svelte";
  import TernaryEnum from "./enums/TernaryEnum.svelte";

  let {keys = $bindable(), ...props} = $props();
</script>

<div {...props} class="{props.class} flex flex-col gap-y-2 text-[1.65rem]">
  <SecondaryEnum bind:value={keys.selectel.key}>- Selectel</SecondaryEnum>
  <TernaryEnum bind:value={keys.survivalhost.key}>- SurvivalHost</TernaryEnum>
</div>