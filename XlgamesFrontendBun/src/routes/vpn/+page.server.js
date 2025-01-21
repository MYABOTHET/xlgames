import configuration from "$lib";

export async function load({fetch}) {
  return {
    vpn: await (await fetch(`${configuration.api}/Products/VPN`)).json()
  }
}