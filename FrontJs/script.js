/* 
Selectors in JavaScript

Все обращения к элементам страницы в JavaScript начинаются с объекта document.
Этот объект представляет собой модель страницы, которая содержит все элементы страницы.
Находится она внутри объекта window, который представляет собой окно браузера.
Но писать каждый раз window.document довольно длинно, поэтому можно обращаться к объекту document напрямую.

Также, вы должны понимать, что в window хранится не только объект document, но и все ваши переменные, функции и т.д.

Существует несколько способов обращения к элементам страницы:
1. По id
2. По тегу
3. По классу
4. По селектору

По id

Напоминаю, что id должен быть уникальным на странице.
let navbar = document.getElementById('navbar'); 
console.log(navbar);

По тегу

let navbar = document.getElementsByTagName('nav');
console.log(navbar);

По классу

let navbar = document.getElementsByClassName('navbar');
console.log(navbar);

По селектору
Тут все очень просто, мы берем элемент по css селектору.
*/

// let navbar = document.getElementById('navbar');
// console.log(navbar);

// let navbar = document.getElementsByTagName("nav");

// for (let i = 0; i < navbar.length; i++) {
//   console.log(navbar[i]);
// }

// let navbar = document.getElementsByClassName("navbar");
// console.log(navbar);

// let navbar = document.querySelector(".navbar");
// let navbar1 = document.querySelector("#navbar");
// let navbar2 = document.querySelector("nav");

// console.log(navbar);
// console.log(navbar1);
// console.log(navbar2);

// let navbar = document.querySelectorAll(".navbar");
// let navbar1 = document.querySelectorAll("#navbar");
// let navbar2 = document.querySelectorAll("nav");

// console.log(navbar);
// console.log(navbar1);
// console.log(navbar2);

// Events

// let heading = document.querySelector("h1");

// setTimeout(() => {
//   heading.innerHTML = `<span>
//   <i class="fas fa-spinner fa-spin"></i>
//   </span> Loading...`;
// }, 5000);

// let heading = document.querySelector("h1");

// let i = 0;
// setInterval(() => {
//   heading.innerText = i;
//   i++;
// }, 200);

//// Events

// let heading = document.querySelector("h1");

// heading.onclick = () => {
//   console.log("Clicked");
// };

// heading.addEventListener("click", () => {
//   console.log("Clicked");
// });


//// Event loop

let heading = document.querySelector("h1");



