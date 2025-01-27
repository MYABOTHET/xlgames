import configuration from "$lib";

export async function load({params, fetch}) {
  let translate = await (await fetch(`${configuration.api}/GameServerDatas/${params.translateId}`)).json();
  console.log(translate);
  return {
    translate
  }
}