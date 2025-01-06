import {api} from "$lib/server/secrets.js";

export async function load({cookies, parent, fetch}) {
  let locale = cookies.get('saved-user-locale') ?? cookies.get('user-temporary-locale');
  if (!locale) {
    let data = await parent();
    locale = data.language["Locale"];
  }
  const url = new URL(`${api}/News/${locale}`);
  url.searchParams.set('require', String(false));
  url.searchParams.set('max', String(3));
  return {
    news: await (await fetch(url)).json()
  }
}