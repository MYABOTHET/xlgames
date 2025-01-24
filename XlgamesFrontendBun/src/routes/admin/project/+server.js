import configuration from "$lib";

export async function PUT({request, fetch}) {
  const projectData = await request.json();
  const response = await fetch(`${configuration.api}/ProjectDatas`, {
    method: 'PUT',
    body: JSON.stringify(projectData),
    headers: {
      'Content-Type': 'application/json'
    }
  });
  return new Response(null, {status: response.status});
}