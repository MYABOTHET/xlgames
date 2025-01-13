import configuration from "$lib";
import {json} from "@sveltejs/kit";
import {getUserLanguageFromCookies} from "$lib/tools.js";

export async function GET({ url, fetch, cookies }) {
  return json(await (await fetch(`${configuration.api}/News?whmcsName=${getUserLanguageFromCookies(cookies).WHMCSName}&max=${url.searchParams.get("max") ?? 65535}`)).json());
}