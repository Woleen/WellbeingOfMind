import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

const ArticleDetail = () => {
  const { articleId } = useParams();
  const [article, setArticle] = useState({});
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch(`https://localhost:7267/api/articles/${articleId}`)
      .then((response) => response.json())
      .then((data) => setArticle(data))
      .catch((error) => console.error("Error fetching article:", error))
      .finally(() => setLoading(false));
  }, [articleId]);

  if (loading) {
    return <p>Loading...</p>;
  }

  return (
    <div className="container mt-4">
      <div className="row">
        <div className="col-lg-8">
          <h2>{article.title}</h2>
          <div className="content" style={{ textAlign: "justify" }}>
            <div dangerouslySetInnerHTML={{ __html: article.content }} />
          </div>
          <p className="mt-3" style={{ textAlign: "right" }}>
            Author: dr {article.author}
          </p>
        </div>
      </div>
    </div>
  );
};

export default ArticleDetail;
