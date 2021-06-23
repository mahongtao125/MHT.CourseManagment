using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MHT.CourseManagment.Commom
{
    public class NotifyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propNmae = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propNmae));
        }

        public NotifyBase()
        {

        }
    }
}
