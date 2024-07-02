import React, {useEffect} from 'react';
import { useLocation } from 'react-router-dom';


function Movies(props) {

    const location = useLocation();


    useEffect(() => {
        getMovieByName(location.state.title);
    });
    

    const getMovieByName = (name, page=1) => {
        const options = {
            method: 'GET',
            headers: {
              accept: 'application/json',
              Authorization: 'Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyYTcxYWMxNTc3NzdkZTM3YzIxNTFjY2Q3OTQxZjU1YSIsIm5iZiI6MTcxOTkwMDQ2Mi42MTI2NjYsInN1YiI6IjY1MzIyMzVkOWFjNTM1MDg3NzU2MGEzYyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.y5TSqyeTbCTp_O-27YpMYsXh1XYlAupIYM7oftoDMlI'
            }
          };
          
          fetch(`https://api.themoviedb.org/3/search/movie?query=${name}&include_adult=true&language=en-US&page=${page}`, options)
            .then(response => response.json())
            .then(response => console.log(response))
            .catch(err => console.error(err));

    };

    return (
        <div>
            
        </div>
    );
}

export default Movies;