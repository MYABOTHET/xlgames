<script>
  import PrimaryEnum from "./PrimaryEnum.svelte";
  import SecondaryInput from "../inputs/SecondaryInput.svelte";
  import PrimaryText from "../texts/PrimaryText.svelte";
  
  let {name, value = $bindable(), children, ...props} = $props();
</script>

<PrimaryEnum {...props} class={props.class}>
  <SecondaryInput placeholder={props.placeholder} bind:value/>
  <PrimaryText>{@render children?.()}</PrimaryText>
</PrimaryEnum>