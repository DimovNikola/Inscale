import React, { useEffect, useState } from "react";
import ResourcesRepository from "../Services/ResourcesService";

const Resources = () => {
  const [resources, setResources] = useState([]);

  useEffect(() => {
    GetResources().then((res) => {
      setResources(res);
    });
  }, []);

  useEffect(() => {
    console.log(resources);
  }, [resources]);

  async function GetResources() {
    var result = await ResourcesRepository.GetResources();

    return result;
  }

  return <div>hello</div>;
};

export default Resources;
