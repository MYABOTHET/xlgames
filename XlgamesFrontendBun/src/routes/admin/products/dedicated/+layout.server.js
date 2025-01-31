import configuration from "$lib";

export async function load({fetch}) {
  const serversList = await (await fetch(`${configuration.api}/Products/Servers/List`)).json();
  return {
    links: serversList.map(server => {
      return {
        title: server, href: `/admin/products/dedicated/${server}`, id: server
      }
    })
  }
}