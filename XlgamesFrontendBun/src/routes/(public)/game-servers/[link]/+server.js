import {json} from "@sveltejs/kit";
import configuration from "$lib";
import {getUserLanguageFromCookies} from "$lib/tools.js";

export async function GET({ fetch, params }) {
  return json(await (await fetch(`${configuration.api}/GameServerDatas/${params.link}`)).json());
}