import configuration from "$lib";

export async function load({fetch, params}) {
  let productDataResponse = await fetch(`${configuration.api}/Products/${params.id}`);
  let productData = null;
  try {
    productData = await productDataResponse.json();
    if (!productData) throw new Error();
  } catch {
    productData = {
      CPU: "...",
      GPU: "...",
      GHz: "0",
      RAM: "0",
      RAMType: "...",
      Disk: "0",
      DiskType: "...",
      Germany: false,
      Falkenstein: false,
      Frankfurt: false,
      Nuremberg: false,
      Finland: false,
      Helsinki: false,
      Russia: false,
      Moscow: false,
      SaintPetersburg: false,
      USA: false,
      NewYork: false,
      Miami: false,
      LosAngeles: false,
      Hillsboro: false,
      Ashburn: false,
      Singapore: false,
      France: false,
      Gravelines: false
    };
  }
  return {productData}
}