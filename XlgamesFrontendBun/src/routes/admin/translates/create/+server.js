import configuration from "$lib";

export async function POST({request, fetch}) {
  let languageDto = await request.json();
  const response = await fetch(`${configuration.api}/Languages`, {
    method: "POST",
    body: JSON.stringify(languageDto),
    headers: {
      'Content-Type': 'application/json'
    }
  });
  if (response.status === 200) {
    return new Response(null, {status: response.status});
  }
  const body = await response.json();
  const errors = Object.values(body.errors);
  let result = [];
  errors.forEach(error => {
    result = result.concat(error);
  })
  return new Response(result.join(", "), {status: response.status});
}