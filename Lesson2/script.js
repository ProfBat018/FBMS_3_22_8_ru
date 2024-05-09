//#region Explicit type casting cs implicit type casting in JS

//// Explicit type casting
// let x = 10;
// let y = 20;
// let z = x + y;
// console.log(z); // 30

// let castedZ = String(z);
// console.log(`${castedZ} ${typeof castedZ}`);

//// Implicit type casting

// let x = '10';
// let y = 20;
// let z = x + y;

// console.log(z); // 1020

//#endregion

//#region Arrays

// let arr = [1, 2, 3, 4, 5];

// arr.forEach((x) => console.log(x));

// console.log(arr[0]); // 1

//// map
// let arr = [1, 2, 3, 4, 5];

// let newArr = arr.map((x) => x * 2);

// console.log(newArr);

//// reduce

// let arr = [1, 2, 3, 4, 5];

// let sum = arr.reduce((res, x) => res + x, 0);
// console.log(sum);

//// filter

// let arr = [1, 2, 3, 4, 5];

// let newArr = arr.filter((x) => x % 2 === 0);

// console.log(newArr);

//#endregion

//#region Typed Arrays

// let arr = new Array(10);

// console.log(arr);

// let arr2 = new Array(10).fill(0);

// console.log(arr2);

// Int32Array arr3 = new Int32Array(10);

//#endregion

//#region Keyed Collections

// let map = new Map();

// map.set("name", "John");
// map.set("age", 25);

// console.log(map.get("name"));

// Map - по сути это обычный Dictionary в C#

// WeakMap - это Map, но ключи в нем могут быть только объектами

// let weakMap = new WeakMap();

// let obj = {
//   name: "John",
//   age: 25,
// };

// weakMap.set(obj, { salary: 1000, position: "Developer" });

// console.log(weakMap.get(obj));

//// Set

// let nums = [1, 2, 3, 4, 5, 5, 5, 5];
// let set1 = new Set(nums);
// let set2 = new Set([5, 34, 34, 23, 54, 7, 46, 1]);

// var res1 = set1.difference(set2);

// console.log(res1);

// Weak Set

// let weakSet = new WeakSet();

// let obj = {
//   name: "John",
//   age: 25,
// };

// let obj2 = {
//   name: "John",
//   age: 25,
// };

// weakSet.add(obj);
// weakSet.add(obj2);

// console.log(weakSet.has(obj));

//#endregion




