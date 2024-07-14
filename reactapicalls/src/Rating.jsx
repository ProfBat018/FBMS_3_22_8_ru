import React from 'react';
import useSWR from 'swr';
import { useState } from 'react';

const fetcher = async (url) => {
    // Настройки запроса включающие тип и JWT токен для авторизации
    const options = {
        method: 'GET',
        headers: {
          accept: 'application/json',
          Authorization: 'Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyYTcxYWMxNTc3NzdkZTM3YzIxNTFjY2Q3OTQxZjU1YSIsIm5iZiI6MTcyMDY4ODI1Mi43NzE0MjMsInN1YiI6IjY1MzIyMzVkOWFjNTM1MDg3NzU2MGEzYyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.yy0TtNHYgbI1PrpQlaZevl1bavBPiUpi1J7za27Qyvs'
        }
      };
      await new Promise(resolve => setTimeout(resolve, 3000));

      try {
          const response = await fetch(url, options);
          const data = await response.json();
          return data;
      }
      catch (error) {
        console.error(error);
      }
}

function Rating() {
  const [page, setPage] = useState(1);

    const {data, isLoading, isError} = useSWR(`https://api.themoviedb.org/3/movie/popular?language=en-US&page=${page}`, fetcher);


    if (isLoading) return ( 
    <div> 
      <h1>
      Loading...
      </h1>
      </div>
    );
    if (isError) return <div>Error...</div>
    
    return (
      <div>
        <h1>Popular movies</h1>
        <ul>
          {data.results.map((movie) => (
            <li key={movie.id}>
              <h2>{movie.title}</h2>
              <p>Rating: {movie.vote_average}</p>
            </li>
          ))} 
        </ul>

        <button onClick={() => setPage(page - 1)}>Previous page</button>
        <button onClick={() => setPage(page + 1)}>Next page</button>


        </div>
    );
}

export default Rating;