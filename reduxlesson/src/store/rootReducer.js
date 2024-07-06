import { combineReducers } from '@reduxjs/toolkit';
import tasksReducer from './taskSlice';

const rootReducer = combineReducers({
  tasks: tasksReducer,
});

export default rootReducer;
