<script>
  import PrimaryEnum from "./PrimaryEnum.svelte";
  import SecondaryText from "../texts/SecondaryText.svelte";
  import TernaryInput from "../inputs/TernaryInput.svelte";
  
  let {name, value = $bindable(), children, ...props} = $props();
</script>

<PrimaryEnum {...props} class={props.class}>
  <TernaryInput bind:value/>
  <SecondaryText>{@render children?.()}</SecondaryText>
</PrimaryEnum>