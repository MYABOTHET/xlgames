import {json} from "@sveltejs/kit";
import {api} from "$lib";

export async function GET({cookies, params}) {
  let locale = cookies.get("saved-locale") ?? cookies.get("time-locale") ?? "en-US";
  return json(await (await fetch(`${api}/News/${locale}/${params.name}`)).json());
}