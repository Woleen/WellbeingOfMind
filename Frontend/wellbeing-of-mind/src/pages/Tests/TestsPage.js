import React, { useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSearch } from "@fortawesome/free-solid-svg-icons";
import { useNavigate } from "react-router-dom";

const TestsList = () => {
  const [tests, setTests] = useState([]);
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();

  useEffect(() => {
    fetch("http://localhost:5227/api/tests")
      .then((response) => response.json())
      .then((data) => setTests(data))
      .catch((error) => console.error("Error fetching articles:", error))
      .finally(() => setLoading(false));
  }, []);

  const handleCardClick = (testId) => {
    navigate(`/test/${testId}`);
  };

  return (
    <div className="container mt-5">
      <h2>Tests List</h2>
      <div className="input-group mb-3">
        <input
          type="text"
          className="form-control"
          placeholder="Search for tests"
          onChange={() => {}}
        />
        <button className="btn btn-outline-secondary" type="button">
          <FontAwesomeIcon icon={faSearch} />
        </button>
      </div>
      <div>{loading ? <p>Loading...</p> : <p></p>}</div>
      <div className="card" style={{ backgroundColor: "lightblue" }}>
        <div className="card-body">
          {tests.map((test) => (
            <div
              key={test.id}
              className="col"
              onClick={() => handleCardClick(test.id)}
              style={{ cursor: "pointer" }}
            >
            <h5 className="card-title">{test.title}</h5>
            <p className="card-text">{test.description}</p>
            </div>
          ))}
        </div>
    </div>
    </div>
  );
};


export default TestsList;
