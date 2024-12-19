export async function load({parent}) {
  let {locale} = await parent();
  console.log(locale);
  return {}
}