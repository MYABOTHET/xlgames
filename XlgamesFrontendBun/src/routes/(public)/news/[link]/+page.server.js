import configuration from "$lib";

export async function load({fetch, params, setHeaders}) {
  setHeaders({
    'X-Robots-Tag': 'noindex, nofollow'
  });
  return {
    news: await (await fetch(`${configuration.api}/News/${params.link}`)).json()
  }
}