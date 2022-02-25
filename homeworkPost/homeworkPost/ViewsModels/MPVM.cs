using DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace homeworkPost.ViewsModels
{
    class MPVM
    {

        const string url = "http://192.168.1.5:26333/User/";
        private HttpClient GetCLient()
        {
            HttpClient client = new HttpClient(GetInsecureHandler());
            return client;
        }
        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

        private ObservableCollection<User> _user;
        public ObservableCollection<User> Users
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
        public async Task LoadData()
        {
            var client = new HttpClient(GetInsecureHandler());
            var result = await client.GetAsync("http://192.168.1.5:26333/User/GetAllUser").ConfigureAwait(false);
            var json = await result.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<ObservableCollection<User>>(json);
            Users = users;
        }
        public ICommand SomeCommand => new Command(async value => { await LoadData(); });

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}

