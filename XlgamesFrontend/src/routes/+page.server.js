import configuration from "$lib";

export async function load({cookies, parent, fetch}) {
  const max = 4;
  const maxNews = 3;
  let userLocale = cookies.get(configuration.savedUserLocale);
  if (!userLocale) {
    const data = await parent();
    userLocale = data.language.Locale;
  }
  return {
    max,
    maxNews,
    news: await (await fetch(`${configuration.api}/News/${userLocale}?require=false&max=${maxNews}`)).json(),
    gameServers: [
      {
        Name: "Minecraft",
        Link: "Minecraft",
        Src: "/minecraft.webp",
        Popular: false,
        Presets: [
          {
            Locale: "en-US",
            Price: 16
          },
          {
            Locale: "ru-RU",
            Price: 1240
          },
        ]
      },
      {
        Name: "RUST",
        Link: "RUST",
        Src: "/rust.webp",
        Popular: true,
        Presets: [
          {
            Locale: "en-US",
            Price: 64
          },
          {
            Locale: "ru-RU",
            Price: 5600
          },
        ]
      },
      {
        Name: "Battlefield 2042",
        Link: "Battlefield-2042",
        Src: "/battlefield-2042.webp",
        Popular: false,
        Presets: [
          {
            Locale: "en-US",
            Price: 32
          },
          {
            Locale: "ru-RU",
            Price: 2860
          },
        ]
      },
      {
        Name: "7 Days to Die",
        Link: "7-Days-to-Die",
        Src: "/7-days-to-die.webp",
        Popular: true,
        Presets: [
          {
            Locale: "en-US",
            Price: 8
          },
          {
            Locale: "ru-RU",
            Price: 520
          },
        ]
      },
    ]
  }
}