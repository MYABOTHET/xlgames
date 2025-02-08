import configuration from "$lib";

export async function load({fetch, params, locals}) {
  const gameServer = await (await fetch(`${configuration.api}/GameServers/${params.link}`)).json();
  const gameServerData = await (await fetch(`${configuration.api}/GameServerDatas/${gameServer
  .GameServerDataPrimaryModels.find(gameServerData => gameServerData.LanguageId === locals.language.Id).Id}`)).json();
  return {
    gameServer,
    gameServerData
  }
}