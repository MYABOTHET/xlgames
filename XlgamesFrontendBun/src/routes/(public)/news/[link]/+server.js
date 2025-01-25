import {json} from "@sveltejs/kit";
import configuration from "$lib";
import {getUserLanguageFromCookies} from "$lib/tools.js";

export async function GET({fetch, params, cookies}) {
  return json(await (await fetch(`${configuration.api}/News/${params.link}/${getUserLanguageFromCookies(cookies).WHMCSName}`)).json());
}