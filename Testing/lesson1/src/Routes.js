import AddTask from './AddTask';
import Home from './Home';
import Tasks from './Tasks';

const routes = [
    {
        element: <Home />,
        path: '/'
    },
    {
        element: <Home />,
        path: '/home'
    },
    {
        element: <Tasks />,
        path: '/tasks',
    },
    {
        element: <AddTask />,
        path: '/add-task',
    }
]


export default routes;
