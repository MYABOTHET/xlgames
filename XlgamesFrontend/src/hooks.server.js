import configuration from "$lib";
import {resolveAcceptLanguage} from "resolve-accept-language";

/** @type {import('@sveltejs/kit').Handle} */
export async function handle({event, resolve}) {
  const {cookies, request} = event;
  let userLocale = cookies.get(configuration.savedUserLocale);
  if (!userLocale) {
    const languages = await (await fetch(`${configuration.api}/Languages`)).json();
    const userAcceptLanguage = request.headers.get("accept-language");
    try {
      userLocale = resolveAcceptLanguage(userAcceptLanguage, languages.map(language => language.Locale),
          "en-US");
    } catch {
      userLocale = "en-US";
    }
    cookies.set(configuration.savedUserLocale, userLocale, {path: "/", httpOnly: false});
    cookies.set(configuration.savedUserLang, languages.find(language => language.Locale === userLocale).Lang, {
      path: "/",
      httpOnly: false
    });
    request.myLanguages = languages;
  }
  return resolve(event, {
    transformPageChunk: ({html}) => html.replace('%lang%', cookies.get(configuration.savedUserLang))
  });
}