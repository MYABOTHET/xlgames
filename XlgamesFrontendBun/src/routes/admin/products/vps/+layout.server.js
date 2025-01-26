import configuration from "$lib";

export async function load({fetch}) {
  const vpsList = await (await fetch(`${configuration.api}/Products/VPS/List`)).json();
  return {
    links: vpsList.map(vps => {
      return {
        title: vps, href: `/admin/products/vps/${vps}`, id: vps
      }
    })
  }
}