import configuration from "$lib";
import {error} from "@sveltejs/kit";

export async function load({fetch, params, locals}) {
  const response = await fetch(`${configuration.api}/GameServers/${params.link}`);
  if (response.status === 204) {
    error(404, 'Not Found');
  }
  const gameServer = await response.json();
  const gameServerData = await (await fetch(`${configuration.api}/GameServerDatas/${gameServer
  .GameServerDataPrimaryModels.find(gameServerData => gameServerData.LanguageId === locals.language.Id).Id}`)).json();
  return {
    gameServer,
    gameServerData
  }
}