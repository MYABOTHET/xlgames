<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import {page} from "$app/state";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import SaveForm from "$lib/components/SaveForm.svelte";
  import ProductCountriesRegions from "$lib/components/ProductCountriesRegions.svelte";
  import {getContext} from "svelte";
  import {getDefaultCountriesAndRegions} from "$lib/tools.js";
  
  let {data} = $props();
  
  let product = $state({
    CPU: data?.productData?.CPU ?? "...",
    GHz: data?.productData?.GHz ?? "0",
    RAM: data?.productData?.RAM ?? "0",
    RAMType: data?.productData?.RAMType ?? "...",
    Disk: data?.productData?.Disk ?? "0",
    DiskType: data?.productData?.DiskType ?? "...",
    ...getDefaultCountriesAndRegions(data)
  });
  let init = $state.raw({init: false});
  let updateProduct = getContext("updateProduct");
  let access = $state(null);
  let timeout = $state(null);
  
  $effect(() => {
    data.productData;
    if (init.init) {
      product = data.productData;
    } else {
      init.init = true;
    }
  });
</script>

<SecondaryPage title="Продукт ID: {page.params.id}">
  <QuaternarySection title="Данные продукта">
    <PrimaryTextarea bind:value={product.CPU} title="Процессор"/>
    <PrimaryTextarea bind:value={product.GHz} title="ГГц"/>
    <PrimaryTextarea bind:value={product.RAM} title="Кол-во ОЗУ (ГБ)"/>
    <PrimaryTextarea bind:value={product.RAMType} title="Тип ОЗУ"/>
    <PrimaryTextarea bind:value={product.Disk} title="Место на диске"/>
    <PrimaryTextarea bind:value={product.DiskType} title="Тип диска"/>
  </QuaternarySection>
  <ProductCountriesRegions bind:product/>
  <SaveForm {access} onclick={() => {clearTimeout(timeout); updateProduct(page.params.id, product);
    access = true; timeout = setTimeout(() => access = null, 5000) }}/>
</SecondaryPage>