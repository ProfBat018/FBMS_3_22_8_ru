# Тема урока

- Обработка асихронных ошибок
- Использование отладчика
- Работа с файлами
- - \_\_dirname
- - \_\_filename
- - process.cwd()
- - path module
- - fs module
- - glob
- - fs-extra
- - globby
- - chokidar

# Обработка асихронных ошибок

Есть три вида обработки асинхронных ошибок:

- Rejection
- Try/Catch
- Propagation

`Rejection` - это когда мы передаем в Promise два колбека, первый для успешного выполнения, второй для ошибки. Если во время выполнения произошла ошибка, то вызывается второй колбек.

```javascript
const divideByTwoPromise = async (num) => {
  return new Promise((resolve, reject) => {
    if (num === 0) {
      reject(new Error("Cannot divide by zero"));
    }
    resolve(num / 2);
  });
};

divideByTwoPromise(0)
  .then((result) => {
    console.log(result);
  })
  .catch((error) => {
    console.error(error.message);
  });
```

`Try/Catch` - это когда мы оборачиваем асинхронный код в блок `try/catch`. Если во время выполнения произошла ошибка, то она попадает в блок `catch`.

```javascript
const divideByTwoPromise = async (num) => {
  return new Promise((resolve, reject) => {
    if (num === 0) {
      reject(new Error("Cannot divide by zero"));
    }
    resolve(num / 2);
  });
};

const foo = async () => {
  try {
    const result = await divideByTwoPromise(0);
    console.log(result);
  } catch (error) {
    console.error(error.message);
  }
};
```

`Propagation` - это когда мы прокидываем ошибку дальше, чтобы ее обработали в другом месте.

```javascript
async function divideByTwo(amount) {
  if (typeof amount !== "number")
    throw new TypeError("amount must be a number");
  if (amount <= 0) throw new RangeError("amount must be greater than zero");
  if (amount % 2) throw new OddError("amount");
  return amount / 2;
}

try {
  const result = await divideByTwo(3);
  console.log(result);
} catch (error) {
  if (error instanceof TypeError) {
    console.error("TypeError:", error.message);
  } else if (error instanceof RangeError) {
    console.error("RangeError:", error.message);
  } else {
    throw error;
  }
}
```

# Использование отладчика

Для того чтобы использовать отладчик в Node.js, нужно запустить скрипт с флагом `--inspect`.

```bash

node --inspect index.js
```

А лучше просто использовать `VS Code`, так как в нем есть встроенный отладчик.

# Работа с файлами

### \_\_dirname

```javascript
console.log(__dirname);
```

### \_\_filename

```javascript
console.log(__filename);
```

### process.cwd()

```javascript
console.log(process.cwd());
```

Разница между ними в том, что `__dirname` всегда возвращает абсолютный путь к файлу где index.js, а `process.cwd()` возвращает абсолютный путь к рабочей директории.

### path module

```javascript
const path = require("path");

console.log(path.join(__dirname, "index.js"));

console.log(path.resolve(__dirname, "index.js"));

console.log(path.extname(__filename));
```

```bash
path.join('/a', '/b') // Outputs '/a/b'

path.resolve('/a', '/b') // Outputs '/b'
```

### fs module

```javascript

const fs = require("fs");

fs.readFile(__filename, "utf8", (error, data) => {
  if (error) {
    console.error(error.message);
    return;
  }
  console.log(data);
});

fs.writeFile(`${__dirname}/message.txt`, "Hello Node.js", (error) => {
  if (error) {
    console.error(error.message);
    return;
  }
  console.log("The file has been saved!");
});

