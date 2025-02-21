import configuration from "$lib";
import {error, redirect} from "@sveltejs/kit";

/** @type {import('@sveltejs/kit').Handle} */
export async function handle({event, resolve}) {
  const {locals, url, fetch, params} = event;
  if (url.pathname.startsWith("/admin") && !url.pathname.startsWith("/admin/login")) {
    const response = await fetch(`${configuration.api}/Auth/Validate`);
    if (response.status === 401) {
      redirect(301, "/admin/login");
    }
  }
  if (params.locale !== undefined) {
    let paramsLocale = params.locale.split('/');
    if (paramsLocale.length !== 1) error(404, 'Not Found');
    let locale = paramsLocale[0];
    if (locale === 'en') error(404, 'Not Found');
    if (locale === '') locale = 'en';
    const languages = await (await fetch(`${configuration.api}/Languages`)).json();
    let language = languages.find(language => language.Lang === locale);
    if (!language) error(404, 'Not Found');
    locals.languages = languages;
    locals.language = language;
    return resolve(event, {
      transformPageChunk: ({html}) => html.replace('%lang%', locale)
    });
  }
  return resolve(event, {
    transformPageChunk: ({html}) => html.replace('%lang%', 'en')
  });
}

/** @type {import('@sveltejs/kit').HandleFetch} */
export async function handleFetch({ event, request, fetch }) {
  request.headers.set('cookie', event.request.headers.get('cookie'));
  return fetch(request);
}