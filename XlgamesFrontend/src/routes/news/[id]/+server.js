import {json} from "@sveltejs/kit";
import configuration from "$lib";

export async function GET({ url, fetch, params }) {
  const locale = url.searchParams.get("locale");
  return json(await (await fetch(`${configuration.api}/News/${locale}/${params["id"]}`)).json());
}