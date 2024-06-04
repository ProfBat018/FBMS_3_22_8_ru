# Rendering в `react`

- Component lifecycle
- Lists and keys
- Render props
- Refs
- Events
- High order components

`Rendering` - это процесс отображения компонентов на странице. В `react` это происходит с помощью метода `render()`, если компонент является классом, или с помощью функции возращающей `jsx`, если компонент является функцией.

### Component lifecycle

`Component lifecycle` - это последовательность событий, которые происходят с компонентом во время его жизни. В `react` есть три группы методов жизненного цикла:

- `Mounting` - методы, которые вызываются при создании компонента и его добавлении в `DOM`.
- `Updating` - методы, которые вызываются при обновлении компонента.
- `Unmounting` - методы, которые вызываются при удалении компонента из `DOM`.

### Lists and keys

`Lists` - это массивы, которые используются для отображения однотипных элементов. В `react` для отображения списков используется метод `map()`. Каждый элемент списка должен иметь уникальный `key`, чтобы `react` мог отслеживать изменения в списке.

```jsx
export const people = [
  {
    id: 0,
    name: "Creola Katherine Johnson",
    profession: "mathematician",
    accomplishment: "spaceflight calculations",
    imageId: "MK3eW3A",
  },
  {
    id: 1,
    name: "Mario José Molina-Pasquel Henríquez",
    profession: "chemist",
    accomplishment: "discovery of Arctic ozone hole",
    imageId: "mynHUSa",
  },
  {
    id: 2,
    name: "Mohammad Abdus Salam",
    profession: "physicist",
    accomplishment: "electromagnetism theory",
    imageId: "bE7W1ji",
  },
  {
    id: 3,
    name: "Percy Lavon Julian",
    profession: "chemist",
    accomplishment:
      "pioneering cortisone drugs, steroids and birth control pills",
    imageId: "IOjWm71",
  },
  {
    id: 4,
    name: "Subrahmanyan Chandrasekhar",
    profession: "astrophysicist",
    accomplishment: "white dwarf star mass calculations",
    imageId: "lrWQx8l",
  },
];
```

```jsx
import { people } from "./data.js";

export default function List() {
  const listItems = people.map((person) => (
    <li key={person.id}>
      <img src={getImageUrl(person)} alt={person.name} />
      <p>
        <b>{person.name}</b>
        {" " + person.profession + " "}
        known for {person.accomplishment}
      </p>
    </li>
  ));
  return <ul>{listItems}</ul>;
}
```

### Render props

`render props` - это свойства компонента, которые мы возвращаем.

```jsx
function Avatar() {
  return (
    <img
      className="avatar"
      src="https://i.imgur.com/1bX5QH6.jpg"
      alt="Lin Lanying"
      width={100}
      height={100}
    />
  );
}

export default function Profile() {
  return <Avatar />;
}
```

То что вы видите сверху это свойства по умолчанию, которые возращаются при 
отрисовке компонента `Avatar`. Но что если мы хотим изменить `src`, `alt`, `width` и `height` ? В таком случае нам надо передать эти `props` в `Avatar` из `Profile`.

```jsx

function Avatar(props) {
  return (
    <img
      className="avatar"
      src={props.src}
      alt={props.alt}
      width={props.width}
      height={props.height}
    />
  );
}

export default function Profile() {
  return (
    <Avatar
      src="https://i.imgur.com/1bX5QH6.jpg"
      alt="Lin Lanying"
      width={100}
      height={100}
    />
  );
}
```


