import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
const AnxietyTest = () => {
  const { testId } = useParams();
  const [questions, setQuestions] = useState([]);
  const [test, setTest] = useState([]);
  const [answers, setAnswers] = useState([]);
  const [currentQuestion, setCurrentQuestion] = useState(0);
  const [analysisResult, setAnalysisResult] = useState(null);

  
  useEffect(() => {
    const fetchQuestions = async (testId) => {
      try {
        const response = await fetch(`http://localhost:5227/api/tests/${testId}`);
        const data = await response.json();
        setQuestions(data.questions);
        setAnswers(Array(data.questions.length).fill(''));
        setTest(data);
      } catch (error) {
        console.error('Error fetching questions:', error);
      }
    };
    
    fetchQuestions(testId);
  }, [testId]);

  const handleAnswer = (answer) => {
    const newAnswers = [...answers];
    newAnswers[currentQuestion] = answer;
    setAnswers(newAnswers);

    // Move to the next question or finish the test
    if (currentQuestion < questions.length - 1) {
      setCurrentQuestion(currentQuestion + 1);
    } else {
      // Perform analysis when all questions are answered
      const anxietyLevel = analyzeAnswers(newAnswers);
      setAnalysisResult(anxietyLevel);
    }
  };

  const analyzeAnswers = (userAnswers) => {
    let totalAnxietyScore = 0;

    userAnswers.forEach((userChoice, index) => {
      const question = questions[index];
      const selectedChoice = question.choices.find((choice) => choice.choiceContent === userChoice);

      if (selectedChoice) {
        totalAnxietyScore += getAnxietyScore(selectedChoice.choiceType);
      }
    });

    if (totalAnxietyScore <= 5) {
      return 'Low Anxiety Level';
    } else if (totalAnxietyScore <= 12) {
      return 'Moderate Anxiety Level';
    } else {
      return 'High Anxiety Level';
    }
  };

  const getAnxietyScore = (choiceType) => {
    switch (choiceType) {
      case 'No Anxiety':
        return 0;
      case 'Mild Anxiety':
        return 2;
      case 'Severe Anxiety':
        return 3;
      default:
        return 0;
    }
  };

  return (
    <div>
       <h2>{test.title}</h2>
      {analysisResult ? (
  <div>
    <p>Your anxiety level: {analysisResult}</p>
    {/* You can provide more detailed feedback or suggestions here */}
  </div>
) : (
  <div>
    <p>{questions[currentQuestion]?.questionContent}</p>
    <div>
      {questions[currentQuestion]?.choices.map((choice) => (
        <button key={choice.id} onClick={() => handleAnswer(choice.choiceContent)}>
          {choice.choiceContent}
        </button>
      ))}
    </div>
  </div>
)}
    </div>
  );
};

export default AnxietyTest;