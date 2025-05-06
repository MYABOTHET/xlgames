export async function process(action, options) {
  const response = await fetch(`${window.location.href}&handlerend=${action}`, {
    ...origin,
    ...options
  });
  if (response.ok) return response.json();
  else alert(await response.text());
  return false;
}