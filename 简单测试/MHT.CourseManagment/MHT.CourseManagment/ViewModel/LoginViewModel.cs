using MHT.CourseManagment.Commom;
using MHT.CourseManagment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MHT.CourseManagment.ViewModel
{
    public class LoginViewModel:NotifyBase
    {
        public CommandBase CloseWindowCommand { get; set; }
        public LoginModel LoginModel { get; set; }

        public CommandBase LoginCommand { get; set; }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                this.NotifyPropertyChanged();
            }
        }


        public LoginViewModel()
        {
            this.LoginModel = new LoginModel();
            this.LoginModel.UserName = "Jovan";
            this.LoginModel.Password = "123123";

            this.CloseWindowCommand = new CommandBase();
            this.CloseWindowCommand.DoExcute += CloseWindow;
            this.CloseWindowCommand.DoCanExcute += new Func<object, bool>((o) =>
            {
                return true;
            });

            this.LoginCommand = new CommandBase();
            this.LoginCommand.DoExcute = new Action<object>(DoLogin);
            this.LoginCommand.DoCanExcute = new Func<object, bool>((o) =>
            {
                return true;

            });
        }
        /// <summary>
        /// 关闭窗体事件响应器
        /// </summary>
        /// <param name="o"></param>
        private void CloseWindow(object o)
        {
            (o as Window).Close();
        }

        private void DoLogin(object o)
        {
            this.ErrorMessage = "";

            if (string.IsNullOrEmpty(LoginModel.UserName))
            {
                this.ErrorMessage = "请输入用户名！";
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.Password))
            {
                this.ErrorMessage = "请输入密码！";
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.ValidationCode))
            {
                this.ErrorMessage = "请输入验证码！";
                return;
            }
            if (LoginModel.ValidationCode.ToLower() != "7364")
            {
                this.ErrorMessage = "验证码输入不正确！";
                return;
            }

        }
    }
}
