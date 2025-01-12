import configuration from "$lib";
import {getUserLanguageFromCookies} from "$lib/tools.js";

export async function load({cookies, fetch}) {
  const max = 4;
  const maxNews = 3;
  return {
    max,
    maxNews,
    news: await (await fetch(`${configuration.api}/News/${getUserLanguageFromCookies(cookies).WHMCSName}?max=${maxNews}`)).json(),
    gameServers: await (await fetch(`${configuration.api}/GameServers/Cards?max=${max}`)).json()
  }
}