import React, { useState, useEffect } from "react";

import StartService from "../services/start.service";

const Home = () => {
  const [content, setContent] = useState("");

  useEffect(() => {

    console.log("use effect");

    StartService.getStartContent().then(
      (response) => {

        console.log("data");

        setContent(response.data);
      },
      (error) => {
        const _content =
          (error.response && error.response.data) ||
          error.message ||
          error.toString();

        setContent(_content);
      }
    );
  }, []);

  return (
    <div className="container">
      <header className="jumbotron">
        {content}
      </header>
    </div>
  );
};

export default Home;