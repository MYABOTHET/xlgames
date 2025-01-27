import configuration from "$lib";

export async function load({fetch, params}) {
  const language = await (await fetch(`${configuration.api}/Languages/${params.id}`)).json();
  const linksOptions = [
    {
      title: "Настройки",
      href: `/admin/translates/${params.id}/settings`
    },
    {
      title: "Общий перевод",
      href: `/admin/translates/${params.id}/shared`
    },
    {
      title: "Главная страница",
      href: `/admin/translates/${params.id}/home`
    },
    {
      title: "Игровые серверы",
      href: `/admin/translates/${params.id}/game-servers`
    },
    {
      title: "Игровой сервер",
      href: `/admin/translates/${params.id}/game-server`
    },
    {
      title: "Серверы без GPU",
      href: `/admin/translates/${params.id}/servers-without-a-gpu`
    },
    {
      title: "Серверы с GPU",
      href: `/admin/translates/${params.id}/servers-with-gpu`
    },
    {
      title: "VPS",
      href: `/admin/translates/${params.id}/vps`
    },
    {
      title: "Веб хостинг",
      href: `/admin/translates/${params.id}/web-hosting`
    },
    {
      title: "VPN",
      href: `/admin/translates/${params.id}/vpn`
    },
    {
      title: "Дата центры",
      href: `/admin/translates/${params.id}/data-centers`
    },
    {
      title: "Новости",
      href: `/admin/translates/${params.id}/news`
    },
    {
      title: "О нас",
      href: `/admin/translates/${params.id}/about-us`
    },
    {
      title: "Контакты",
      href: `/admin/translates/${params.id}/contacts`
    },
    {
      title: "Усл. обслуж.",
      href: `/admin/translates/${params.id}/terms-of-service`
    },
    {
      title: "Пол. конфид.",
      href: `/admin/translates/${params.id}/privacy-policy`
    },
    {
      title: "Пол. «Cookie»",
      href: `/admin/translates/${params.id}/cookie-policy`
    }
  ];
  return {
    language,
    linksOptions
  }
}