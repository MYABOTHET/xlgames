export function load() {

  const language = {
    navigation_links: {
      dedicated_servers: 'Выделенные серверы',
    }
  }
  const navigation_links = {
    header: {
      menu: {
        order: 2,
        title: 'dedicated_servers',
        links: [
          {
            title: 'Серверы',
            href: '/dedicated-servers'
          },
          {
            title: 'Серверы для ИИ',
            href: '/gpu-dedicated-servers'
          }
        ]
      },
      other: [
        {
          order: 1,
          title: 'Игровые серверы',
          href: '/game-servers'
        },
        {
          order: 3,
          title: 'VPS',
          href: '/vps'
        },
        {
          order: 4,
          title: 'Веб хостинг',
          href: '/web-hosting'
        },
        {
          order: 5,
          title: 'VPN',
          href: '/vpn'
        }
      ]
    },
    profile: [
      {
        title: 'Личный кабинет',
        href: 'https://xlgames.gg/store/login'
      },
      {
        title: 'Игровой хостинг',
        href: 'https://clients.xlgames.pro/main/index?last=main/index'
      },
    ],
    footer: [
      {
        title: 'Условия обслуживания',
        href: '/terms-of-service'
      },
      {
        title: 'Политика конфиденциальности',
        href: '/privacy-policy'
      },
    ],
    other: [
      {
        title: 'Центр обработки данных',
        href: '/data-center'
      },
      {
        title: 'Новости',
        href: '/news'
      },
      {
        title: 'О нас',
        href: '/about'
      },
      {
        title: 'Контакты',
        href: '/contacts'
      },
    ]
  };
  const project_titles = {
    logo: 'XL',
    title: 'XLGAMES.GG',
    year: '2024'
  };
  const languages = [
    {
      id: 'russian',
      title: 'Русский'
    },
    {
      id: 'english',
      title: 'English'
    },
    {
      id: 'german',
      title: 'Deutsch'
    },
  ];

  return {
    navigation_links, project_titles, languages, language
  }
}