import API from "../Common/api";

let ResourcesApiCallhelper = {
  GetResources: async function () {
    let response = await API.get("Resources").then((res) => {
      return res.data;
    });

    if (response === null || response === undefined) {
      return [];
    }

    return response;
  },
};

export default ResourcesApiCallhelper;
