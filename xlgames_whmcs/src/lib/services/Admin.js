import Tools from "./Tools.js";

class Admin {
  save_keys(keys) {
    let url = Tools.get_url();
    this.append_save_keys_method(url);
    return fetch(url.href, {method: "POST", body: JSON.stringify(keys)});
  }
  get_keys() {
    let url = Tools.get_url();
    this.append_save_keys_method(url);
    return fetch(url.href);
  }
  append_languages_method(url) {
    Tools.append_method(url, "languages");
  }
  append_language_method(url) {
    Tools.append_method(url, "language");
  }
  append_save_keys_method(url) {
    Tools.append_method(url, "keys");
  }
  get_languages() {
    let url = Tools.get_url();
    this.append_languages_method(url);
    return fetch(url.href);
  }
  get_language(name) {
    let url = Tools.get_url();
    this.append_language_method(url);
    url.searchParams.append("language", name);
    return fetch(url.href);
  }
  update_language(language, save = false) {
    let url = Tools.get_url();
    this.append_language_method(url);
    if (save) url.searchParams.append("save", "yes");
    return fetch(url.href, {method: "POST", body: JSON.stringify(language)});
  }
  delete_language(name) {
    let url = Tools.get_url();
    this.append_language_method(url);
    url.searchParams.append("name", name)
    return fetch(url.href, {method: "DELETE"});
  }
}

const AdminService = new Admin();

export default AdminService;