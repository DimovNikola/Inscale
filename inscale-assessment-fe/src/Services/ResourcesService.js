import ResourcesApiCallhelper from "../ApiCallHelpers/ResourcesApiHelpers";

let ResourcesRepository = {
  GetResources: async function () {
    var result = await ResourcesApiCallhelper.GetResources();
    return result;
  },
};

export default ResourcesRepository;
