#region Writing

#region Method1

/*
using System.Text;

FileStream fs = new("data.txt", FileMode.OpenOrCreate);

string text = "Hello\nWorld!";

byte[] buffer = Encoding.UTF8.GetBytes(text);

fs.Write(buffer, 0, buffer.Length);
fs.Close();
*/

#endregion

#region Method2

/*
FileStream fs = new("data.txt", FileMode.OpenOrCreate);
StreamWriter sw = new(fs);

sw.WriteLine("Hello");

sw.Close();
fs.Close();
*/

#endregion

#region Method3

// using (FileStream fs = new("data.txt", FileMode.OpenOrCreate))
// {
//     using (StreamWriter sw = new(fs))
//     {
//         sw.WriteLine("Hello");
//     }
// }

#endregion

#region Method4

// using FileStream fs = new("data.txt", FileMode.OpenOrCreate);
// using StreamWriter sw = new(fs);
//
// sw.WriteLine("Hello");


#endregion
#endregion

#region Reading

// Тут все также как и в записи, только используем StreamReader

/*
using FileStream fs = new("data.txt", FileMode.OpenOrCreate);
using StreamReader sr = new(fs);

string text = sr.ReadToEnd();

Console.WriteLine(text);
*/
#endregion

#region Switch

// string text = "Hello\nWorld!";
//
// switch (text)
// {
//     case "A":
//         Console.WriteLine("1");
//         break;
//     case 2:
//         Console.WriteLine("2");
//         break;
//     case 3:
//         Console.WriteLine("3");
//         break;
//     case 4:
//         Console.WriteLine("4");
//         break;
//     case 5:
//         Console.WriteLine("5");
//         break;
// }
//
#endregion

#region InlineSwitch

// string text = "4";

// string result = text switch
// {
     // "1" => "1",
     // "2" => "2",
     // "3" => "3",
     // "4" => "4",
     // "5" => "5",
     // _ => "6"
// };

// Console.WriteLine(result);


#endregion

