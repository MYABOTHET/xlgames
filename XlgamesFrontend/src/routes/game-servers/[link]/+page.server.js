import configuration from "$lib";

export async function load({cookies, parent, fetch}) {
  return {
    gameServer: {
      Name: "Minecraft",
      Link: "Minecraft",
      Src: "/minecraft.webp",
      Slots: 0,
      CPU: "...",
      RAM: "...",
      Disk: "...",
      Data: {
        Head: "",
        Price: 1240,
        Description: "...",
        GameServerPoints: ["...", "...", "..."],
      }
    },
  }
}