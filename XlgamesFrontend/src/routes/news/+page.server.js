import configuration from "$lib";

export async function load({cookies, parent, fetch}) {
  let userLocale = cookies.get(configuration.savedUserLocale) ?? cookies.get(configuration.userTemporaryLocale);
  if (!userLocale) {
    const data = await parent();
    userLocale = data.language.Locale;
  }
  return {
    news: await (await fetch(`${configuration.api}/News/${userLocale}?require=false`)).json()
  }
}