# Взоможности API запросов в React 

В общем у нас есть несколько вариантов того, как мы можем делать запросы к серверу в React.
- Fetch API
- Axios
- react-query
- SWR

## Fetch API

Этот способ мы рассматривали уже много раз. В нем нет ничего сложного. Просто делаем запрос к серверу и получаем данные. 

## Axios

Axios - это библиотека для работы с запросами. Она позволяет делать запросы к серверу и получать данные. По факту я воспринимаю Axios как улучшенный Fetch API.

## react-query

`react-query` - это тоже библиотека для работы с запросами. 

Для начала установим ее в наш проект:

```bash
npm install react-query
```

Импортируем ее в наш проект:

```js

import { QueryClient, QueryClientProvider, useQuery } from 'react-query'

```

Чтобы работать с запросами, нам нужно создать `QueryClient`:

```js

const queryClient = new QueryClient()

```

И обернуть наше приложение в `QueryClientProvider`:

```js

<QueryClientProvider client={queryClient}>
  <App />

</QueryClientProvider>

```

Суть этой библиотеки в том, что он работает вместе с `fetch` и `axios`. 
Он по факту позволяет проще забирать данные с сервера и обновлять их.




# Вопрос Рустама 

В чем разница между имортированием через фигурные скобки и без них?

```js

import { QueryClient, QueryClientProvider, useQuery } from 'react-query'

```

```js

import QueryClient, QueryClientProvider, useQuery from 'react-query'

```

# Ответ

Когда мы импортируем через фигурные скобки, мы импортируем конкретный элемент из библиотеки.
Когда мы импортируем без фигурных скобок, мы импортируем default элемент из библиотеки.

Разница в export и export default.



