import configuration from "$lib";

export async function load({fetch}) {
  return {
    gameServers: await (await fetch(`${configuration.api}/GameServers/Cards?max=65535`)).json()
  }
}