using Adapter.Services;

var xml = DataDownloaderService.DownloadData();

var json = XmlToJsonAdapter.ConvertXmlToJson(xml);

using FileStream fs = new("data.json", FileMode.OpenOrCreate);
using StreamWriter sw = new(fs);

sw.Write(json);
