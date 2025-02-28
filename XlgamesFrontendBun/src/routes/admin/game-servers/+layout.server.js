import configuration from "$lib";

export async function load({fetch}) {
  const gameServers = await (await fetch(`${configuration.api}/GameServers`)).json();
  return {
    links: gameServers.map(gameServer => {
      return {
        title: gameServer.Name, href: `/admin/game-servers/${gameServer.Id}`, id: gameServer.Id
      }
    }).sort((a, b) => a.title.localeCompare(b.title, "ru-RU"))
  }
}