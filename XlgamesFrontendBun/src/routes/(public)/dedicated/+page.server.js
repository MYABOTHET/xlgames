import configuration from "$lib";

export async function load({fetch}) {
  return {
    servers: (await (await fetch(`${configuration.api}/Products/Servers`)).json()).map(server => {
      try {
        server.Data = JSON.parse(server.Data.replaceAll("&quot;", '"'));
        if (!server.Data) throw new Error();
      } catch {
        server.Data = "";
      }
      return server;
    }).filter(server => server.Data !== "")
  }
}