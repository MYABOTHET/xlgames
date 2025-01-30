import configuration from "$lib";
import {defaultCountriesAndRegions} from "$lib/tools.js";

export async function load({fetch, params}) {
  let productDataResponse = await fetch(`${configuration.api}/Products/${params.id}`);
  let productData = null;
  try {
    productData = await productDataResponse.json();
    if (!productData) throw new Error();
  } catch {
    productData = {
      CPU: "...",
      GHz: "0",
      RAM: "0",
      RAMType: "...",
      Disk: "0",
      DiskType: "...",
      ...defaultCountriesAndRegions
    };
  }
  return {productData}
}