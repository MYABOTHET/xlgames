import {json} from "@sveltejs/kit";
import {api} from "$lib";

export async function GET({cookies}) {
  let locale = cookies.get("saved-locale") ?? cookies.get("time-locale") ?? "en-US";
  let result = await (await fetch(`${api}/Languages/PrivacyPolicyPage/${locale}`)).json();
  return json(result);
}