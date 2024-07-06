import { createSlice } from '@reduxjs/toolkit';

const tasksSlice = createSlice({
  name: 'tasks',
  initialState: {
    tasks: [],
  },
  reducers: {
    addTask: (state, action) => {
      state.tasks.push(action.payload);
    },
    deleteTask: (state, action) => {
      state.tasks = state.tasks.filter((task) => task.id !== action.payload);
    },
  },
});

export const { addTask } = tasksSlice.actions;
export const { deleteTask } = tasksSlice.actions;

export const selectTasks = (state) => state.tasks.tasks;

export default tasksSlice.reducer;
