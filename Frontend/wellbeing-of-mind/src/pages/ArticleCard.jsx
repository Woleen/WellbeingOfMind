import React from "react";

const ArticleCard = ({ article }) => {
  return (
    <div className="card" style={{ backgroundColor: "lightblue" }}>
      <div className="card-body">
        <h5 className="card-title">{article.title}</h5>

        <p className="card-text">{article.description}</p>
        <p className="card-text">
          <small className="text-muted">
            {article.author} <br /> {article.createdAt.slice(0, 10)}
          </small>
        </p>
      </div>
    </div>
  );
};

export default ArticleCard;
