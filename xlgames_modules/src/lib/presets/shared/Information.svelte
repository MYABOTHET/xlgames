<script>
  import EnumSection from "../../components/shared/EnumSection.svelte";
  import Enum, {Status, Password, PasswordDeleted} from "../../components/shared/Enum.svelte";
  import EnumContent from "../../components/shared/EnumContent.svelte";

  let {ip, login, password, os, status, ...props} = $props();
</script>

<EnumSection {...props}>
  {#if status !== "-"}
    <Enum title={language.status ?? "..."}>
      {@render Status((status ? language.is_on : language.is_off) ?? "...", status)}
    </Enum>
  {/if}
  <Enum title={language.os ?? "..."}>
    <EnumContent content={os} />
  </Enum>
  <Enum title={language.ip ?? "..."}>
    <EnumContent content={ip} />
  </Enum>
  <Enum title={language.login ?? "..."}>
    <EnumContent content={login} />
  </Enum>
  <Enum title={language.password ?? "..."}>
    {#if password}
      {@render Password(password)}
    {:else}
      {@render PasswordDeleted()}
    {/if}
  </Enum>
</EnumSection>