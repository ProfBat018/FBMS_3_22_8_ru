import "./App.css";
import React, { useState, useEffect } from "react";

function App() {
  const [forecast, setForecast] = useState([]);
  const [dbData, setDbData] = useState(null);

  useEffect(() => {
    // Fetch initial weather forecast
    fetch("http://localhost:8080/weatherforecast")
      .then((response) => {
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        return response.json(); // Parse the JSON response
      })
      .then((data) => {
        console.log("Weather forecast:", data); // Handle the response data
        setForecast(data);
      })
      .catch((error) => {
        console.error("Error fetching weather forecast:", error); // Handle errors
      });
  }, []);

  const fetchDbData = () => {
    // Fetch data from the new endpoint
    fetch("http://localhost:8080/getallfromdb")
      .then((response) => {
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        return response.json(); // Parse the JSON response
      })
      .then((data) => {
        console.log("Database data:", data); // Log the result
        setDbData(data);
      })
      .catch((error) => {
        console.error("Error fetching database data:", error); // Handle errors
      });
  };

  return (
    <div className="App">
      <h1>Weather Forecast</h1>
      <table border="1" style={{ borderCollapse: "collapse", width: "100%" }}>
        <thead>
          <tr>
            <th>Date</th>
            <th>Temperature (°C)</th>
            <th>Temperature (°F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecast.map((item, index) => (
            <tr key={index}>
              <td>{item.date}</td>
              <td>{item.temperatureC}</td>
              <td>{item.temperatureF}</td>
              <td>{item.summary}</td>
            </tr>
          ))}
        </tbody>
      </table>

      <h2>Database Data</h2>
      <button onClick={fetchDbData}>Fetch Data from Database</button>

      {dbData && (
        <div
          style={{
            marginTop: "20px",
            padding: "10px",
            border: "1px solid #ccc",
            borderRadius: "5px",
            maxHeight: "300px",
            overflowY: "scroll",
            backgroundColor: "#f9f9f9",
          }}
        >
          <pre>{JSON.stringify(dbData, null, 2)}</pre>
        </div>
      )}
    </div>
  );
}

export default App;