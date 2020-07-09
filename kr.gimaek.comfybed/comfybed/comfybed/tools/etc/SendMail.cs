using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Reflection;
using System.Text;

namespace comfybed.tools.etc
{
    class SendMail
    {
        private static string time = DateTime.Now.ToString("yyyyMMddHHmmss");
        private static String timea = time;
        private static long ConvertLong = long.Parse(timea);
        private static string ToBase36 = Encode(ConvertLong);

        /*이메일 전송 함수*/
        public static string Send(string input)
        {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.naver.com");
                mail.From = new MailAddress("sqlstyle@naver.com");
                mail.To.Add(input);
                mail.Subject = "인증 확인 이메일입니다";
                mail.Body = "인증코드는" + ToBase36 + "입니다.";
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.naver.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("sqlstyle", "cch1109626!@");
                SmtpServer.Send(mail);
            return input;
        }


        /*
         * 이메일 인증번호 Base36 바꿔주는 함수
         * string 현재시간 -> long -> Base36
         */

        private const string CharList = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static String Encode(long input)
        {
            if (input < 0) throw new ArgumentOutOfRangeException("input", input, "input cannot be negative");
            char[] clistarr = CharList.ToCharArray();
            Array.Sort(clistarr);
            var result = new Stack<char>();
            while (input != 0)
            {
                result.Push(clistarr[input % 36]);
                input /= 36;
            }
            return new string(result.ToArray());
        }

        /*
         * getBase36
         */
        public static string getBase36()
        {
            return ToBase36;
        }


    }
}
