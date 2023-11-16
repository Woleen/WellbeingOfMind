import React from "react";
import Layout from "./pages/Layout";
import Articles from "./pages/Articles";
import NoPage from "./pages/NoPage";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Tests from './pages/Tests/Tests'
import { jsQuizz } from './pages/Tests/constatants';

function App() {
  return (
    
    <div>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Layout />}>
            <Route path="/articles" element={<Articles />}></Route>
            <Route path="*" element={<NoPage />} />
            <Route path="/tests" element={<Tests questions={jsQuizz.questions} />}></Route>

          </Route>
        </Routes>
      </BrowserRouter>
    </div>
   
     
  );
   

   
 
}

export default App;
