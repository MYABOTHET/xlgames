import configuration from "$lib";

export async function load({fetch, params, setHeaders, locals}) {
  setHeaders({
    'X-Robots-Tag': 'noindex, nofollow'
  });
  return {
    news: await (await fetch(`${configuration.api}/News/${params.link}?whmcsName=${locals.language.WHMCSName}`)).json()
  }
}