import configuration from "$lib";

export async function load({fetch}) {
  const serversGPUList = await (await fetch(`${configuration.api}/Products/Servers-GPU/List`)).json();
  return {
    links: serversGPUList.map(serverGPU => {
      return {
        title: serverGPU, href: `/admin/products/gpu-servers/${serverGPU}`, id: serverGPU
      }
    })
  }
}