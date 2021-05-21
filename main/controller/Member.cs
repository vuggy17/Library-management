using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using main.layout.member.component;
using main.model;
using main.model.enums;
using MaterialDesignThemes.Wpf;

namespace main.controller
{
    public class MemberViewModel : ViewModelBase
    {
        public Converter converter { get; set; }
        public ObservableCollection<Converter> memberList { get; set; }
        public ICommand RunBlockNotificationCommand => new AnotherCommandImplementation(RunBlockNotification);

        private async void RunBlockNotification(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new Notification_unblock
            {
                DataContext = this
            };

            //show the dialog
            var result = await DialogHost.Show(view, "BlockDialog", ExtendedOpenedEventHandler, ExtendedClosingEventHandler);

            //check the result...
            Debug.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
            => Debug.WriteLine("You could intercept the open and affect the dialog using eventArgs.Session.");

        private void ExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) return;

            //OK, lets cancel the close...
            eventArgs.Cancel();

            //...now, lets update the "session" with some new content!
            eventArgs.Session.UpdateContent(new Progresbar());
            //note, you can also grab the session when the dialog opens via the DialogOpenedEventHandler

            //lets run a fake operation for 1 seconds then close this baby.
            Task.Delay(TimeSpan.FromSeconds(1))
                .ContinueWith((t, _) => eventArgs.Session.Close(false), null,
                    TaskScheduler.FromCurrentSynchronizationContext());
        }
        public MemberViewModel()
        {
            converter = new Converter();

            memberList = new ObservableCollection<Converter>()
            {
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
            };

        }
    }
}
