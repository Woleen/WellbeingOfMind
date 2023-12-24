import React from "react";
import Layout from "./pages/Layout";
import Articles from "./pages/Articles";
import ArticleDetail from "./pages/ArticleDetail";
import NoPage from "./pages/NoPage";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import TestsList from "./pages/Tests/TestsPage";
import Test from "./pages/Tests/Test";


function App() {
  return (
    <div>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Layout />}>
            <Route path="/articles" element={<Articles />}></Route>
            <Route path="/article/:articleId" element={<ArticleDetail />} />
            <Route path="/tests" element={<TestsList />} />
            <Route path="/tests/:testId" element={<Test />} />
            <Route path="*" element={<NoPage />} /></Route>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
