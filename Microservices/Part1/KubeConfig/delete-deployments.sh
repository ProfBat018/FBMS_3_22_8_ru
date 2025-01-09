#!/bin/bash

# Путь к папке с файлами деплойментов
DEPLOYMENT_DIR="./deployments"

# Проверяем, существует ли папка
if [ ! -d "$DEPLOYMENT_DIR" ]; then
  echo "Папка $DEPLOYMENT_DIR не найдена!"
  exit 1
fi

# Удаляем все объекты в папке
for file in "$DEPLOYMENT_DIR"/*; do
  if [ -f "$file" ]; then
    echo "Удаление объекта из файла: $file"
    kubectl delete -f "$file"
  else
    echo "Пропущен: $file (не файл)"
  fi
done

echo "Все объекты удалены."
