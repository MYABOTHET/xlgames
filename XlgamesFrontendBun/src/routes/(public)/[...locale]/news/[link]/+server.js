import {json} from "@sveltejs/kit";
import configuration from "$lib";

export async function GET({fetch, params, url}) {
  return json(await (await fetch(`${configuration.api}/News/${params.link}/${url.searchParams.get('WHMCSName')}`)).json());
}