import configuration from "$lib";
import {getUserLanguageFromCookies} from "$lib/tools.js";

export async function load({cookies, fetch, url}) {
  return {
    news: await (await fetch(`${configuration.api}/News/${getUserLanguageFromCookies(cookies).WHMCSName}?max=${url.searchParams.get("max") ?? 65535}`)).json()
  }
}