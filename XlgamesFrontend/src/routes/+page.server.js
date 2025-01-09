import configuration from "$lib";

export async function load({cookies, parent, fetch}) {
  let userLocale = cookies.get(configuration.savedUserLocale);
  if (!userLocale) {
    const data = await parent();
    userLocale = data.language.Locale;
  }
  return {
    news: await (await fetch(`${configuration.api}/News/${userLocale}?require=false&max=3`)).json()
  }
}