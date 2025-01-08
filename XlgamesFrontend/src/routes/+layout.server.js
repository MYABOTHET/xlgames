import configuration from "$lib";
import DeviceDetector from "node-device-detector";
import DeviceHelper from "node-device-detector/helper";
import {resolveAcceptLanguage} from "resolve-accept-language";

export async function load({request, fetch, cookies}) {
  const mobileWidth = 64;
  const headerHeight = 5;
  const author = "Лёвин Валерий Дмитриевич";
  const navigationLinks = {
    header: {
      menu: {
        name: "DedicatedServers",
        position: 2,
        links: [
          {
            name: "ServersWithoutGPU",
            href: "/servers"
          },
          {
            name: "ServersWithGPU",
            href: "/servers-gpu"
          }
        ]
      },
      other: [
        {
          position: 1,
          name: "GameServers",
          href: "/game-servers"
        },
        {
          position: 3,
          name: "VPS",
          href: "/vps"
        },
        {
          position: 4,
          name: "WebHosting",
          href: "/web-hosting"
        },
        {
          position: 5,
          name: "VPN",
          href: "/vpn"
        }
      ]
    },
    menu: [
      {
        name: "PersonalAccount",
        href: "https://xlgames.gg/store/login"
      },
      {
        name: "GameHosting",
        href: "https://clients.xlgames.pro/main/index?last=main/index"
      },
    ],
    footer: [
      {
        name: "TermsService",
        href: "/terms-of-service"
      },
      {
        name: "PrivacyPolicy",
        href: "/privacy-policy"
      },
    ],
    other: [
      {
        name: "DataCenters",
        href: "/data-centers"
      },
      {
        name: "News",
        href: "/news"
      },
      {
        name: "AboutUs",
        href: "/about-us"
      },
      {
        name: "Contacts",
        href: "/contacts"
      },
    ]
  };
  const projectData = {
    logo: "XL",
    name: "XLGAMES.GG",
    year: 2024
  };
  const userAgent = request.headers.get("user-agent");
  const detector = new DeviceDetector();
  const userData = detector.detect(userAgent);
  const userOnMobile = DeviceHelper.isMobile(userData);
  let userLocale = cookies.get(configuration.savedUserLocale) ?? cookies.get(configuration.userTemporaryLocale);
  let languages = null;
  if (!userLocale) {
    languages = await (await fetch(`${configuration.api}/Languages`)).json();
    const userAcceptLanguage = request.headers.get("accept-language");
    const locales = [];
    languages.forEach(language => {
      locales.push(language.Locale);
    });
    try {
      userLocale = resolveAcceptLanguage(userAcceptLanguage, locales, "en-US");
    } catch { userLocale = "en-US"; }
    cookies.set(configuration.userTemporaryLocale, userLocale, { path: "/" });
  }
  return {
    mobileWidth,
    headerHeight,
    author,
    navigationLinks,
    projectData,
    userOnMobile,
    languages: languages ? languages : await (await fetch(`${configuration.api}/Languages`)).json(),
    language: await (await fetch(`${configuration.api}/Languages/${userLocale}`)).json(),
  }
}