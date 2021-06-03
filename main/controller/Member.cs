using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using main.layout.member.component;
using main.model;
using main.model.enums;
using MaterialDesignThemes.Wpf;
using main.layout;
using System.Windows;

namespace main.controller
{
    public class MemberViewModel : ViewModelBase
    {
        public Converter converter { get; set; }
        public ObservableCollection<Converter> memberList { get; set; }
        public ObservableCollection<Converter> blackList { get; set; }
        public Account SelectedAccount { get; set; }

        public ICommand RunDeleteNotificationCommand => new AnotherCommandImplementation(RunDeleteNotification);
        public ICommand RunBlockNotificationCommand => new AnotherCommandImplementation(RunBlockNotification);
        public ICommand RunUnBlockNotificationCommand => new AnotherCommandImplementation(RunUnBlockNotification);
        public ICommand RunEditFormCommand => new AnotherCommandImplementation(RunEditForm);
        public ICommand RunAddFormCommand => new AnotherCommandImplementation(RunAddForm);

        public ICommand SwichToBlackListCommand => new AnotherCommandImplementation(SwitchToBlackList);
        public ICommand SwichToActiveListCommand => new AnotherCommandImplementation(SwitchToActiveList);

        private async void RunAddForm(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new AddMember
            {
                DataContext = this
            };

            //show the dialog
            var result = await DialogHost.Show(view, "MemberDialog", ExtendedOpenedEventHandler, ExtendedClosingEventHandler);

            //check the result...
            Debug.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }
        private async void RunEditForm(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new Member_info
            {
                DataContext = this
            };

            //show the dialog
            var result = await DialogHost.Show(view, "MemberDialog", EditFormExtendedOpenedEventHandler, ExtendedClosingEventHandler);

            //check the result...
            Debug.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }
        private async void RunDeleteNotification(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new Notification_delete
            {
                DataContext = this
            };

            //show the dialog
            var result = await DialogHost.Show(view, "MemberDialog", ExtendedOpenedEventHandler, ExtendedClosingEventHandler);
            Console.WriteLine(SelectedAccount.info.name);

            //check the result...
            Debug.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }
        private async void RunUnBlockNotification(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new Notification_unblock
            {
                DataContext = this
            };

            //show the dialog
            var result = await DialogHost.Show(view, "MemberDialog", ExtendedOpenedEventHandler, ExtendedClosingEventHandler);

            //check the result...
            Debug.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }
        private async void RunBlockNotification(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new Notification_block
            {
                DataContext = this
            };

            //show the dialog
            var result = await DialogHost.Show(view, "MemberDialog", ExtendedOpenedEventHandler, ExtendedClosingEventHandler);

            //check the result...
            Debug.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void EditFormExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
        {
            // làm gì đó để lấy được data từ selected item rồi ném vào đây cho nó xử lí
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

        private void SwitchToBlackList(object o)
        {
            Uri uri = new Uri("/layout/member/component/MemberBlackListWraper.xaml", UriKind.Relative);
            Member.navigationFrame.Navigate(uri);
        }

        private void SwitchToActiveList(object o)
        {
            Uri uri = new Uri("/layout/member/component/MemberActiveWraper.xaml", UriKind.Relative);
            Member.navigationFrame.Navigate(uri);
        }

        private static MemberViewModel instance;
        // lock object for multi thread-safe
        private static object syncLock = new object();
        public static MemberViewModel getInstance()
        {
            if (instance == null)
                lock (syncLock)
                    if (instance == null)
                        instance = new MemberViewModel();
            return instance;
        }
        public void deleteMember()
        {
            memberList.RemoveAt(1);
        }

        public MemberViewModel()
        {
            converter = new Converter();

            memberList = new ObservableCollection<Converter>()
            {
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),

                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                 this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),

                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),

                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),

                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),

                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                  this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),

                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                 this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),

                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),

                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),

                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),
                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),

                this.converter.build("hi", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.ACTIVE, 5, "../resource/img/avt_default.png"),


            };

            blackList = new ObservableCollection<Converter> {
                this.converter.build("Blac listed", "khanh hoa", " example@gmail.com", "08969256174", AccountStatus.BLACKLISTED, 5, "../resource/img/avt_default.png"),
            };

        }
    }
}
