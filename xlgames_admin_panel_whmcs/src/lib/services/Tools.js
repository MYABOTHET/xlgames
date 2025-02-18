class Tools {
  get_url() {
    return new URL(window.location.href);
  }
  append_method(url, method) {
    url.searchParams.append("method", method);
  }
  parse_error(body) {
    return body.error_message;
  }
}

const ToolsService = new Tools();

export default ToolsService;