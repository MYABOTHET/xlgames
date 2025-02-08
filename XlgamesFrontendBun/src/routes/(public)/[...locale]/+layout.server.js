import configuration from "$lib";
import Bowser from "bowser";

const mobileWidth = 72;
const headerHeight = 5;
const author = "Лёвин Валерий Дмитриевич";

export async function load({request, fetch, locals, setHeaders}) {
  const promises = [
    fetch(`${configuration.api}/Languages/${locals.language.Id}`),
    fetch(`${configuration.api}/ProjectDatas`),
  ];
  let languages = null;
  if (locals.languages) {
    languages = locals.languages;
  } else {
    promises.push(fetch(`${configuration.api}/Languages`));
  }
  const data = await Promise.all(promises);
  if (!languages) {
    languages = await data[2].json();
  }
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
    language: await data[0].json(),
  }
}