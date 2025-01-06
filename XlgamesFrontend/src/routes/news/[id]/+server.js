import {api} from "$lib/server/secrets.js";

export async function GET({ url, fetch, params }) {
  const locale = url.searchParams.get('locale') ?? 'en-US';
  return await fetch(`${api}/News/${locale}/${params["id"]}`);
}