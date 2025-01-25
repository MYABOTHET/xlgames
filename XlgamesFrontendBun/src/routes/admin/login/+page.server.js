import configuration from "$lib";
import { redirect } from '@sveltejs/kit';

function getCookie(response) {
  return response.headers.get("set-cookie").split("; ").reduce((acc, item) => {
    const [name, value] = item.split("=")
    acc[name] = value
    return acc
  }, {});
}

/** @satisfies {import('./$types').Actions} */
export const actions = {
  default: async ({ request, fetch, cookies }) => {
    const data = await request.formData();
    const login = data.get("login");
    const password = data.get("password");
    const response = await fetch(`${configuration.api}/Auth/Login`, {
      method: "POST",
      body: JSON.stringify({
        name: login,
        password
      }),
      headers: {
        "Content-Type": "application/json"
      },
    });
    if (response.status === 200) {
      cookies.set(".AspNetCore.Cookies", getCookie(response)[".AspNetCore.Cookies"], {path: "/admin", maxAge: 60 * 60 * 24 * 5,
      sameSite: "Strict", priority: "high", httpOnly: true, secure: true});
      redirect(301, "/admin");
      return {success: true};
    }
    const body = await response.json();
    const errors = Object.values(body.errors);
    let result = [];
    errors.forEach(error => {
      result = result.concat(error);
    })
    return {success: false, errors: result};
  },
};