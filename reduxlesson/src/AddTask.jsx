import React, { useRef } from 'react';
import { useDispatch } from 'react-redux';
import { Link } from 'react-router-dom';
import { addTask } from './store/taskSlice';


export default function AddTask() {
  const dispatch = useDispatch();
  const taskNameRef = useRef('');
  const descriptionRef = useRef('');
  const deadlineRef = useRef('');
  const isImportantRef = useRef(false);

  const handleSubmit = (e) => {
    e.preventDefault();

    const newTask = {
      taskName: taskNameRef.current.value,
      description: descriptionRef.current.value,
      deadline: deadlineRef.current.value,
      isImportant: isImportantRef.current.checked,
    };

    dispatch(addTask(newTask));

    // Очистка значений полей формы
    taskNameRef.current.value = '';
    descriptionRef.current.value = '';
    deadlineRef.current.value = '';
    isImportantRef.current.checked = false;
  };

  return (
    <div className="bg-gray-100 min-h-screen flex items-center justify-center">
      <div className="bg-white rounded-lg shadow-lg p-6 w-full md:w-1/2 lg:w-1/3">
        <h1 className="text-3xl font-semibold mb-4 text-center">Add New Task</h1>
        <form onSubmit={handleSubmit}>
          <div className="mb-4">
            <label htmlFor="taskName" className="block text-sm font-medium text-gray-700">
              Task Name
            </label>
            <input
              type="text"
              id="taskName"
              ref={taskNameRef}
              className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
              placeholder="Enter task name..."
              required
            />
          </div>

          <div className="mb-4">
            <label htmlFor="description" className="block text-sm font-medium text-gray-700">
              Description
            </label>
            <textarea
              id="description"
              ref={descriptionRef}
              rows={3}
              className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
              placeholder="Enter task description..."
              required
            />
          </div>

          <div className="mb-4">
            <label htmlFor="deadline" className="block text-sm font-medium text-gray-700">
              Deadline
            </label>
            <input
              type="date"
              id="deadline"
              ref={deadlineRef}
              className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
            />
          </div>

          <div className="mb-4">
            <div className="flex items-center">
              <input
                type="checkbox"
                id="isImportant"
                ref={isImportantRef}
                className="focus:ring-blue-500 h-4 w-4 text-blue-600 border-gray-300 rounded"
              />
              <label htmlFor="isImportant" className="ml-2 block text-sm text-gray-900">
                Is Important
              </label>
            </div>
          </div>

          <button
            type="submit"
            className="bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600 transition duration-300"
          >
            Add Task
          </button>

          <Link to='/home'>
            <button
              className="bg-red-500 text-white py-2 px-4 rounded-md hover:bg-red-600 transition duration-300"
            >
              Cancel
            </button>
          </Link>
        </form>
      </div>
    </div>
  );
}
