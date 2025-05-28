import {page} from "$app/state";
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

export let defaultCountriesAndRegions = {
  Germany: false,
  Falkenstein: false,
  Frankfurt: false,
  Nuremberg: false,
  Finland: false,
  Helsinki: false,
  Russia: false,
  Moscow: false,
  SaintPetersburg: false,
  Orenburg: false,
  Ekaterenburg: false,
  Vladivastok: false,
  Novosibirsk: false,
  USA: false,
  NewYork: false,
  Miami: false,
  LosAngeles: false,
  Hillsboro: false,
  Ashburn: false,
  Singapore: false,
  France: false,
  Gravelines: false,
  UnitedKingdom: false,
  Poland: false,
  Canada: false,
  Limburg: false,
  Erith: false,
  Strasbourg: false,
  Warsaw: false,
  Beauharnois: false,
}

export let defaultProductData = {
  CPU: "...",
  RAM: "0",
  Disk: "0",
  DiskType: "...",
  GB: false,
  TB: false,
}

export function getDefaultProductData(data) {
  return {
    CPU: data?.productData?.CPU ?? "...",
    RAM: data?.productData?.RAM ?? "0",
    Disk: data?.productData?.Disk ?? "0",
    DiskType: data?.productData?.DiskType ?? "...",
    GB: data?.productData?.GB ?? false,
    TB: data?.productData?.TB ?? false,
  }
}

export function getDefaultCountriesAndRegions(data) {
  return {
    Germany: data?.productData?.Germany ?? false,
    Falkenstein: data?.productData?.Falkenstein ?? false,
    Frankfurt: data?.productData?.Frankfurt ?? false,
    Nuremberg: data?.productData?.Nuremberg ?? false,
    Finland: data?.productData?.Finland ?? false,
    Helsinki: data?.productData?.Helsinki ?? false,
    Russia: data?.productData?.Russia ?? false,
    Moscow: data?.productData?.Moscow ?? false,
    SaintPetersburg: data?.productData?.SaintPetersburg ?? false,
    Orenburg: data?.productData?.Orenburg ?? false,
    Ekaterenburg: data?.productData?.Ekaterenburg ?? false,
    Vladivastok: data?.productData?.Vladivastok ?? false,
    Novosibirsk: data?.productData?.Novosibirsk ?? false,
    USA: data?.productData?.USA ?? false,
    NewYork: data?.productData?.NewYork ?? false,
    Miami: data?.productData?.Miami ?? false,
    LosAngeles: data?.productData?.LosAngeles ?? false,
    Hillsboro: data?.productData?.Hillsboro ?? false,
    Ashburn: data?.productData?.Ashburn ?? false,
    Singapore: data?.productData?.Singapore ?? false,
    France: data?.productData?.France ?? false,
    Gravelines: data?.productData?.Gravelines ?? false,
    UnitedKingdom: data?.productData?.UnitedKingdom ?? false,
    Poland: data?.productData?.Poland ?? false,
    Canada: data?.productData?.Canada ?? false,
    Limburg: data?.productData?.Limburg ?? false,
    Erith: data?.productData?.Erith ?? false,
    Strasbourg: data?.productData?.Strasbourg ?? false,
    Warsaw: data?.productData?.Warsaw ?? false,
    Beauharnois: data?.productData?.Beauharnois ?? false,
  }
}

export function transformLocale(locale, url) {
  if (locale === 'en') locale = '';
  if (url === "/") return `/${locale}`;
  if (locale) return `/${locale}${url}`;
  return url;
}

export function generateUrl(locale, pathname, language) {
  if (pathname === '/') pathname = '';
  if (language.Locale === "en-US") {
    if (locale === "en") {
      return `${page.url.origin}${pathname}`;
    }
    return `${page.url.origin}/${locale}${pathname}`;
  }
  let url = pathname.split("/");
  url = url.filter(url => url !== '');
  url.splice(0, 1);
  if (locale !== "en") {
    url.unshift(locale);
  }
  let newUrl = '/' + url.join('/');
  if (newUrl === '/') newUrl = '';
  return `${page.url.origin}${newUrl}`;
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