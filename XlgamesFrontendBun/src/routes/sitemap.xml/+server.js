import configuration from "$lib";

export async function GET() {
  const languages = await (await fetch(`${configuration.api}/Languages`)).json();
  const games = await (await fetch(`${configuration.api}/GameServers/Links`)).json();
  const news = await (await fetch(`${configuration.api}/News?whmcsName=english`)).json();
  let ip = 'https://xlgames.gg';
  let urls = [
      '/',
      '/about-us',
      '/contacts',
      '/cookie-policy',
      '/data-centers',
      '/games',
      '/news',
      '/privacy-policy',
      '/dedicated',
      '/gpu-servers',
      '/terms-of-service',
      '/vpn',
      '/vps',
      '/web-hosting',
  ];
  urls = urls.concat(games.map(game => `/games/${encodeURI(game.Name).replace(/~/g, '%7E')}`));
  urls = urls.concat(news.map(newsItem => `/news/${encodeURI(newsItem.LinkName).replace(/~/g, '%7E')}`));
  let output = [];
  languages.forEach(l => {
    urls.forEach(url => {
      let out = '<url>';
      let newUrl = url;
      if (url === '/') {
        url = '';
        newUrl = '';
      }
      if (l.Locale !== "en-US") {
        newUrl = `/${l.Lang}${newUrl}`;
      }
      out += `<loc>${ip + newUrl}</loc>`;
      languages.forEach(language => {
        let result = `${ip}/${language.Lang}${url}`;
        if (language.Locale === "en-US") {
          result = `${ip}${url}`;
        }
        out += `<xhtml:link rel="alternate" hreflang="${language.Lang}" href="${result}"/>`;
      });
      out += '</url>';
      output.push(out);
    });
  })
  return new Response(
      `
<?xml version="1.0" encoding="UTF-8"?>

<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9" xmlns:xhtml="http://www.w3.org/1999/xhtml">
${output.join('\n')}
</urlset>
      `.trim(),
      {
        headers: {
          'Content-Type': 'application/xml'
        }
      }
  );
}