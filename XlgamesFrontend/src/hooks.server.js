import configuration from "$lib";
import {resolveAcceptLanguage} from "resolve-accept-language";
import {getUserLanguageFromCookies} from "$lib/tools.js";

/** @type {import('@sveltejs/kit').Handle} */
export async function handle({event, resolve}) {
  const {cookies, request} = event;
  let userLanguage = getUserLanguageFromCookies(cookies);
  if (!userLanguage) {
    let userLocale = null;
    const languages = await (await fetch(`${configuration.api}/Languages`)).json();
    const userAcceptLanguage = request.headers.get("accept-language");
    try {
      userLocale = resolveAcceptLanguage(userAcceptLanguage, languages.map(language => language.Locale), "en-US");
    } catch {
      userLocale = "en-US";
    }
    userLanguage = languages.find(language => language.Locale === userLocale);
    cookies.set(configuration.userLanguage, JSON.stringify(userLanguage), {path: "/", httpOnly: false, secure: false, priority: "high"});
    request.languagesCache = languages;
  }
  return resolve(event, {
    transformPageChunk: ({html}) => html.replace('%lang%', userLanguage.Lang)
  });
}