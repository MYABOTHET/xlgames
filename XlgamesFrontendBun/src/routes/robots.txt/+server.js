import configuration from "$lib";

export async function GET({fetch}) {
  const languages = await (await fetch(`${configuration.api}/Languages`)).json();
  // let disallows = [];
  // languages.forEach(language => {
  //   if (language.Lang === "en") {
  //     disallows.push(`Disallow: /news/`);
  //   } else {
  //     disallows.push(`Disallow: /${language.Lang}/news/`);
  //   }
  // });
  // ${disallows.join('\n')}
  return new Response(
      `
User-agent: *
Allow: /
Disallow: /images
Disallow: /fonts
Disallow: /store
Disallow: /admin
Sitemap: https://xlgames.gg/sitemap.xml
      `.trim(),
      {
        headers: {
          'Content-Type': 'text/plain'
        }
      }
  );
}