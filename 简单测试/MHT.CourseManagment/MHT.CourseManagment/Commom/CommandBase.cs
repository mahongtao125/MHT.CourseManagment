using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MHT.CourseManagment.Commom
{
    public class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return DoCanExcute?.Invoke(parameter) == true;  //返回值类型是可空bool类型，
        }

        public void Execute(object parameter)
        {
            DoExcute?.Invoke(parameter);
        }

        public Action<object> DoExcute { get; set; }

        public Func<object,bool> DoCanExcute { get; set; }
    }
}
