import DeviceDetector from "node-device-detector";
import DeviceHelper from "node-device-detector/helper";

const detector = new DeviceDetector({
  clientIndexes: true,
  deviceIndexes: true,
  deviceAliasCode: false,
  deviceTrusted: false,
  deviceInfo: false,
  maxUserAgentSize: 500,
});

export function load({request}) {
  const mobile = DeviceHelper.isMobile(detector.detect(request.headers.get('user-agent')));
  return {
    mobile
  }
}