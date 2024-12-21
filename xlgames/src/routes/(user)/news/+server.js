import {json} from "@sveltejs/kit";
import {api} from "$lib";

export async function GET({cookies, url}) {
  let locale = cookies.get("saved-locale") ?? cookies.get("time-locale") ?? "en-US";
  let result = null;
  if (url.searchParams.get("method") === "news") {
    result = await (await fetch(`${api}/News/${locale}?max=${url.searchParams.get("max_items") ?? 1000}&require=${url.searchParams.get("require") ?? true}`)).json();
  } else {
    result = await (await fetch(`${api}/Languages/NewsPage/${locale}`)).json();
  }
  return json(result);
}