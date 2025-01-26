<script>
  import PrimaryPage from "$lib/components/pages/PrimaryPage.svelte";
  import PrimaryNav from "$lib/components/nav/PrimaryNav.svelte";
  import {setContext} from "svelte";
  
  const {children, data} = $props();
  
  async function updateProduct(id, product) {
    await fetch(`/admin/products?id=${id}`, {
      method: "PUT",
      body: JSON.stringify(product),
      headers: {
        'Content-Type': 'application/json'
      }
    });
  }
  
  setContext("updateProduct", updateProduct);
</script>

<PrimaryNav links={data.links}/>

<PrimaryPage>
  {@render children?.()}
</PrimaryPage>