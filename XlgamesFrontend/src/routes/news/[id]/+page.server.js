import configuration from "$lib";
import {getUserLanguageFromCookies} from "$lib/tools.js";

export async function load({cookies, fetch, params}) {
  return {
    news: await (await fetch(`${configuration.api}/News/${getUserLanguageFromCookies(cookies).WHMCSName}/${params.id}`)).json()
  }
}