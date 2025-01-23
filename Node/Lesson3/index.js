// const divideByTwoPromise = async (num) => {
//   return new Promise((resolve, reject) => {
//     if (num === 0) {
//       reject(new Error("Cannot divide by zero"));
//     }
//     resolve(num / 2);
//   });
// };

// divideByTwoPromise(0)
//   .then((result) => {
//     console.log(result);
//   })
//   .catch((error) => {
//     console.error(error.message);
//   });

// ----------------------------

// const divideByTwoPromise = async (num) => {
//   return new Promise((resolve, reject) => {
//     if (num === 0) {
//       reject(new Error("Cannot divide by zero"));
//     }
//     resolve(num / 2);
//   });
// };

// const foo = async () => {
//   try {
//     const result = await divideByTwoPromise(0);
//     console.log(result);
//   } catch (error) {
//     console.error(error.message);
//   }
// };

// foo();


// ----------------------------

// console.log(`${__dirname}/images/batman.png`);
// console.log(__filename);

// ----------------------------

// console.log(process.cwd());

// ----------------------------

// const path = require("path");

// console.log(path.join(__dirname, "index.js"));

// console.log(path.resolve(__dirname, "index.js"));

// console.log(path.extname(__filename));


// ----------------------------


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
