import configuration from "$lib";
import {json} from "@sveltejs/kit";

export async function GET({ url, fetch }) {
  const locale = url.searchParams.get("locale");
  return json(await (await fetch(`${configuration.api}/News/${locale}?require=${url.searchParams.get("require")}
  &max=${url.searchParams.get("max") ?? 65536}`)).json());
}