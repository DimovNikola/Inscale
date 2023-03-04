import React, { useState } from "react";
import BookingsRepository from "../Services/BookingsService";
import DatePicker from "./DatePicker";

const Modal = ({ setShowModal, resourceName, setSelectedResource }) => {
  const [dateFrom, setDateFrom] = useState();
  const [dateTo, setDateTo] = useState();
  const [quantity, setQuantity] = useState();

  async function bookResource() {
    let resource = {
      id: 0,
      dateFrom: dateFrom,
      dateTo: dateTo,
      bookedQuantity: quantity,
      resourceId: setSelectedResource,
    };

    var result = await BookingsRepository.BookResource(resource);

    return result;
  }

  return (
    <>
      <div className="justify-center items-center flex overflow-x-hidden overflow-y-auto fixed inset-0 z-50 outline-none focus:outline-none">
        <div className="relative w-auto my-6 mx-auto max-w-3xl">
          {/*content*/}
          <div className="border-0 rounded-lg shadow-lg relative flex flex-col w-full bg-white outline-none focus:outline-none">
            {/*header*/}
            <div className="flex items-center justify-around p-5 border-b border-solid border-slate-200 rounded-t">
              <h3 className="text-3xl font-semibold">Booking {resourceName}</h3>
              <button
                type="button"
                className="text-gray-400 bg-transparent hover:bg-gray-200 hover:text-gray-900 rounded-lg text-sm p-1.5 ml-auto inline-flex items-center dark:hover:bg-gray-600 dark:hover:text-white"
                data-modal-hide="defaultModal"
                onClick={() => {
                  setShowModal(false);
                  setSelectedResource(0);
                }}
              >
                <svg
                  aria-hidden="true"
                  className="w-5 h-5"
                  fill="currentColor"
                  viewBox="0 0 20 20"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    fillRule="evenodd"
                    d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
                    clipRule="evenodd"
                  ></path>
                </svg>
                <span className="sr-only">Close modal</span>
              </button>
            </div>
            {/*body*/}
            <div className="relative p-6 flex-auto flex items-start justify-between space-x-32">
              <div className="grid gap-6 mb-6 lg:grid-cols-1">
                <div className="relative p-6 flex-auto flex items-start justify-between space-x-32">
                  <p className="my-4 text-slate-500 text-lg leading-relaxed flex">
                    Date From
                  </p>
                  <DatePicker setDate={setDateFrom} />
                </div>
                <div className="relative p-6 flex-auto flex items-start justify-between space-x-32">
                  <p className="my-4 text-slate-500 text-lg leading-relaxed flex">
                    Date To
                  </p>
                  <DatePicker setDate={setDateTo} />
                </div>
                <div className="relative p-6 flex-auto flex items-start justify-between space-x-32">
                  <p className="my-4 text-slate-500 text-lg leading-relaxed flex">
                    Quantity
                  </p>
                  <input
                    type="number"
                    className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                    placeholder="0"
                    onChange={(e) => setQuantity(e.target.value)}
                  />
                </div>
              </div>
            </div>
            {/*footer*/}
            <div className="flex items-end justify-end p-6 border-t border-solid border-slate-200 rounded-b">
              <button
                className="bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-sm px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150"
                type="button"
                onClick={bookResource}
              >
                Book
              </button>
            </div>
          </div>
        </div>
      </div>
      <div className="opacity-25 fixed inset-0 z-40 bg-black"></div>
    </>
  );
};

export default Modal;
