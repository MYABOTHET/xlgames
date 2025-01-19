import configuration from "$lib";

export async function load({fetch, params}) {
  return {
    news: await (await fetch(`${configuration.api}/News/${params.link}`)).json()
  }
}