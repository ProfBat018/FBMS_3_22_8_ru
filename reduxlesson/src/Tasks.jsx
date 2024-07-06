// components/Tasks.js

import React from 'react';
import { useSelector } from 'react-redux';
import { selectTasks } from './store/taskSlice';
import { Link } from 'react-router-dom';

const Tasks = () => {
  const tasks = useSelector(selectTasks);

  return (
    <div className="bg-gray-100 min-h-screen flex items-center justify-center">
      <div className="bg-white rounded-lg shadow-lg p-6 w-full md:w-1/2 lg:w-1/3">
        <h1 className="text-3xl font-semibold mb-4 text-center">Tasks List</h1>
        <div className="overflow-y-auto max-h-80">
          <div className="space-y-4">
            {tasks.map((task, index) => (
              <div key={index} className="border p-4 rounded-md shadow-sm">
                <h2 className="text-lg font-medium">{task.taskName}</h2>
                <p className="text-gray-700">{task.description}</p>
                {task.deadline && (
                  <p className="text-sm text-gray-500 mt-2">Deadline: {task.deadline}</p>
                )}
                {task.isImportant && (
                  <p className="text-sm text-red-500 font-semibold mt-2">Important</p>
                )}
              </div>
            ))}
            {tasks.length === 0 && (
              <p className="text-gray-500 text-center">No tasks available.</p>
            )}
          </div>
        </div>
        <Link to="/home">
          <button
            className="bg-blue-500 text-white py-2 px-4 rounded-md mt-4 w-full hover:bg-blue-600 transition duration-300"
          >
            Go back
          </button> 
        </Link>
      </div>
    </div>
  );
};

export default Tasks;
