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