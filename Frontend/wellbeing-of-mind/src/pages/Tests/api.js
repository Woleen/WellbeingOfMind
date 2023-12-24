import React, { useEffect, useState, useParams } from "react";


  const TestDetail = () => {
    const { TestId } = useParams();
    const [test, setTest] = useState({});
    const [loading, setLoading] = useState(true);
  
    useEffect(() => {
      fetch(`https://localhost:7267/api/tests/${TestId}`)
        .then((response) => response.json())
        .then((data) => setTest(data))
        .catch((error) => console.error("Error fetching article:", error))
        .finally(() => setLoading(false));
    }, [TestId]);
  
    if (loading) {
      return <p>Loading...</p>;
    }
    return test
  }
export default TestDetail;