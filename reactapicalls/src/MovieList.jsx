import React from 'react';
import { useLocation } from 'react-router-dom';
import { useEffect, useState } from 'react';
import Navbar from './Navbar';
import { Outlet } from 'react-router-dom';
import useSWR from 'swr';
import axios from 'axios';


const MovieList = () => {
    const location = useLocation();
    const [isSignedIn, setIsSignedIn] = useState(false);

    const fetcher = async (url) => {
        const options = {
            method: 'GET',
            headers: {
                accept: 'application/json',
                Authorization: 'Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyYTcxYWMxNTc3NzdkZTM3YzIxNTFjY2Q3OTQxZjU1YSIsIm5iZiI6MTcyMDk0MDg1Mi40MzM4NTgsInN1YiI6IjY1MzIyMzVkOWFjNTM1MDg3NzU2MGEzYyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.D0mcyls1LflVgQprdWzp_lsiuYkppCgw-PEgSj3h1ZM'
            }
        };

        try {
            const response = await fetch(url, options)
            const data = await response.json()
            return data;
        }
        catch (error) {
            console.error(error);
        }
    };

    const { data, isLoading, isError } = useSWR(`https://api.themoviedb.org/3/search/movie?query=${location.state.from}&include_adult=false&language=en-US&page=1`, fetcher);

    if (isLoading) return (
        <div>
            <h1>
                Loading...
            </h1>
        </div>
    );

    if (isError) return <div>Error...</div>;


    return (
        <div>
            <header>
                <Navbar isSignedIn={isSignedIn} />
            </header>
            <div>

                <h1>Search results for "{location.state.from}"</h1>
                <ul>
                    {data.results.map((movie) => (
                        <li key={movie.id}>
                            <h2>{movie.title}</h2>
                            <p>Rating: {movie.vote_average}</p>
                        </li>
                    ))}
                </ul>
                    </div>
        </div>
    );
};

export default MovieList;