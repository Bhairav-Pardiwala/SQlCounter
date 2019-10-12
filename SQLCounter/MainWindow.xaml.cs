using Microsoft.Win32;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Http;
using System.Windows.Threading;
using CsvHelper;
using System.IO;

namespace SQLCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly HttpClient client = new HttpClient();
        DispatcherTimer tmr = new DispatcherTimer();
        List<Record> records = new List<Record>();
        public MainWindow()
        {
            InitializeComponent();
            //mysql();

            //ReadList(DateTime.Now,DateTime.Now);
            ReadList();
            tmr.Interval = TimeSpan.FromSeconds(10);
            tmr.Tick += Refresh_Tick;
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
             ReadList();
        }

        private async Task ReadList()
        {
            var list=await PerformCall();
            records = list;
            listRecords.ItemsSource = records;
            cnt.Text = "cnt:"+records.Count.ToString();
        }

        public async Task<List<Record>> PerformCall(bool isDelete = false)
        {
            var postContent = "{\"key1\":\"\",\"operation\":\"read\"}";
            if(isDelete)
            {
                postContent = "{\"key1\":\"\",\"operation\":\"delete\"}";
            }
            var content = new StringContent(postContent,Encoding.UTF8,"application/json");
            HttpResponseMessage response;
            try
            {
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                response = await client.PostAsync("", content);
            }
            catch (Exception e)
            {

                throw;
            }
            //response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<Record>>(responseBody);
            return data;
        }

        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {
            ReadList();
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            await PerformCall(true);
            ReadList();
        }

        private void ChkRefresh_Checked(object sender, RoutedEventArgs e)
        {
            if(chkRefresh.IsChecked==true)
            {
                tmr.Start();
            }
            else
            {
                tmr.Stop();
            }
        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            var saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".csv";
           var file= saveFile.ShowDialog();
            if(file!=null)
            {
                using (var writer = new StreamWriter(saveFile.FileName))
                using (var csv = new CsvWriter(writer))
                {
                    csv.WriteRecords(records);
                }
            }
           
        }

        //private void ReadList(DateTime start,DateTime end)
        //{
        //    var connstr = "Server=205.147.111.116;Uid=psyzone_psyzone;Pwd=Mmb.2850;database=psyzone_test;";
        //    MySqlConnection cn = new MySqlConnection(connstr);

        //    try
        //    {

        //        string sqlCmd = "SELECT * FROM psyzone_test.set";

        //        MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
        //        adr.SelectCommand.CommandType = CommandType.Text;
        //        DataTable dt = new DataTable();
        //        adr.Fill(dt); //opens and closes the DB connection automatically !! (fetches from pool)

        //        var js = JsonConvert.SerializeObject(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("{oops - {0}", ex.Message);
        //    }
        //    finally
        //    {
        //        cn.Dispose(); // return connection to pool
        //    }

        //}

        //private async Task mysql()
        //{
        //    try
        //    {
        //        var connstr = "Server=psyzone.co.in;Uid=psyzone_psyzone;Pwd=Mmb.2850;database=psyzone_test;";
        //        using (var conn = new MySqlConnection(connstr))
        //        {


        //            conn.Open();

        //            using (var cmd = conn.CreateCommand())
        //            {


        //                cmd.CommandTimeout = 0;
        //                cmd.CommandText = @"SELECT * FROM psyzone_test.set ";
        //                //cmd.CommandText = "select * from pe_stage.pe_newsletter_categories ";
        //                //cmd.Parameters.AddWithValue("@ID", 547);
        //                var list = new List<Tuple<String, String>>();
        //                using (var reader = cmd.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        var name = reader.GetString("id");
        //                        var mail= reader.GetString("name");
        //                        var date = reader.GetDateTime("Datetime");
        //                        list.Add(new Tuple<string, string>(name, mail));

        //                    }
        //                }
        //                var str = "uname,umail"+Environment.NewLine;
        //                foreach (var item in list)
        //                {
        //                    str += item.Item1 + "," + item.Item2 + Environment.NewLine;
        //                }



        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }

        //}
    }
    public class Set
    {

    }
}
