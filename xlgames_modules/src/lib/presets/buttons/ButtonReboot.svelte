<script>
  import Reboot from "../../components/svgs/Reboot.svelte";
  import ButtonIconControl from "../../components/buttons/ButtonIconControl.svelte";

  let props = $props();
</script>

<ButtonIconControl {...props} Control={Reboot} childrenClass="stroke-yellow-500 hover:stroke-yellow-400"/>