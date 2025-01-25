import configuration from "$lib";
import {validateResponse} from "$lib/tools.js";

export async function PUT({request, fetch}) {
  const projectData = await request.json();
  const response = await fetch(`${configuration.api}/ProjectDatas`, {
    method: 'PUT',
    body: JSON.stringify(projectData),
    headers: {
      'Content-Type': 'application/json'
    }
  });
  return validateResponse(response);
}