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