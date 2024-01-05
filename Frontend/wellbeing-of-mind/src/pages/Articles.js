import React, { useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSearch } from "@fortawesome/free-solid-svg-icons";
import ArticleCard from "./ArticleCard";
import { useNavigate } from "react-router-dom";

const ArticleList = () => {
  const [articles, setArticles] = useState([]);
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();

  useEffect(() => {
    fetch("https://localhost:7267/api/articles")
      .then((response) => response.json())
      .then((data) => setArticles(data))
      .catch((error) => console.error("Error fetching articles:", error))
      .finally(() => setLoading(false));
  }, []);

  const handleCardClick = (articleId) => {
    navigate(`/article/${articleId}`);
  };

  return (
    <div className="container mt-5">
      <h2>Article List</h2>
      <div className="input-group mb-3">
        <input
          type="text"
          className="form-control"
          onChange={() => {}}
        />
        <button className="btn btn-outline-secondary" type="button">
          <FontAwesomeIcon icon={faSearch} />
        </button>
      </div>
      <div>{loading ? <p>Loading...</p> : <p></p>}</div>
      <div className="row row-cols-1 row-cols-md-2 row-cols-lg-5 g-4">
        {articles.map((article) => (
          <div
            key={article.id}
            className="col"
            onClick={() => handleCardClick(article.id)}
            style={{ cursor: "pointer" }}
          >
            <ArticleCard article={article} />
          </div>
        ))}
      </div>
    </div>
  );
};

export default ArticleList;
