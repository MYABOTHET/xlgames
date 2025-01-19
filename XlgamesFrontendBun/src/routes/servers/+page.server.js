import configuration from "$lib";

export async function load({fetch}) {
  let counter = 1;
  return {
    servers: (await (await fetch(`${configuration.api}/Servers`)).json()).map(server => {
      server.Data = JSON.parse(server.Data);
      return server;
    })
  }
}