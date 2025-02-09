<script>
  import {getContext} from "svelte";
  import SecondarySection from "$lib/components/sections/SecondarySection.svelte";
  
  const {data} = $props();
  
  let language = $derived(getContext("language")());
  
  let priceFormatter = $derived(new Intl.NumberFormat(language.Locale));
  let prices = $derived(getPrices(data.vpn));
  
  function getPrice(price) {
    const sign = language.Shared.CurrencySign;
    const position = language.Shared.CurrencySignPosition;
    return position ? sign + priceFormatter.format(price) : priceFormatter.format(price) + sign;
  }
  
  function getPrices(vpn) {
    const pricing = vpn.find(pricing => pricing.CurrencyId === language.CurrencyId);
    return {
      OneMonth: getPrice(pricing.Monthly),
      ThreeMonths: getPrice(pricing.Quarterly),
      HalfYear: getPrice(pricing.Semiannually),
      Year: getPrice(pricing.Annually),
    };
  }
</script>

<svelte:head>
  <title>{language.VPN.Title} - {data.projectData.Name}</title>
  {@html language.VPN.Head}
</svelte:head>

{#snippet VPNCard(title, price, href, discount)}
  <article class="border-2 border-(--color-quaternary) rounded-2xl py-6 flex items-center flex-col text-center
transition-colors hover:bg-(--color-secondary) px-4">
    <h1 class="text-2xl font-medium">{title}</h1>
    <p class="mt-6">{price}</p>
    <div class="my-8 flex flex-col gap-y-2 text-sm">
      {#if true}
        {#each language.VPN.VPNPoints as point}
          <p class="text-left">- {point}</p>
        {/each}
      {/if}
      {#if discount}
        <p class="text-center mt-5 text-(--color-ternary)">
          {language.VPN.DiscountPosition
              ? discount + "% " + language.VPN.Discount
              : language.VPN.Discount + " " + discount + "%"}
        </p>
      {/if}
    </div>
    <a rel="nofollow" class="quinary-block w-fit px-6 py-2.5 mt-auto" {href} data-sveltekit-reload>{language.Shared.Order}</a>
  </article>
{/snippet}

<article class="secondary-section">
  <h1 class="primary-title">{language.VPN.Name}</h1>
  <p>{language.VPN.Description}</p>
  {#if language.VPN.VPNCollection.length}
    <SecondarySection items={language.VPN.VPNCollection}/>
  {/if}
  <h1 class="primary-title">{language.VPN.Tariffs}</h1>
  <section class="grid grid-cols-4 gap-8 max-secondary:grid-cols-3 max-secondary:*:last:grid-cols-subgrid
max-secondary:*:last:col-start-2 max-ternary:*:last:grid-cols-none max-ternary:*:last:col-start-auto
max-ternary:grid-cols-2 max-nine:grid-cols-1">
    {@render VPNCard?.(language.VPN.OneMonth, prices.OneMonth,
        "/store/cart.php?a=add&pid=51&billingcycle=montly")}
    {@render VPNCard?.(language.VPN.ThreeMonths, prices.ThreeMonths,
        "/store/cart.php?a=add&pid=51&billingcycle=quarterly", language.VPN.DiscountThreeMonths)}
    {@render VPNCard?.(language.VPN.HalfYear, prices.HalfYear,
        "/store/cart.php?a=add&pid=51&billingcycle=semiannually", language.VPN.DiscountHalfYear)}
    {@render VPNCard?.(language.VPN.Year, prices.Year,
        "/store/cart.php?a=add&pid=51&billingcycle=annually", language.VPN.DiscountYear)}
  </section>
</article>