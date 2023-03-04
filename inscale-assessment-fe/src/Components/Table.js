import React from "react";

const Table = ({ rows, columns, actions, tableName, ignoreCol, onClick }) => {
  return (
    <div className="flex flex-col justify-center h-full w-full">
      <div className="w-full max-w-2xl mx-auto bg-white shadow-lg rounded-sm border border-gray-200">
        <header className="px-5 py-4 border-b border-gray-100">
          <h2 className="font-semibold text-gray-800">{tableName}</h2>
        </header>
        <div className="p-3">
          <div className="overflow-x-auto">
            <table className="table-auto w-full">
              <thead className="text-xs font-semibold uppercase text-gray-400 bg-gray-50">
                <tr>
                  {columns.map((column) => {
                    if (column !== ignoreCol)
                      return (
                        <th
                          key={column.length}
                          className="p-2 whitespace-nowrap"
                        >
                          <div className="font-semibold text-left">
                            {column}
                          </div>
                        </th>
                      );
                  })}
                  {actions.map((action) => {
                    return (
                      <th
                        key={action.length}
                        className="p-2 whitespace-nowrap w-50"
                      >
                        <div className="font-semibold text-end">
                          {action}ING
                        </div>
                      </th>
                    );
                  })}
                </tr>
              </thead>
              <tbody className="text-sm divide-y divide-gray-100">
                {rows.map((row) => {
                  return (
                    <tr key={row.id}>
                      {columns.map((column) => {
                        if (column !== ignoreCol)
                          return (
                            <td key={row.Id} className="p-2 whitespace-nowrap">
                              <div className="flex items-center">
                                <div className="font-medium text-gray-800">
                                  {row[column]}
                                </div>
                              </div>
                            </td>
                          );
                      })}
                      {actions.map((action) => {
                        return (
                          <td key={row.id} className="p-2 whitespace-nowrap">
                            <div className="container flex flex-col items-end">
                              <button
                                onClick={onClick}
                                key={row.id}
                                id={row.id}
                                className="py-2 px-4 bg-transparent text-red-600 font-semibold border border-red-600 rounded hover:bg-red-600 hover:text-white hover:border-transparent transition ease-in duration-200 transform hover:-translate-y-1 active:translate-y-0"
                              >
                                {action}
                              </button>
                            </div>
                          </td>
                        );
                      })}
                    </tr>
                  );
                })}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Table;
