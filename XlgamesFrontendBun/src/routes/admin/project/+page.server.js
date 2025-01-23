import configuration from "$lib";

export async function load({fetch}) {
  return {
    projectData: await (await fetch(`${configuration.api}/ProjectDatas`)).json()
  }
}