/** @type {import('@sveltejs/kit').Handle} */
export function handle({ event, resolve }) {
  // console.log(event.cookies.getAll());

  return resolve(event, {
    transformPageChunk: ({ html }) => html.replace('%lang%', "ru")
  });
}