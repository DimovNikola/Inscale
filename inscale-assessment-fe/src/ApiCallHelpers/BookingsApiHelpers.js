import API from "../Common/api";

let BookingsApiCallHellper = {
  BookResource: async function (resource) {
    let response = await API.post("Bookings", resource).then((res) => {
      return res.data;
    });

    if (response === null || response === undefined) {
      return [];
    }

    return response;
  },
};

export default BookingsApiCallHellper;
