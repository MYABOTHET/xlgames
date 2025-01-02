import {api} from "$lib";

export async function load({cookies, parent, params}) {
  let locale = cookies.get('saved-locale') ?? cookies.get('time-locale');
  if (!locale) {
    let data = await parent();
    locale = data.locale;
  }
  return {
    news_item: await (await fetch(`${api}/News/${locale}/${params.name}`)).json()
  }
}