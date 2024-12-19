import {api} from "$lib";

export async function load({cookies, parent}) {
  let locale = cookies.get('saved-locale') ?? cookies.get('time-locale');
  if (!locale) {
    let data = await parent();
    locale = data.locale;
  }
  return {
    main_page: await (await fetch(`${api}/Languages/MainPage/${locale}`)).json()
  }
}