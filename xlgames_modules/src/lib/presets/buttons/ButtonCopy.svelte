<script>
  import Copy from "../../components/svgs/Copy.svelte";
  import ButtonIconStatic from "../../components/buttons/ButtonIconStatic.svelte";

  let props = $props();
</script>

<ButtonIconStatic {...props}>
  <Copy class="w-6 fill-gray-700/90 hover:fill-gray-600 transition-all"/>
</ButtonIconStatic>