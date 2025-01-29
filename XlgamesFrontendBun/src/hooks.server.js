import configuration from "$lib";
import {resolveAcceptLanguage} from "resolve-accept-language";
import {getUserLanguageFromCookies} from "$lib/tools.js";
import {redirect} from "@sveltejs/kit";

/** @type {import('@sveltejs/kit').Handle} */
export async function handle({event, resolve}) {
  const {cookies, request, locals, url, fetch} = event;
  if (url.pathname.startsWith("/admin") && !url.pathname.startsWith("/admin/login")) {
    const response = await fetch(`${configuration.api}/Auth/Validate`);
    console.log(cookies.getAll());
    if (response.status === 401) {
      redirect(301, "/admin/login");
    }
  }
  let userLanguage = getUserLanguageFromCookies(cookies);
  const languages = await (await fetch(`${configuration.api}/Languages`)).json();
  if (!userLanguage) {
    let userLocale = null;
    const userAcceptLanguage = request.headers.get("accept-language");
    try {
      userLocale = resolveAcceptLanguage(userAcceptLanguage, languages.map(language => language.Locale), "en-US");
    } catch {
      userLocale = "en-US";
    }
    userLanguage = languages.find(language => language.Locale === userLocale);
    cookies.set(configuration.userLanguage, JSON.stringify(userLanguage), {
      path: "/",
      httpOnly: false,
      secure: false,
      priority: "high"
    });
  } else {
    if (!languages.find(language =>
        language.Name === userLanguage.Name
        && language.WHMCSName === userLanguage.WHMCSName
        && language.OriginalName === userLanguage.OriginalName
        && language.Locale === userLanguage.Locale
        && language.Lang === userLanguage.Lang
        && language.CurrencyId === userLanguage.CurrencyId
    )) {
      userLanguage = languages.find(language => language.Id === userLanguage.Id)
          ?? languages.find(language => language.Id === 1);
      cookies.set(configuration.userLanguage, JSON.stringify(userLanguage), {
        path: "/",
        httpOnly: false,
        secure: false,
        priority: "high"
      });
    }
  }
  locals.languages = languages;
  return resolve(event, {
    transformPageChunk: ({html}) => html.replace('%lang%', userLanguage.Lang)
  });
}