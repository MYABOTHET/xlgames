<script>
  import SharedSkelet from "../shared/SharedSkelet.svelte";
  import Button from "../../presets/buttons/Button.svelte";
  import Schedule from "../../components/shared/Schedule.svelte";
  import {process} from "../../index.js";

  let information = $state(information_PHP);
  let loading_control = $state(false);
  let os = $state(information.available_os[0] ?? "...");

  let period = $state("hourly");
  let points = $derived(information.network[period]);

  async function reboot() {
    loading_control = true;
    await process("reboot", {
      method: "POST"
    });
    loading_control = false;
  }

  async function reinstall_os() {
    let license_key = prompt(`${language.are_you_sure_you_want_to_reinstall_the_os ?? "..."}\n\n* ${language.after_reinstalling_the_os_all_data_will_be_deleted_permanently_without_the_possibility_of_recovery ?? "..."}\n\n${language.license_key ?? "..."}`);
    if (!(license_key !== null && license_key !== undefined)) return;
    loading_control = true;
    let result = await process("reinstall", {
      method: "POST",
      body: JSON.stringify({
        license_key,
        os
      })
    });
    if (result !== false) {
      location.reload();
    } else {
      loading_control = false;
    }
  }
</script>

{#snippet ButtonPeriod(title, content)}
  <Button {title} class={period === content ? '' : 'text-gray-500'} onclick={() => {period = content}}/>
{/snippet}

<SharedSkelet bind:os {information} {loading_control} {points} {reboot} {reinstall_os}>
  <section class="text-[15px] flex" style="gap: inherit">
    {@render ButtonPeriod(language.hour, "hourly")}
    {@render ButtonPeriod(language.day, "daily")}
    {@render ButtonPeriod(language.weekly, "weekly")}
    {@render ButtonPeriod(language.month, "monthly")}
    {@render ButtonPeriod(language.year, "yearly")}
  </section>
  <Schedule {points}/>
</SharedSkelet>