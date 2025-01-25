import configuration from "$lib";
import {validateResponse} from "$lib/tools.js";

export async function PUT({request, fetch, params}) {
  console.log(params.id);
  const language = await request.json();
  const response = await fetch(`${configuration.api}/Languages/${params.id}`, {
    method: "PUT",
    body: JSON.stringify(language),
    headers: {
      'Content-Type': 'application/json'
    }
  });
  return validateResponse(response);
}

export async function DELETE({fetch, params}) {
  const response = await fetch(`${configuration.api}/Languages/${params.id}`, {
    method: "DELETE"
  });
  return validateResponse(response);
}