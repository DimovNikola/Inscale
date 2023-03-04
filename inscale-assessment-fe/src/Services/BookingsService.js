import BookingsApiCallHellper from "../ApiCallHelpers/BookingsApiHelpers";

let BookingsRepository = {
  BookResource: async function (resource) {
    var result = await BookingsApiCallHellper.BookResource(resource);
    return result;
  },
};

export default BookingsRepository;
