import React from "react";

export default function withoutMemo(props) {
  const processedItems = processItems(props.data);

  return (
    <ul>
      {processedItems.map((item) => (
        <li key={item.id}>
          {item.make} {item.model}
        </li>
      ))}
    </ul>
  );
}

const processItems = (items) => {
  return items.map((car) => ({
    id: Math.random((Math.random() + 1).toString(36).substring(7)),
    make: car.make.toUpperCase(),
    model: car.model.toUpperCase(),
    price: car.price,
  }));
};
