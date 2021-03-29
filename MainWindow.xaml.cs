using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfJsonConverterSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string FilePath = @"c:\temp\user.json";

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSerialize_Click(object sender, RoutedEventArgs e)
        {
            // UserModelの生成
            var user = this.CreateUserModel();
            // 生成したUserModelをJsonに変換
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            // ファイル出力
            using (var sw = new StreamWriter(FilePath, false, Encoding.UTF8))
            {
                sw.Write(json);
            }
        }

        /// <summary>
        /// CreateUserModel
        /// </summary>
        /// <returns></returns>
        private UserModel CreateUserModel()
        {
            var tanaka = new UserModel();
            tanaka.CreatedDateTime = DateTime.Now;
            tanaka.UserId = 1;
            tanaka.UserName = "田中　太郎";
            tanaka.BirthDay = new DateTime(1990, 12, 23);

            var mama = new UserModel();
            mama.CreatedDateTime = DateTime.Now;
            mama.UserId = 2;
            mama.UserName = "田中　花子";
            mama.BirthDay = new DateTime(1991, 3, 4);
            tanaka.Family.Add(mama);

            var child = new UserModel();
            child.CreatedDateTime = DateTime.Now;
            child.UserId = 3;
            child.UserName = "田中　一郎";
            child.BirthDay = new DateTime(2018, 11, 1);
            tanaka.Family.Add(child);

            return tanaka;
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeserialize_Click(object sender, RoutedEventArgs e)
        {
            var json = File.ReadAllText(FilePath);
            var userModel = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(json);

            var result = Newtonsoft.Json.JsonConvert.SerializeObject(json);
            Debug.WriteLine(result);
        }
    }
}
