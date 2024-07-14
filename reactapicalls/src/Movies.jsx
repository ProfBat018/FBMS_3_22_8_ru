import React from 'react';
import { useRef, useState, useEffect } from 'react';
import {Link} from 'react-router-dom';

function Movies(props) {

    const [search, setSearch] = useState();

    const getMoviesByName = () => {
    };

    return (
        <div>
            <div className="flex justify-center items-center h-screen">
                <div className="flex flex-col w-96">
                    <input
                        onChange={(e) => setSearch(e.target.value)}
                        type="text"
                        placeholder="Search for movies"
                        className="px-4 py-2 border border-gray-300 rounded-md"
                    />
                    <Link to="/movielist" state={{ from: search }} >
                        <button onClick={getMoviesByName} className="bg-blue-500 text-white px-4 py-2 mt-2 rounded-md">
                            Search
                        </button>
                    </Link>
                </div>
            </div>

            <div>
                <p>Want to see rating ? </p>

                <Link to="/home/rating">
                    <button className="bg-blue-500 text-white px-4 py-2 mt-2 rounded-md">
                        Click here
                    </button>
                </Link>

            </div>
        </div>
    );
}

export default Movies;