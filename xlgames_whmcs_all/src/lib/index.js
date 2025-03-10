const default_params = {
  headers: {
    "Content-Type": "application/json"
  }
};

export async function process(action, params) {
  const response = await fetch(`${window.location.href}&action=${action}`, {
    ...default_params,
    ...params
  });
  if (response.ok) return response.json();
  else alert(await response.text());
  return undefined;
}

export function compare(a, b) {
  if (a > b) return 1;
  if (a === b) return 0;
  if (a < b) return -1;
}