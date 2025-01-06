import {api} from "$lib/server/secrets.js";

export async function load({cookies, parent, fetch, params}) {
  let locale = cookies.get('saved-user-locale') ?? cookies.get('user-temporary-locale');
  if (!locale) {
    let data = await parent();
    locale = data.language["Locale"];
  }
  return {
    news: await (await fetch(`${api}/News/${locale}/${params["id"]}`)).json()
  }
}