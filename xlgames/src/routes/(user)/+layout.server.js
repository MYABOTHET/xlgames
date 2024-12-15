export function load() {
  const navigation_links = {
    header: {
      menu: {
        order: 2,
        title: 'Выделенные серверы',
        links: [
          {
            title: 'Серверы',
            href: '/dedicated-servers',
          },
          {
            title: 'Серверы для ИИ',
            href: '/gpu-dedicated-servers',
          }
        ]
      },
      other: [
        {
          order: 1,
          title: 'Игровые серверы',
          href: '/game-servers'
        }
      ]
    },
    profile: {}
  };
  return {
    navigation_links
  }
}