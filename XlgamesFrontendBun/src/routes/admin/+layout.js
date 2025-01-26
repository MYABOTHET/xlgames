const title = "Панель управления";
const links = [
  {
    title: "Данные проекта",
    href: "/admin/project"
  },
  {
    title: "Переводы",
    href: "/admin/translates"
  },
  {
    title: "Игровые серверы",
    href: "/admin/game-servers"
  },
  {
    title: "Продукты",
    href: "/admin/products"
  }
];

export function load() {
  return {
    title,
    links
  }
}