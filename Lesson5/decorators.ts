// sealed decorator

// function sealed(target: any) {
//   Object.seal(target);
//   Object.seal(target.prototype);
// }

// @sealed
// class SealedClass {
//   name: string;
//   surname: string | undefined;

//   constructor(name: string) {
//     this.name = name;
//     console.log("SealedClass constructor");
//   }
// }

// let sealedClass = new SealedClass(`test sealed class`);

// SealedClass.prototype.surname = `test surname`;



function logDataFromMethod(target: any, key: string, descriptor: any) {
  console.log(`target: ${target.constructor.name}`);
  console.log(`key: ${key}`);
  console.log(`descriptor: ${descriptor}`);

  descriptor.value = function (...args: any[]) {
  console.log(`Arguments: ${args}`);
  };
  
}


class LogDataClass {
  @logDataFromMethod
  logData(name: string) {
    console.log(`logData`);
  }
}

class Elnur {
    @logDataFromMethod
    logData(name: string) {
      console.log(`logData`);
    }
}

// let logDataClass = new LogDataClass();
// logDataClass.logData("Elnur");


// let elnur = new Elnur();
// elnur.logData("Elnur");