import {api} from "$lib/server/secrets.js";

export async function GET({ url, fetch }) {
  const locale = url.searchParams.get('locale') ?? 'en-US';
  const myUrl = new URL(`${api}/News/${locale}`);
  myUrl.searchParams.set('require', url.searchParams.get('require') ?? true);
  myUrl.searchParams.set('max', url.searchParams.get('max') ?? 65536);
  return await fetch(myUrl);
}