using comfybed.tools.etc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using comfybed.tools.etc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace comfybed.view.user
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserJoinFrm : ContentPage
    {

        public UserJoinFrm()
        {
            InitializeComponent();
        }




        private void btnSend_Clicked(object sender, EventArgs e)
        {
            //이메일 정규화 검증
            if (IsValidEmail(txtTo.Text) == false)
            {
                DisplayAlert("실패", "이메일 형식을 확인해주세요", "확인");
            }
            else if (txtPw.Text != txtPwCheck.Text)
            {
                DisplayAlert("실패", "비밀번호가 동일하지 않습니다.", "확인");
                txtPw.TextColor = Color.Red;
            }
            else if (txtPw.Text.Equals("") || txtPwCheck.Text.Equals(""))
            {
                DisplayAlert("실패", "비밀번호를 입력해주세요.", "확인");
                txtPw.TextColor = Color.Red;
            }
            else if (txtTo.Text.Equals(""))
            {
                DisplayAlert("실패", "이메일을 입력해주세요.", "확인");
                txtPw.TextColor = Color.Red;
            }
            else
            {
                try
                {

                    SendMail.Send(txtTo.Text);
                    EmailTime.Text = "이메일이 전송되었습니다.";
                }
                catch (Exception ex)
                {
                    DisplayAlert("실패", ex.Message, " OK");
                }

            }
        }

        private void btnRegister_Clicked(object sender, EventArgs e)
        {

            if (txtPw.Text != txtPwCheck.Text)
            {
                DisplayAlert("실패", "비밀번호를 다시 확인해주세요", "확인");
                txtPw.TextColor = Color.Red;
            }
            else if (btnCheckEmail.IsEnabled == true)
            {
                DisplayAlert("실패", "이메일 인증을 진행해주세요", "확인");
            }
            else if (txtPw.Text.Equals("") || txtPwCheck.Text.Equals(""))
            {
                DisplayAlert("실패", "비밀번호를 입력해주세요.", "확인");
                txtPw.TextColor = Color.Red;
            }
            else if (txtTo.Text.Equals(""))
            {
                DisplayAlert("실패", "이메일을 입력해주세요.", "확인");
                txtTo.TextColor = Color.Red;
            }
            else if (txtTo.Text.Any(X => Char.IsWhiteSpace(X) == true))
            {
                DisplayAlert("실패", "아이디에는 공백이 있으면 안됩니다.", "확인");
                txtTo.TextColor = Color.Red;
            }
            else if (txtPw.Text.Any(X => Char.IsWhiteSpace(X) == true))
            {
                DisplayAlert("실패", "패스워드에는 공백이 있으면 안됩니다.", "확인");
                txtPw.TextColor = Color.Red;
            }
            else
            {
                DisplayAlert("성공", "회원가입완료 3초 후 메인화면으로 이동합니다.", "성공");
                System.Threading.Thread.Sleep(3000);
                Application.Current.MainPage = new MainFrm();
            }
        }


        private void BtnRegister_Clicked(object sender, EventArgs e)  {

            if (txtPw.Text != txtPwCheck.Text) {
                DisplayAlert("실패", "비밀번호를 다시 확인해주세요", "확인");
                txtPw.TextColor = Color.Red;
            } else if (btnCheckEmail.IsEnabled == true) {
                DisplayAlert("실패", "이메일 인증을 진행해주세요", "확인");
            } else if (txtPw.Text.Equals("") || txtPwCheck.Text.Equals("")) {
                DisplayAlert("실패", "비밀번호를 입력해주세요.", "확인");
                txtPw.TextColor = Color.Red;
            } else if (txtTo.Text.Equals("")) {
                DisplayAlert("실패", "이메일을 입력해주세요.", "확인");
                txtTo.TextColor = Color.Red;
            } else if (txtTo.Text.Any(X => Char.IsWhiteSpace(X) == true)){
                DisplayAlert("실패", "아이디에는 공백이 있으면 안됩니다.", "확인");
                txtTo.TextColor = Color.Red;
            } else if (txtPw.Text.Any(X => Char.IsWhiteSpace(X) == true)) {
                DisplayAlert("실패", "패스워드에는 공백이 있으면 안됩니다.", "확인");
                txtPw.TextColor = Color.Red;
            } else {
                DisplayAlert("성공", "회원가입완료 3초 후 메인화면으로 이동합니다.", "성공");
                Application.Current.MainPage = new MainFrm();
            }
        }

        private void Btnpass_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("dd", SendMail.getBase36(), "dd");
        }


        private void btnEmailCheck_Clicked(object sender, EventArgs e)
        {

            if (CheckEmailCode.Text != SendMail.getBase36())
            {
                DisplayAlert("실패", "인증코드가 잘못됬습니다.", "확인");
                CheckEmailCode.TextColor = Color.Red;
            }
            else if (CheckEmailCode.Text.Equals(""))
            {
                DisplayAlert("실패", "인증코드를 입력해주세요.", "확인");
                CheckEmailCode.TextColor = Color.Red;
            }
            else
            {
                DisplayAlert("성공", "이메일 인증이 완료되었습니다..", "성공");
                (sender as Button).IsEnabled = false; //인증완료 인증버튼 비활성화
                btnSend.IsEnabled = false; //인증이 완료될경우 인증 메일 보내기 버튼 비활성화
            }
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
