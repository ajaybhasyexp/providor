import logo from './logo.svg';
import './App.css';
import { useState, useEffect } from 'react';
import MeterPoint from './components/MeterPoint';

function App() {
  const [books, setBooks] = useState(null);

  useEffect(() => {
    getData();

    // we will use async/await to fetch this data
    async function getData() {
      const response = await fetch("https://www.anapioficeandfire.com/api/books");
      const data = await response.json();
      // store the data into our books variable
      setBooks(data);
    }
  }, []);
  return (
    <div className="App">
      <MeterPoint/>
    </div>
  );
}

export default App;
