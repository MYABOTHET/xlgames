import configuration from "$lib";
import {json} from "@sveltejs/kit";

export async function GET({url, fetch}) {
  return json(await (await fetch(`${configuration.api}/News?whmcsName=${url.searchParams.get('WHMCSName')}&max=${url.searchParams.get("max") ?? 65535}`)).json());
}