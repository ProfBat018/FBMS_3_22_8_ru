// console.log(`Start of code`);

// let res = fetch("https://jsonplaceholder.typicode.com/posts");

// console.log(`Start of fetch`);

// res
//   .then((response) => {
//     return response.json();
//   })
//   .then((data) => {
//     console.log(data);
//   })
//   .catch((error) => {
//     console.log(error);
//   });

// console.log(`End of code`);

// let res = fetch("https://jsonplaceholder.typicode.com/posts");

// console.log(res);

// res
//   .then((response) => {
//     return response.json();
//   })
//   .then((data) => {
//     console.log(data);
//   })
//   .catch((error) => {
//     console.log(error);
//   })
//   .finally(() => {
//     console.log("Finally");
//   });

function marry(man, woman) {
  woman.husband = man;
  man.wife = woman;

  return {
    father: man,
    mother: woman,
  };
}

let john = { name: "John" };
let ann = { name: "Ann" };

let family = marry(john, ann);

console.log(family);
