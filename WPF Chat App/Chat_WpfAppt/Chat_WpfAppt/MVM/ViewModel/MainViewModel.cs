using Chat_WpfAppt.Core;
using Chat_WpfAppt.MVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_WpfAppt.MVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        //Create Model.MessageModel, then link here
        public ObservableCollection<MessageModel> Messages { get; set; }

        //Create Model.ContacteModel, then link here
        public ObservableCollection<ContactModel> Contacts { get; set; }


        //Create the enter command which was used in the MessageBox.xaml - see RelayCommand
        public RelayCommand SendCommand { get; set; }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set {
                 _selectedContact = value;
                   OnPropertyChanged();
                }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            //Instanstiate the command
            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });

                Message = "";
            });


            // Showcase items
            Messages.Add(new MessageModel { 
                Username = "Sam_Squirrel",
                UsernameColor = "#409aff",
                ImageSource = "https://i.imgur.com/HUYibMX.jpeg",
                Message = "Test",
                MessageTime = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });



            // Fake because there is no external API to pull in the data
            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Sam_Squirrel",
                    UsernameColor = "#409aff",
                    ImageSource = "https://i.imgur.com/HUYibMX.jpeg",
                    Message = "Test",
                    MessageTime = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false

                });
            }

            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = " Sam_Squirrel",
                    UsernameColor = "#409aff",
                    ImageSource = "https://i.imgur.com/HUYibMX.jpeg",
                    Message = "Test",
                    MessageTime = DateTime.Now,
                    IsNativeOrigin = true,
                });
            }

            Messages.Add(new MessageModel
            {
                Username = "Sam_Squirel",
                UsernameColor = "#409aff",
                ImageSource = "https://i.imgur.com/HUYibMX.jpeg",
                Message = "Last",
                MessageTime = DateTime.Now,
                IsNativeOrigin = true,
            });

            // Create 5 fake contacts
            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel { 
                    Username = $"Betty_Bunny {i}",
                    ImageSource = "https://i.imgur.com/tPnzJEz.jpeg",
                    Messages = Messages
                });

            }
        }
    }
}
