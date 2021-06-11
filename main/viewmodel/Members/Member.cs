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
using System.Reflection;

namespace main.controller
{
    public class MemberViewModel : BaseViewModel
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
            get => filterByInfo(getAllAciveMember());
            set
            {
                _memberList = value;
            }
        }
        private ObservableCollection<Converter> _blackList;

        public ObservableCollection<Converter> blackList 
        {
            get => filterByInfo(getAllBlackListMember());
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
        public ICommand RunEditFormCommand => new RelayCommand<object>((p) => { return true; }, (p) => { RunEditForm(); });
        public ICommand RunAddFormCommand => new RelayCommand<object>((p) => { return true; }, (p) => { RunAddForm(); });



        private void RunAddForm()
        {
            AddNewMemberForm add = new AddNewMemberForm();
            add.Show();            
        }
        private void RunEditForm()
        {
            EditForm editForm = new EditForm();
            editForm.Show();
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
                memberList.Add( new Converter().buildWithAccount(member,""));
            }
            return memberList;
        }
        private ObservableCollection<Converter> getAllBlackListMember()
        {
            var memberList = new ObservableCollection<Converter>();
            foreach (var member in data.getAllMembers())
            {
                if (member.status == AccountStatus.BLACKLISTED)
                    memberList.Add(new Converter().buildWithAccount(member, ""));
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
            EditForm.updateMember += updateMember;
        }
        private string searchKeyword = "";
        public string SearchKeyword
        {
            get => searchKeyword;
            set
            {
                searchKeyword = value;
                            
                OnPropertyChanged("memberList");
                OnPropertyChanged("blackList");
            }
        }
       
        

       
        private ObservableCollection<Converter> filterByInfo(ObservableCollection<Converter> listToFindMember)
        {
            

            ObservableCollection<Converter> filterList = new ObservableCollection<Converter>();

            foreach (var member in listToFindMember)
            {

                foreach (PropertyInfo prop in member.GetType().GetProperties())
                {
                    var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                    if (type == typeof(string) || type == typeof(int) || type == typeof(DateTime))
                    {
                        var member_field = prop.GetValue(member, null);
                        if (member_field != null)
                        {
                            String member_data = member_field.ToString().Trim().ToLower();
                            String keyWord = searchKeyword.ToLower();
                            if (member_data != null && keyWord != null)
                            {
                                if (member_data.Contains(keyWord))
                                {                                    
                                    filterList.Add(member);
                                    break;
                                }
                            }
                        }
                    }

                }
            }
            return filterList;
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
