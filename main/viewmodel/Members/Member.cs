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
using main.viewmodel.Members;
using main.layout.member.forms;

namespace main.controller
{
    public class MemberViewModel : ViewModelBase
    {
        DataLoadFromDB data = DataLoadFromDB.getIntance();
        private void updateMember()
        {
            OnPropertyChanged("memberList");
            OnPropertyChanged("blackList");
            OnPropertyChanged("TotalBlackListMember");
            OnPropertyChanged("TotalMember");
            OnPropertyChanged("TotalActiveMember");


        }
        public int TotalBlackListMember
        {
            get => blackList.Count;
        }
        public int TotalMember
        {
            get => data.getAllMembers().Count;
        }
        public int TotalActiveMember
        {
            get => memberList.Count;
        }


        private ObservableCollection<Converter> _memberList;
        public ObservableCollection<Converter> memberList 
        {
            get => getAllAciveMember();
            set
            {
                _memberList = value;
            }
        }
        private ObservableCollection<Converter> _blackList;

        public ObservableCollection<Converter> blackList 
        {
            get => getAllBlackListMember();
            set
            {
                _blackList = value;
            }
        }
        public int SelectedAccountID { get; set; }

        private Converter selectedItem;
        public Converter SelectedItem 
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                if (selectedItem != null)
                {
                    SelectedAccountID = selectedItem.id;
                }          

            }
        }
        

        public ICommand RunDeleteNotificationCommand => new RelayCommand<object>((p) => { return true; }, (p) => { RunDeleteNotification(); });
        public ICommand RunBlockNotificationCommand => new RelayCommand<object>((p) => { return true; }, (p) => { RunBlockNotification(); });
        public ICommand RunUnBlockNotificationCommand => new RelayCommand<object>((p) => { return true; }, (p) => { RunUnBlockNotification(); });
        public ICommand RunEditFormCommand => new AnotherCommandImplementation(RunEditForm);
        public ICommand RunAddFormCommand => new RelayCommand<object>((p) => { return true; }, (p) => { RunAddForm(); });



        private void RunAddForm()
        {
            AddNewMemberForm add = new AddNewMemberForm();
            add.Show();            
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
        private void RunDeleteNotification()
        {
            DeleteConfirn deleteConfirn = new DeleteConfirn();
            deleteConfirn.Show();
        }
        private void RunUnBlockNotification()
        {
            UnBlockConfirm unBlockConfirm = new UnBlockConfirm();
            unBlockConfirm.Show();
        }
        private void RunBlockNotification()
        {
            BlockConfirm blockConfirm = new BlockConfirm();
            blockConfirm.Show();
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



        private static MemberViewModel instance;
        
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

        private ObservableCollection<Converter> getAllAciveMember()
        {
            var memberList = new ObservableCollection<Converter>();
            foreach (var member in data.getAllMembers())
            {
                if( member.status == AccountStatus.ACTIVE)
                memberList.Add( new Converter().build(member.id,member.info.name, member.info.address,member.info.email,member.info.phone,member.status,member.totalBookLoan,""));
            }
            return memberList;
        }
        private ObservableCollection<Converter> getAllBlackListMember()
        {
            var memberList = new ObservableCollection<Converter>();
            foreach (var member in data.getAllMembers())
            {
                if (member.status == AccountStatus.BLACKLISTED)
                    memberList.Add(new Converter().build(member.id,member.info.name, member.info.address, member.info.email, member.info.phone, member.status, member.totalBookLoan, ""));
            }
            return memberList;
        }

        public MemberViewModel()
        {            
            MemberNavigationViewModel.ChangePage += MemberNavigationViewModel_ChangePage;
            AddNewMemberForm.updateMember += updateMember;
            BlockConfirm.updateMember += updateMember;
            UnBlockConfirm.updateMember += updateMember;
            DeleteConfirn.updateMember += updateMember;
        }



        private void MemberNavigationViewModel_ChangePage(string page)
        {
            switch (page)
            {
                case "ActiveList":
                    SwitchToActiveList();
                    break;
                case "BlackList":
                    SwitchToBlackList();
                    break;
            }
        }
        private void SwitchToBlackList()
        {
            Uri uri = new Uri("/layout/member/component/MemberBlackListWraper.xaml", UriKind.Relative);
            Member.navigationFrame.Navigate(uri);
        }

        private void SwitchToActiveList()
        {
            Uri uri = new Uri("/layout/member/component/MemberActiveWraper.xaml", UriKind.Relative);
            Member.navigationFrame.Navigate(uri);
        }
    }
}
