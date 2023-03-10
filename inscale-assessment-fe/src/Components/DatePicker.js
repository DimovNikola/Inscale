import React from "react";

const DatePicker = ({ setDate }) => {
  return (
    <div className="relative max-w-sm">
      <div className="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none"></div>
      <input
        datepicker
        type="datetime-local"
        className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full pl-10 p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
        placeholder="Select date"
        onChange={(e) => setDate(e.target.value)}
      />
      <input type="text" id="expected" />
    </div>
  );
};

export default DatePicker;
