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

export async function validateResponse(response) {
  if (response.status === 200) {
    return new Response(await response.text(), {status: response.status});
  }
  const body = await response.json();
  const errors = Object.values(body.errors);
  let result = [];
  errors.forEach(error => {
    result = result.concat(error);
  })
  return new Response(result.join(", "), {status: response.status});
}