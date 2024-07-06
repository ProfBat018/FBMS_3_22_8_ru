import React from 'react'
import { Link } from 'react-router-dom'


export default function Home() {

    
  return (
    <div className="bg-gray-100 min-h-screen flex items-center justify-center">
      <div className="bg-white rounded-lg shadow-lg p-6 w-full md:w-1/2 lg:w-1/3">
        <h1 className="text-3xl font-semibold mb-4 text-center">ToDoApp</h1>

        <Link to="/add-task">
          <button
            className="bg-blue-500 text-white py-2 px-4 rounded-md mb-4 w-full hover:bg-blue-600 transition duration-300"
          >
            Add New Task
          </button>
        </Link>

        <Link to="/tasks">
        <button
          className="bg-green-500 text-white py-2 px-4 rounded-md mb-4 w-full hover:bg-green-600 transition duration-300"
        >
          Show all tasks
        </button>
        </Link>
      </div>
    </div>
  );
}
