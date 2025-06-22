import configuration from "$lib";

export async function GET({fetch, params}) {
  const {id} = params;
  return fetch(`${configuration.api}/Languages/all/${id}`);
}