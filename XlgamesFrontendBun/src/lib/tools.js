import configuration from "$lib/index.js";

export function createDateFormatter(locale) {
  return new Intl.DateTimeFormat(locale, {
    hour: "numeric",
    minute: "numeric",
    weekday: "long",
    year: "numeric",
    month: "long",
    day: "numeric",
  });
}

export function getUserLanguageFromCookies(cookies) {
  try {
    return JSON.parse(cookies.get(configuration.userLanguage));
  } catch {
    return null;
  }
}

export function getUserLanguageFromCookieClient(cookie) {
  return JSON.parse(decodeURIComponent(cookie[configuration.userLanguage]));
}