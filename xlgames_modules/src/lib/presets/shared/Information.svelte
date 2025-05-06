<script>
  import EnumSection from "../../components/shared/EnumSection.svelte";
  import Enum from "../../components/shared/Enum.svelte";

  let {ip, login, password, os, ...props} = $props();
</script>

<EnumSection {...props}>
  <Enum content={ip} title={language.ip ?? "..."}/>
  <Enum content={login} title={language.login ?? "..."}/>
  <Enum content={password} title={language.password ?? "..."}/>
  <Enum content={os} title={language.os ?? "..."}/>
</EnumSection>