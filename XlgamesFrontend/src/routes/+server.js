import configuration from "$lib";
import {json} from "@sveltejs/kit";
import {getUserLanguageFromCookies} from "$lib/tools.js";

export async function GET({fetch, cookies}) {
  return json(await (await fetch(`${configuration.api}/Languages/${getUserLanguageFromCookies(cookies).Id}`)).json());
}