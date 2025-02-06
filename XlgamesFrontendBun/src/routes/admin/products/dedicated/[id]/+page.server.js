import configuration from "$lib";
import {defaultCountriesAndRegions, defaultProductData} from "$lib/tools.js";

export async function load({fetch, params}) {
  let productDataResponse = await fetch(`${configuration.api}/Products/${params.id}`);
  let productData = null;
  try {
    productData = await productDataResponse.text();
    productData = JSON.parse(productData.replaceAll("&quot;", '"'));
    if (!productData) throw new Error();
  } catch {
    productData = {
      GHz: "0",
      RAMType: "...",
      ...defaultProductData,
      ...defaultCountriesAndRegions
    };
  }
  return {productData}
}