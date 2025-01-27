import configuration from "$lib";

export async function load({fetch, params}) {
  let gameServer = await (await fetch(`${configuration.api}/GameServers/${params.id}`)).json();
  let languageList = await (await fetch(`${configuration.api}/Languages/List`)).json();
  let linksOptions = [
    {
      title: "Настройки",
      href: `/admin/game-servers/${params.id}/settings`
    },
  ];
  let linksResult = linksOptions.concat(gameServer.GameServerDataPrimaryModels
  .map(model => {return {
    title: languageList.find(language => language.Id === model.LanguageId).Name,
    href: `/admin/game-servers/${params.id}/${model.Id}`
  }}).sort((a, b) => a.title.localeCompare(b.title, "ru-RU")));
  return {
    gameServer,
    linksOptions: linksResult,
    languageList
  }
}