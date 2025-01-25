import configuration from "$lib";
import {validateResponse} from "$lib/tools.js";

export async function POST({request, fetch}) {
  let languageDto = await request.json();
  const response = await fetch(`${configuration.api}/Languages`, {
    method: "POST",
    body: JSON.stringify(languageDto),
    headers: {
      'Content-Type': 'application/json'
    }
  });
  return validateResponse(response);
}