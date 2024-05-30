# Структура проекта на React. Компоненты

## Структура проекта на React

Весь проект состоит из несколькизх папок и файлов, давайте их разберем на примере проекта `components`

- components
  - node_modules
  - public
  - src
    - components
      - Header
        - Header.js
        - Header.css
      - Main
        - Main.js
        - Main.css
      - Footer
        - Footer.js
        - Footer.css
    - App.js
    - App.css
    - index.js
  - .gitignore
  - package-lock.json
  - package.json
  - README.md

В папке `node_modules` хранятся все зависимости проекта, которые устанавливаются с помощью команды `npm install`.

В папке `public` хранятся все статические файлы проекта, такие как изображения, шрифты, favicon и т.д.

В папке `src` хранятся все файлы проекта, которые мы пишем сами.

В папке `components` хранятся все компоненты проекта. Каждый компонент находится в своей папке, в которой хранятся файлы компонента.

В файле `App.js` находится главный компонент проекта, который включает в себя все остальные компоненты.

В файле `index.js` находится точка входа в проект, в которой происходит рендеринг главного компонента.

Разница между `package-lock.json` и `package.json` заключается в том, что первый хранит информацию метаданных, а второй о манифесте проекта.

## Компоненты

Компоненты - это основные строительные блоки React приложения. Они позволяют разбить интерфейс на независимые части, которые можно повторно использовать в разных местах приложения.

Компоненты могут быть функциональными и классовыми. Функциональные компоненты - это просто функции, которые принимают `props` и возвращают React элемент. Классовые компоненты - это классы, которые наследуются от `React.Component` и имеют метод `render`, который возвращает React элемент.

Сразу говорю вам что классовые компоненты устарели и их использование не рекомендуется(IMHO). Все новые компоненты лучше писать как функциональные.

И сразу же скажу вам разницу между ними. В `react` есть такие вещи как `hooks`, которые позволяют вам управлять состоянием и жизненным циклом компонента. В классовых компонентах это делается с помощью методов жизненного цикла, а в функциональных компонентах с помощью `hooks`. Соответсвенно, `hooks` использовать в классовых компонентах невозможно.
Конечно же альтернатива это использовать специальные методы для этого, но код будет очень громоздким и нечитаемым.

## Пример функционального компонента

```jsx
import React from "react";

function Header() {
  return (
    <header>
      <h1>Header</h1>
    </header>
  );
}

export default Header;
```

## Пример классового компонента

```jsx
import React, { Component } from "react";

class Header extends Component {
  render() {
    return (
      <header>
        <h1>Header</h1>
      </header>
    );
  }
}

export default Header;
```

## Расширения файлов для компонентов

Для компонентов обычно используют следующие расширения файлов:

- `.js` - для JavaScript кода компонента
- `.css` - для стилей компонента
- `.test.js` - для тестов компонента
- `.jsx` - для JavaScript кода компонента с JSX

Теперь запомнмте, вы можете создать компонент как с `.js` так и с `.jsx` расширением,

## Обработки событий. Нажатие

Для обработки событий в React используется синтаксис JSX. Для обработки события нажатия на кнопку используется атрибут `onClick`, в который передается функция-обработчик события.

```jsx
import React from "react";

function Button() {
  function handleClick() {
    alert("Button clicked");
  }

  return <button onClick={handleClick}>Click me</button>;
}
```

Если вы хотите изменить страницу при нажатии на кнопку, то вам нужно использовать хуки. Например, `useState` для изменения состояния компонента.

```jsx
import React, { useState } from "react";

function Button() {
  const [count, setCount] = useState(0);

  function handleClick() {
    setCount(count + 1);
  }

  return (
    <div>
      <p>Count: {count}</p>
      <button onClick={handleClick}>Click me</button>
    </div>
  );
}
```

# Навигация

В `react` есть два варианта как можно менять страницы. Это `react-router-dom` и использование `state`.

## React Router Dom

Это мы пройдем в будущем, он очень простой. Для преждевременного ознакомления можете перейти по ссылке [СЮДА](https://github.com/ProfBat018/FBMS_1221_RU/tree/Devops/Microservices/frontend)

## Использование state

Для навигации между страницами можно использовать `state`. Для этого нужно создать переменную, которая будет хранить текущую страницу, и функцию, которая будет изменять эту переменную.

```jsx
import React, { useState } from "react";

function App() {
  const [page, setPage] = useState("home");

  function goToHome() {
    setPage("home");
  }

  function goToAbout() {
    setPage("about");
  }

  return (
    <div>
      <nav>
        <button onClick={goToHome}>Home</button>
        <button onClick={goToAbout}>About</button>
      </nav>
      {page === "home" && <Home />}
      {page === "about" && <About />}
    </div>
  );
}

function Home() {
  return <h1>Home</h1>;
}

function About() {
  return <h1>About</h1>;
}
```

Но в нашем случае `button` находится в отдельном компоненте, поэтому нам нужно передать функцию `goToHome` и `goToAbout` через `props`.

```jsx
import React, { useState } from "react";

function App() {
const [page, setPage] = useState("home");

function goToHome() {
  setPage("home");
}

function goToAbout() {
  setPage("about");
}

  return (
    <div>
      <Nav goToHome={goToHome} goToAbout={goToAbout} />
      {page === "home" && <Home />}
      {page === "about" && <About />}
    </div>
  );
}

function Nav({ goToHome, goToAbout }) {
  return (
    <nav>
      <button onClick={goToHome}>Home</button>
      <button onClick={goToAbout}>About</button>
    </nav>
  );
}

function Home() {
  return <h1>Home</h1>;
}

function About() {
  return <h1>About</h1>;
}
```

а сама кнопка будет выглядеть так:

```jsx
function Nav({ goToHome, goToAbout }) {
  return (
    <nav>
      <button onClick={goToHome}>Home</button>
      <button onClick={goToAbout}>About</button>
    </nav>
  );
}
```
