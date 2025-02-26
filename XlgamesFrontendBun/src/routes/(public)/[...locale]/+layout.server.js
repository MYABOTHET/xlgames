import configuration from "$lib";
import Bowser from "bowser";
import {isbot} from "isbot";
import {resolveAcceptLanguage} from "resolve-accept-language";
import {redirect} from "@sveltejs/kit";
import {getUserLanguageFromCookies, transformLocale} from "$lib/tools.js";

const mobileWidth = 72;
const headerHeight = 5;
const author = "Лёвин Валерий Дмитриевич";

export async function load({request, fetch, locals, url, cookies}) {
  let {languages, language, locale} = locals;
  if (locale === 'en') {
    const userAgent = request.headers.get("user-agent");
    const isBot = isbot(userAgent);
    if (!isBot) {
      let userLocale = null;
      const userAcceptLanguage = request.headers.get("accept-language");
      try {
        userLocale = resolveAcceptLanguage(userAcceptLanguage, languages.map(language => language.Locale), "en-US");
      } catch {
        userLocale = "en-US";
      }
      if (userLocale !== "en-US") {
        let userLanguage = getUserLanguageFromCookies(cookies);
        if (userLanguage) {
          if (userLanguage.Locale !== "en-US") {
            redirect(307, transformLocale(userLanguage.Lang, url.pathname));
          }
        } else {
          let lang = languages.find(language => language.Locale === userLocale).Lang;
          redirect(307, transformLocale(lang, url.pathname));
        }
      }
    }
  }
  const promises = [
    fetch(`${configuration.api}/Languages/${language.Id}`),
    fetch(`${configuration.api}/ProjectDatas`),
  ];
  const data = await Promise.all(promises);
  let projectData = await data[1].json();
  const navigationLinks = {
    default: "/",
    header: {
      menu: {
        name: "DedicatedServers", position: 2, links: [{
          name: "ServersWithoutGPU", href: "/dedicated"
        }, {
          name: "ServersWithGPU", href: "/gpu-servers"
        }]
      }, other: [{
        position: 1, name: "GameServers", href: "/games"
      }, {
        position: 3, name: "VPS", href: "/vps"
      }, {
        position: 4, name: "WebHosting", href: "/web-hosting"
      }, {
        position: 5, name: "VPN", href: "/vpn"
      }]
    }, menu: [{
      name: "PersonalAccount", href: projectData.PersonalAccount
    }, {
      name: "GameHosting", href: projectData.GameHosting
    },], footer: [{
      name: "TermsService", href: "/terms-of-service"
    }, {
      name: "PrivacyPolicy", href: "/privacy-policy"
    }, {
      name: "CookiePolicy", href: "/cookie-policy"
    },], other: [{
      name: "DataCenters", href: "/data-centers"
    }, {
      name: "News", href: "/news"
    }, {
      name: "AboutUs", href: "/about-us"
    }, {
      name: "Contacts", href: "/contacts"
    },]
  };
  const userAgent = request.headers.get("user-agent");
  const browser = Bowser.getParser(userAgent)
  const userOnMobile = browser.getPlatformType() === "mobile";
  return {
    mobileWidth,
    headerHeight,
    author,
    userOnMobile,
    projectData,
    languages,
    navigationLinks,
    language: await data[0].json()
  }
}