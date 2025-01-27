import configuration from "$lib";
import {validateResponse} from "$lib/tools.js";

export async function PUT({request, fetch, params}) {
  const translate = await request.json();
  const response = await fetch(`${configuration.api}/GameServerDatas/${params.id}`, {
    method: "PUT",
    body: JSON.stringify(translate),
    headers: {
      'Content-Type': 'application/json'
    }
  });
  return validateResponse(response);
}