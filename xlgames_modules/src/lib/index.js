export async function process(action, options) {
  return fetch(`${window.location.href}&handlerend=${action}`, {
    ...origin,
    ...options
  });
}