import configuration from "$lib";
import {getUserLanguageFromCookies} from "$lib/tools.js";

export async function load({fetch, params, cookies}) {
  const gameServer = await (await fetch(`${configuration.api}/GameServers/${params.link}`)).json();
  const gameServerData = await (await fetch(`${configuration.api}/GameServerDatas/${gameServer
  .GameServerDataPrimaryModels.find(gameServerData => gameServerData.LanguageId === getUserLanguageFromCookies(cookies).Id).Id}`)).json();
  return {
    gameServer,
    gameServerData
  }
}