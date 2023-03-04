import React, { useEffect, useState } from "react";
import Loading from "../Components/Loading";
import Modal from "../Components/Modal";
import Table from "../Components/Table";
import ResourcesRepository from "../Services/ResourcesService";

const Resources = () => {
  const [resources, setResources] = useState([]);
  const [columns, setColumns] = useState([]);
  const [loading, setLoading] = useState(false);
  const [showModal, setShowModal] = useState(false);
  const [selectedResource, setSelectedResource] = useState(0);

  useEffect(() => {
    setLoading(true);
    GetResources().then((res) => {
      console.log(res);
      setResources(res);
      setColumns(Object.keys(res[0]));
      setLoading(false);
    });
  }, []);

  async function GetResources() {
    var result = await ResourcesRepository.GetResources();

    if (result.data === null) {
      // show not found page
    }

    return result.data;
  }

  function onClick(e) {
    console.log(e.target.id);
    // display modal
    setShowModal(true);
    setSelectedResource(e.target.id);
  }

  if (showModal) {
    return (
      <Modal
        setShowModal={setShowModal}
        resourceName={resources[selectedResource - 1].name}
        setSelectedResource={setSelectedResource}
        resourceId={selectedResource}
      />
    );
  }

  return (
    <div className="flex items-center justify-center min-h-screen">
      {loading ? (
        <Loading />
      ) : (
        <Table
          rows={resources}
          columns={columns}
          actions={["Book"]}
          tableName="Resources"
          ignoreCol={"quantity"}
          onClick={onClick}
        />
      )}
    </div>
  );
};

export default Resources;
