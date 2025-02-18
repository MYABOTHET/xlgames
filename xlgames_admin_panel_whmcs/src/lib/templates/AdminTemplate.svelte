<script>
  import TernaryButton from "../components/buttons/TernaryButton.svelte";
  import Links from "../components/Links.svelte";
  import Section from "../components/Section.svelte";
  import Languages from "../components/Languages.svelte";
  import Saving from "../components/Saving.svelte";
  import Keys from "../components/Keys.svelte";
  import QuaternaryText from "../components/texts/QuaternaryText.svelte";
  import StaticPrice from "../components/StaticPrice.svelte";
  
  let {current_link = $bindable(), links, saving, keys = $bindable(), saving_message, save_keys,
  error, error_message, loading, loading_message, loading_error_message, loading_status,
  current_language, languages, change_language, create_new_language, name_new_language = $bindable(),
    language_content = $bindable(), save_language, delete_language,
    
    id = $bindable(),
    price = $bindable(),
    product,
    success_message,
    get_product,
    set_static_price,
    delete_static_price,
    update_static_price,} = $props();
</script>

<div class="relative text-[1.65rem]">
  <div class="w-full h-full absolute flex justify-center items-center z-20
{loading || !loading_status ? 'backdrop-blur-[3px]' : 'backdrop-blur-0 opacity-0 pointer-events-none'}">
    {#if loading}<span class="text-sky-500">{loading_message} {'٩(◕‿◕｡)۶'}</span>{/if}
    {#if !loading_status}<span class="text-red-500">{loading_error_message} {'(╥﹏╥)'}</span>{/if}
  </div>
  
  <div class="px-4 py-2">
    <Section>
      
      {#snippet header()}
      <div class="flex gap-x-8">
        <Links bind:current_link {links}/>
        <div class="relative text-nowrap flex items-center text-2xl">
          {#if saving}
            <Saving>{saving_message}</Saving>
          {/if}
          {#if error}
            <QuaternaryText>{error_message}</QuaternaryText>
          {/if}
        </div>
      </div>
      {/snippet}
      
      {#if current_link === links[0].href}
        <div class="flex flex-col gap-y-2">
          <Keys bind:keys/>
          <TernaryButton class="max-w-[44rem] w-full" onclick={save_keys}>Сохранить</TernaryButton>
        </div>
      {/if}
      
      {#if current_link === links[1].href}
        <Languages bind:language_content {create_new_language} bind:name_new_language value={current_language} items={languages}
                   method={change_language} {save_language} {delete_language}/>
      {/if}
      
      {#if current_link === links[2].href}
        <StaticPrice bind:id bind:price {product} {error_message} {success_message}
                     {get_product} {set_static_price} {delete_static_price} {update_static_price}/>
      {/if}
    
    </Section>
  </div>
</div>
