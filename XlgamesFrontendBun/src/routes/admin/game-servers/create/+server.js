import configuration from "$lib";
import {validateResponse} from "$lib/tools.js";

export async function POST({request, fetch}) {
  let name = await request.text();
  let formData = new FormData();
  formData.append("name", name);
  const response = await fetch(`${configuration.api}/GameServers`, {
    method: "POST",
    body: formData,
  });
  return validateResponse(response);
}