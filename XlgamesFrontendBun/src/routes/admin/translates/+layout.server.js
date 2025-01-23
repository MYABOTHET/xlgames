import configuration from "$lib";

export async function load({fetch}) {
  const links = [
    {
      title: "Создать язык",
      href: "/admin/translates/create"
    }
  ];
  const languageList = await (await fetch(`${configuration.api}/Languages/List`)).json();
  return {
    links: links.concat(languageList.map(language => {return {
      title: language.Name, href: `/admin/translates/${language.Id}`
    }}))
  }
}