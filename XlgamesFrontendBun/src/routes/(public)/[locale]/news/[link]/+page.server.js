import configuration from "$lib";
import {getUserLanguageFromCookies} from "$lib/tools.js";

export async function load({fetch, params, setHeaders, cookies}) {
  setHeaders({
    'X-Robots-Tag': 'noindex, nofollow'
  });
  return {
    news: await (await fetch(`${configuration.api}/News/${params.link}?whmcsName=${getUserLanguageFromCookies(cookies).WHMCSName}`)).json()
  }
}