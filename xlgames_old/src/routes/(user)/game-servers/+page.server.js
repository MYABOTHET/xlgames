import {api} from "$lib";

export async function load({cookies, parent}) {
  let locale = cookies.get('saved-locale') ?? cookies.get('time-locale');
  if (!locale) {
    let data = await parent();
    locale = data.locale;
  }
  return {
    game_servers: await (await fetch(`${api}/Languages/GameServersPage/${locale}`)).json()
  }
}