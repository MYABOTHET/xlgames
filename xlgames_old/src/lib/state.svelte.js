import {writable} from "svelte/store";

export const global_state = $state({
  shared_page: {},
});

export const store = writable({
  shared_page: {},
})

export const locale_store = $state({
  locale: "en-US"
});