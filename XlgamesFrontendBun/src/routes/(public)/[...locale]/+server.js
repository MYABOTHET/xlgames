import configuration from "$lib";
import {json} from "@sveltejs/kit";

export async function GET({fetch, url}) {
  return json(await (await fetch(`${configuration.api}/Languages/${url.searchParams.get('id')}`)).json());
}