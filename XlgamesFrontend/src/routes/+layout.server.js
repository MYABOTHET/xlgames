import {api} from "$lib/server/secrets.js";
import DeviceDetector from "node-device-detector";
import DeviceHelper from "node-device-detector/helper";
import {resolveAcceptLanguage} from "resolve-accept-language";

const detector = new DeviceDetector({
  clientIndexes: true,
  deviceIndexes: true,
  deviceAliasCode: false,
  deviceTrusted: false,
  deviceInfo: false,
  maxUserAgentSize: 500,
});

export async function load({fetch, request, cookies}) {
  let locale = cookies.get('saved-user-locale');
  const languagesResponse = await fetch(`${api}/Languages`);
  const languages = await languagesResponse.json();
  if (!locale) {
    const locales = [];
    languages.forEach(language => {
      locales.push(language["Locale"]);
    });
    const acceptLanguage = request.headers.get('accept-language');
    try {
      locale = resolveAcceptLanguage(acceptLanguage, locales, 'en-US');
    } catch {
      locale = 'en-US';
    }
    cookies.set('user-temporary-locale', locale, {path: '/'});
  }
  const links = {
    header: {
      dedicatedServers: {
        order: 2,
        name: 'DedicatedServers',
        links: [
          {
            name: 'ServersWithoutGPU',
            href: '/servers'
          },
          {
            name: 'ServersWithGPU',
            href: '/servers-gpu'
          }
        ]
      },
      other: [
        {
          order: 1,
          name: 'GameServers',
          href: '/game-servers'
        },
        {
          order: 3,
          name: 'VPS',
          href: '/vps'
        },
        {
          order: 4,
          name: 'WebHosting',
          href: '/web-hosting'
        },
        {
          order: 5,
          name: 'VPN',
          href: '/vpn'
        }
      ]
    },
    profile: [
      {
        name: 'PersonalAccount',
        href: 'https://xlgames.gg/store/login'
      },
      {
        name: 'GameHosting',
        href: 'https://clients.xlgames.pro/main/index?last=main/index'
      },
    ],
    footer: [
      {
        name: 'TermsService',
        href: '/terms-of-service'
      },
      {
        name: 'PrivacyPolicy',
        href: '/privacy-policy'
      },
    ],
    other: [
      {
        name: 'DataCenters',
        href: '/data-centers'
      },
      {
        name: 'News',
        href: '/news'
      },
      {
        name: 'AboutUs',
        href: '/about-us'
      },
      {
        name: 'Contacts',
        href: '/contacts'
      },
    ]
  };
  const project = {
    logo: 'XL',
    name: 'XLGAMES.GG',
    year: 2024
  };
  const isMobile = DeviceHelper.isMobile(detector.detect(request.headers.get('user-agent')));
  return {
    language: await (await fetch(`${api}/Languages/${locale}`)).json(),
    project, links, languages, isMobile
  }
}