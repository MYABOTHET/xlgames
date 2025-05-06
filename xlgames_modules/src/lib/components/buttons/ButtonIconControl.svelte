<script>
  import ButtonIcon from "./ButtonIcon.svelte";
  import Power from "../svgs/Power.svelte";

  let {childrenClass = "stroke-white hover:stroke-white/90", Control = Power, ...props} = $props();
</script>

<ButtonIcon {...props}>
  <Control class="transition-all size-10 z-5 {childrenClass}"/>
  <Control class="absolute size-10 stroke-black/50 mt-1 z-0"/>
</ButtonIcon>