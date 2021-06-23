using MHT.CourseManagment.Commom;


namespace MHT.CourseManagment.Model
{
    public class LoginModel: NotifyBase
    {
        private string _userName;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                this.NotifyPropertyChanged();
            }
        }

        private string _password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                this.NotifyPropertyChanged();
            }
        }

        private string _validationCode;
        /// <summary>
        /// 验证码
        /// </summary>
        public string ValidationCode
        {
            get { return _validationCode; }
            set
            {
                _validationCode = value;
                this.NotifyPropertyChanged();
            }
        }



     


    }
}
