import configuration from "$lib";

export async function load({locals, fetch, url}) {
  return {
    news: await (await fetch(`${configuration.api}/News?whmcsName=${locals.language.WHMCSName}&max=${url.searchParams.get("max") ?? 65535}`)).json()
  }
}