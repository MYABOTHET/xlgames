import configuration from "$lib";
import DeviceDetector from "node-device-detector";
import DeviceHelper from "node-device-detector/helper";
import {getUserLanguageFromCookies} from "$lib/tools.js";

const mobileWidth = 64;
const headerHeight = 5;
const author = "Лёвин Валерий Дмитриевич";
const detector = new DeviceDetector();

export async function load({request, fetch, cookies, locals}) {
  const userAgent = request.headers.get("user-agent");
  const userData = detector.detect(userAgent);
  const userOnMobile = DeviceHelper.isMobile(userData);
  const projectData = await (await fetch(`${configuration.api}/ProjectDatas`)).json();
  const navigationLinks = {
    header: {
      menu: {
        name: "DedicatedServers", position: 2, links: [{
          name: "ServersWithoutGPU", href: "/servers"
        }, {
          name: "ServersWithGPU", href: "/servers-gpu"
        }]
      }, other: [{
        position: 1, name: "GameServers", href: "/game-servers"
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
  return {
    mobileWidth,
    headerHeight,
    author,
    navigationLinks,
    userOnMobile,
    projectData,
    languages: locals.languages ? locals.languages : await (await fetch(`${configuration.api}/Languages`)).json(),
    language: await (await fetch(`${configuration.api}/Languages/${getUserLanguageFromCookies(cookies).Id}`)).json(),
  }
}