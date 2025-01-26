import configuration from "$lib";
import {validateResponse} from "$lib/tools.js";

export async function PUT({request, fetch, url}) {
  const product = await request.json();
  let formData = new FormData();
  formData.append("data", JSON.stringify(product));
  const response = await fetch(`${configuration.api}/Products/${url.searchParams.get("id")}`, {
    method: "PUT",
    body: formData,
  });
  return validateResponse(response);
}