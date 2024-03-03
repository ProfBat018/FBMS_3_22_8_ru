using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurService.Models
{

    public class ImageUploadResponse
    {
        public int status { get; set; }
        public bool success { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
        public string deletehash { get; set; }
        public object account_id { get; set; }
        public object account_url { get; set; }
        public object ad_type { get; set; }
        public object ad_url { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int size { get; set; }
        public int views { get; set; }
        public object section { get; set; }
        public object vote { get; set; }
        public int bandwidth { get; set; }
        public bool animated { get; set; }
        public bool favorite { get; set; }
        public bool in_gallery { get; set; }
        public bool in_most_viral { get; set; }
        public bool has_sound { get; set; }
        public bool is_ad { get; set; }
        public object nsfw { get; set; }
        public string link { get; set; }
        public object[] tags { get; set; }
        public int datetime { get; set; }
        public string mp4 { get; set; }
        public string hls { get; set; }
    }
}
