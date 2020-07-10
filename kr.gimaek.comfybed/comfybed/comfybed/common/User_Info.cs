using System;
using System.Collections.Generic;
using System.Text;

namespace comfybed.common
{
    public class User_Info
    {
      public string Email_Add{get; set;}
      public string User_Pass {get; set;}
      public string User_Name {get; set;}
      public string Address {get; set;}
      public string Push_Agree {get; set;}
      public string Pay_Way {get; set;}

        public string Image_Url
        {
            get
            {
                string url = "https://slimeplanet.cafe24.com/comfybed/image/";

                if (User_Name.Equals("변강욱"))
                {
                    return url + "richwell.jpg";
                }
                else if (User_Name.Equals("최성우 숙박") || User_Name.Equals("최성")) 
                {
                    return url+"artist.png";
                }
                return null;
            }
        }
    }
}
