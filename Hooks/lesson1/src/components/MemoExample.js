import React, { useMemo } from "react";

export default function MemoExample(props) {    
  const processedItems = useMemo(() => processItems(props.data), [props.data]);

  return (
      <ul>
        {processedItems.map((item) => (
          <li key={item.id}>{item.name}</li>
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
