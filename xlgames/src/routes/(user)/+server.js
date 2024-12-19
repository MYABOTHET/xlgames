import {json} from "@sveltejs/kit";
import {api} from "$lib";

export async function GET({url, cookies}) {
  let page_id = url.searchParams.get("page_id");
  let locale = cookies.get("saved-locale") ?? cookies.get("time-locale") ?? "en-US";
  let result = null;
  if (page_id === '0') {
    result = await (await fetch(`${api}/Languages/SharedPage/${locale}`)).json();
  }
  if (page_id === '1') {
    result = await (await fetch(`${api}/Languages/MainPage/${locale}`)).json();
  }
  return json(result);
}