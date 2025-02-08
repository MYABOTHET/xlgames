import configuration from "$lib";

const max = 4;
const maxNews = 3;

export async function load({fetch, locals}) {
  const data = await Promise.all([
    fetch(`${configuration.api}/News?whmcsName=${locals.language.WHMCSName}&max=${maxNews}`),
    fetch(`${configuration.api}/GameServers/Cards?max=${max}`)
  ]);
  return {
    max,
    maxNews,
    news: await data[0].json(),
    gameServers: await data[1].json()
  }
}