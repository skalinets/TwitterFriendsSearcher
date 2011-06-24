using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TwitterFriendsSearcher;
using TwitterFriendsSearcher.Twitter;

namespace WpfClient
{
    public class MainWindowViewModel
    {
        private readonly ITwitterFriendsService twitterFriendsService;
        private readonly ObservableCollection<TwitterUserInfo> users = new ObservableCollection<TwitterUserInfo>();
        private string searchString;

        public MainWindowViewModel()
        {
            findUsersCommand = new SimpleCommand((o) => FindUsers());
        }

        public MainWindowViewModel(ITwitterFriendsService twitterFriendsService)
        {
            findUsersCommand = new SimpleCommand((o) => FindUsers());
            this.twitterFriendsService = twitterFriendsService;
        }

        public IEnumerable<TwitterUserInfo> Users
        {
            get { return users; }
        }

        public string SearchString
        {
            get { return searchString; }
            set { searchString = value; }
        }

        private ICommand findUsersCommand;
        public ICommand FindUsersCommand
        {
            get { return findUsersCommand; }
            set { findUsersCommand = value; }
        }

        private void FindUsers()
        {
            users.Clear();
            twitterFriendsService.FindUsersByKeywords(SearchString).ToList().ForEach(users.Add);
        }
    }

     public class SimpleCommand : ICommand
  {
      public Predicate<object> CanExecuteDelegate { get; set; }
         private Action<object> executeDelegate;
         public Action<object> ExecuteDelegate
         {
             get { return executeDelegate; }
             set { executeDelegate = value; }
         }

         public SimpleCommand(Action<object> executeDelegate)
         {
             this.executeDelegate = executeDelegate;
         }

         #region ICommand Members
   
      public bool CanExecute(object parameter)
      {
          if (CanExecuteDelegate != null)
              return CanExecuteDelegate(parameter);
          return true;// if there is no can execute default to true
      }
   
      public event EventHandler CanExecuteChanged
      {
          add { CommandManager.RequerySuggested += value; }
          remove { CommandManager.RequerySuggested -= value; }
      }
   
      public void Execute(object parameter)
      {
          if (ExecuteDelegate != null)
              ExecuteDelegate(parameter);
      }
   
      #endregion
  }
}