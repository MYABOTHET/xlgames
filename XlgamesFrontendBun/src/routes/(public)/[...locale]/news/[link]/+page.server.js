import configuration from "$lib";
import {error} from "@sveltejs/kit";

export async function load({fetch, params, locals}) {
  const response = await fetch(`${configuration.api}/News/${params.link}?whmcsName=${locals.language.WHMCSName}`);
  if (response.status !== 200) {
    error(404, 'Not Found');
  }
  return {
    news: await response.json()
  }
}