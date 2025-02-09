import {api} from "$lib";

export async function load({cookies, parent}) {
  let locale = cookies.get('saved-locale') ?? cookies.get('time-locale');
  if (!locale) {
    let data = await parent();
    locale = data.locale;
  }
  return {
    news_page: await (await fetch(`${api}/Languages/NewsPage/${locale}`)).json(),
    news: await (await fetch(`${api}/News/${locale}?require=false`)).json()
  }
}