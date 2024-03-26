#region ListDirectory
// using System.Net;
//
// var request = (FtpWebRequest)WebRequest.Create("ftp://test.rebex.net");
//
// request.Credentials = new NetworkCredential("demo", "password");
//
// request.Method = WebRequestMethods.Ftp.ListDirectory;
//
// var response = request.GetResponse().GetResponseStream();
//
// using StreamReader sr = new(response);
//
// Console.WriteLine(sr.ReadToEnd());


#endregion


#region DownloadFile
//
// using System.Net;
//
// var request = (FtpWebRequest)WebRequest.Create("ftp://test.rebex.net/readme.txt");
//
// request.Credentials = new NetworkCredential("demo", "password");
//
// request.Method = WebRequestMethods.Ftp.DownloadFile;
//
// var response = request.GetResponse().GetResponseStream();
//
// using Stream streamToWriteTo = File.Open("readme.txt", FileMode.Create);
//
// response.CopyTo(streamToWriteTo);

#endregion

#region UploadFile

using System.Net;

var request = (FtpWebRequest)WebRequest.Create("ftp://test.rebex.net/readme2.md");

request.Credentials = new NetworkCredential("demo", "password");

request.Method = WebRequestMethods.Ftp.UploadFile;

var response = request.GetResponse().GetResponseStream();

using var fs = new FileStream("/Users/wayne/Documents/Work/FBMS_3_22_8_RU/FtpLesson/FtpLesson/readme.md", FileMode.Open);

fs.CopyTo(response);

//
// byte[] buffer = new byte[fs.Length];
// fs.Read(buffer, 0, buffer.Length);
//
// response.Write(buffer, 0, buffer.Length);

#endregion

