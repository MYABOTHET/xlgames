import configuration from "$lib";

export async function load({fetch}) {
  const languageList = await (await fetch(`${configuration.api}/Languages/List`)).json();
  return {
    links: languageList.map(language => {
      return {
        title: language.Name, href: `/admin/translates/${language.Id}`, id: language.Id
      }
    })
  }
}