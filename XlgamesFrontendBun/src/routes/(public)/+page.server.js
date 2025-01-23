import configuration from "$lib";
import {getUserLanguageFromCookies} from "$lib/tools.js";

const max = 4;
const maxNews = 3;

export async function load({cookies, fetch}) {
  const data = await Promise.all([
    fetch(`${configuration.api}/News?whmcsName=${getUserLanguageFromCookies(cookies).WHMCSName}&max=${maxNews}`),
    fetch(`${configuration.api}/GameServers/Cards?max=${max}`)
  ]);
  return {
    max,
    maxNews,
    news: await data[0].json(),
    gameServers: await data[1].json()
  }
}