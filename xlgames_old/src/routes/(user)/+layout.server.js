import {resolveAcceptLanguage} from "resolve-accept-language";
import {api} from "$lib";

export async function load({request, cookies}) {
  let locale = cookies.get('saved-locale');
  const navigation_links = {
    header: {
      menu: {
        order: 2,
        title: 'dedicatedServers',
        links: [
          {
            title: 'servers',
            href: '/servers'
          },
          {
            title: 'serversAI',
            href: '/servers-ai'
          }
        ]
      },
      other: [
        {
          order: 1,
          title: 'gameServers',
          href: '/game-servers'
        },
        {
          order: 3,
          title: 'vps',
          href: '/vps'
        },
        {
          order: 4,
          title: 'webHosting',
          href: '/web-hosting'
        },
        {
          order: 5,
          title: 'vpn',
          href: '/vpn'
        }
      ]
    },
    profile: [
      {
        title: 'personalAccount',
        href: 'https://xlgames.gg/store/login'
      },
      {
        title: 'gameHosting',
        href: 'https://clients.xlgames.pro/main/index?last=main/index'
      },
    ],
    footer: [
      {
        title: 'termsService',
        href: '/terms-of-service'
      },
      {
        title: 'privacyPolicy',
        href: '/privacy-policy'
      },
    ],
    other: [
      {
        title: 'dataCenter',
        href: '/data-center'
      },
      {
        title: 'news',
        href: '/news'
      },
      {
        title: 'about',
        href: '/about'
      },
      {
        title: 'contacts',
        href: '/contacts'
      },
    ]
  };
  const languages = await (await fetch(`${api}/Languages`)).json();
  if (!locale) {
    const locales = [];
    languages.forEach(language => {
      locales.push(language.locale);
    });
    const accept_language = request.headers.get('accept-language');
    try {
      locale = resolveAcceptLanguage(accept_language, locales, locale);
    } catch {
      locale = 'en-US';
      cookies.set('time-locale', locale, {path: '/'});
    }
  }
  const project_titles = {
    logo: 'XL',
    title: 'XLGAMES.GG',
    year: '2024'
  };
  return {
    navigation_links, project_titles, locale, languages,
    shared_page: await (await fetch(`${api}/Languages/SharedPage/${locale}`)).json()
  }
}