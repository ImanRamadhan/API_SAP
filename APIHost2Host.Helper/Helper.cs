using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using System.Xml;
using Newtonsoft.Json;
using System.IO;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net;
using System.Web;

namespace APIHost2Host.Helper
{
    public abstract class ActivityLogBase
    {
        public string HostName { get; set; }
        public string IPAddress { get; set; }
        public string UserName { get; set; }
        public string Activity { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Data { get; set; }
        public LogType Type { get; set; }
        public AppName ApplicationName { get; set; }
        public string PageName
        {
            get { return GetPageName(); }
        }

        private string GetPageName()
        {
            return System.IO.Path.GetFileName(HttpContext.Current.Request.Url.AbsolutePath);
        }

        public ActivityLogBase()
        {

        }

        public ActivityLogBase(HttpRequest request, string activity, string userName)
        {
            this.HostName = request.UserHostName;
            this.IPAddress = request.UserHostAddress;
            this.UserName = userName;
            this.Activity = activity;
            this.Data = "";
        }

        public ActivityLogBase(string activity, string userName)
        {
            this.HostName = HttpContext.Current.Request.UserHostName;
            this.IPAddress = HttpContext.Current.Request.UserHostAddress;
            this.UserName = userName;
            this.Activity = activity;
            this.Data = "";
        }

        public abstract void InsertLog();

        public enum AppName
        {
            SIMA,
            AIS
        }

        public enum LogType
        {
            Error,
            Success,
            Failed
        }

        public static string ParamToString(Hashtable parameters)
        {
            var result = "";

            foreach (DictionaryEntry item in parameters)
            {
                var data = "";

                try
                {
                    data = (item.Value == null) ? "NULL" : item.Value.ToString();
                }
                catch (Exception e)
                {

                }

                try
                {
                    result += item.Key.ToString().Split('-')[0] + " : " + data + " ; ";
                }
                catch (Exception e)
                {

                }


            }

            return result;
        }

        public static string ParamToString(List<System.Data.SqlClient.SqlParameter> param)
        {
            string result = "";


            foreach (var item in param)
            {
                string value = "";


                try
                {
                    if (item.SqlDbType == SqlDbType.Structured)
                    {
                        System.IO.StringWriter sw = new System.IO.StringWriter();
                        var dt = (DataTable)item.Value;
                        dt.TableName = item.ParameterName;

                        dt.WriteXml(sw);

                        value = sw.ToString();
                    }
                    else
                    {
                        value = item.Value.ToString();
                    }
                }
                catch (Exception ex)
                {

                }

            }



            return result;
        }
    }

    public static class ExtendMethod
    {
        public static List<T> Clone<T>(this List<T> listToClone) where T : new()
        {
            return listToClone.Select(item => item).ToList();
        }

        public static void FillFromDataTable<T>(this List<T> list, DataTable data) where T : new()
        {
            //if (list == null) list = new List<T>();

            foreach (DataRow item in data.Rows)
            {
                var r = new T();
                r.FillFromDataRow(item);

                list.Add(r);
            }
        }


        public static void FillFromDataTable<T>(this List<T> list, DataRow[] data) where T : new()
        {
            //if (list == null) list = new List<T>();

            foreach (DataRow item in data)
            {
                var r = new T();
                r.FillFromDataRow(item);

                list.Add(r);
            }
        }


        public static string GetClientIpAddress(this HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return IPAddress.Parse(((HttpContextBase)request.Properties["MS_HttpContext"]).Request.UserHostAddress).ToString();
            }
            return null;
        }

        public static void Add(this List<SqlParameter> list, string parameterName, object value)
        {
            list.Add(new SqlParameter(parameterName, value ?? DBNull.Value));
        }

        public static string ToJson(this object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public static string ToJson(this DataTable data)
        {
            return HelpMe.DataTable2JSON(data);
        }

        public static string ToJson(this DataSet data)
        {
            return HelpMe.Dataset2JSON(data);
        }

        public static void FillFromDataRow(this object origin, DataRow data)
        {
            var theprops = origin.GetType().GetProperties();
            foreach (var item in theprops)
            {
                try
                {
                    if (item.CanWrite)
                    {
                        item.SetValue(origin, data[item.Name]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void SetColumnsOrder(this DataTable table, params String[] columnNames)
        {
            int columnIndex = 0;
            foreach (var columnName in columnNames)
            {
                table.Columns[columnName].SetOrdinal(columnIndex);
                columnIndex++;
            }
        }

        /// <summary>
        /// Method extend untuk konversi tipe datetime ke string dengan bahasa indonesia
        /// </summary>
        /// <param name="format">format string contoh DD/MMM/YYYY </param>
        /// <returns>string datetime sesuai dengan format yang diinputkan</returns>
        public static string ToStringIndonesia(this DateTime date, string format)
        {

            format = format.Replace("yyyy", date.Year.ToString());
            format = format.Replace("yyy", date.Year.ToString().Substring(1, 3));
            format = format.Replace("yy", date.Year.ToString().Substring(2, 2));

            format = format.Replace("YYYY", date.Year.ToString());
            format = format.Replace("YYY", date.Year.ToString().Substring(1, 3));
            format = format.Replace("YY", date.Year.ToString().Substring(2, 2));

            format = format.Replace("tt", date.ToString("tt"));
            format = format.Replace("t", date.ToString("t"));

            format = format.Replace("mm", date.ToString("mm"));
            format = format.Replace("ss", date.ToString("ss"));

            format = format.Replace("HH", date.ToString("HH"));
            format = format.Replace("hh", date.ToString("hh"));

            format = format.Replace("MMMM", Bulan(date.Month));
            format = format.Replace("MMM", Bulan(date.Month).Substring(0, 3));
            format = format.Replace("MM", date.Month.ToString());
            format = format.Replace("dddd", Hari(date.ToString("dddd")));
            format = format.Replace("ddd", Hari(date.ToString("dddd")).Substring(0, 3));
            format = format.Replace("dd", date.ToString("dd"));

            return format;
        }
        
        private static string Hari(string hari)
        {
            string terbilang = hari;
            hari = hari.ToLower();

            switch (hari)
            {
                case "monday":
                    terbilang = "Senin";
                    break;
                case "tuesday":
                    terbilang = "Selasa";
                    break;
                case "wednesday":
                    terbilang = "Rabu";
                    break;
                case "thursday":
                    terbilang = "Kamis";
                    break;
                case "friday":
                    terbilang = "Jumat";
                    break;
                case "saturday":
                    terbilang = "Sabtu";
                    break;
                case "sunday":
                    terbilang = "Minggu";
                    break;
                default:
                    break;
            }

            return terbilang;
        }

        private static string Bulan(int bulan)
        {
            string terbilang = "";

            switch (bulan)
            {
                case 1:
                    terbilang = "Januari";
                    break;
                case 2:
                    terbilang = "Februari";
                    break;
                case 3:
                    terbilang = "Maret";
                    break;
                case 4:
                    terbilang = "April";
                    break;
                case 5:
                    terbilang = "Mei";
                    break;
                case 6:
                    terbilang = "Juni";
                    break;
                case 7:
                    terbilang = "Juli";
                    break;
                case 8:
                    terbilang = "Agustus";
                    break;
                case 9:
                    terbilang = "September";
                    break;
                case 10:
                    terbilang = "Oktober";
                    break;
                case 11:
                    terbilang = "November";
                    break;
                case 12:
                    terbilang = "Desember";
                    break;
                default:
                    break;
            }

            return terbilang;

        }



    }

    public class KeyPair
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Other { get; set; }
    }

    public class HelpMe
    {
        public static Stream CopyAndClose(Stream inputStream)
        {
            const int readSize = 256;
            byte[] buffer = new byte[readSize];
            MemoryStream ms = new MemoryStream();

            int count = inputStream.Read(buffer, 0, readSize);
            while (count > 0)
            {
                ms.Write(buffer, 0, count);
                count = inputStream.Read(buffer, 0, readSize);
            }
            ms.Position = 0;
            inputStream.Close();
            return ms;
        }

        /// <summary>
        /// generate random string dengan panjang yang ditentukan
        /// </summary>
        /// <param name="length">panjang string yang akan di generate</param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            Random random = new Random();

            string chars = "abcdefghijklmnopqrstuvwxyz!?.,;ABCDEFGHIJKLMNOPQRSTUVWXYZ456789!?.,;";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// generate random string dengan panjang dan karakter set yang ditentukan 
        /// </summary>
        /// <param name="length">panjang string yang akan digenerate</param>
        /// <param name="characters">set karakter yang akan dijadikan acuan</param>
        /// <returns></returns>
        public static string RandomString(int length, string characters)
        {
            Random random = new Random();

            return new string(Enumerable.Repeat(characters, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void DownloadFile(string AddressSourceFile, byte[] ContentByte)
        {
            try
            {
                HttpContext Context = HttpContext.Current;
                HttpResponse Response = HttpContext.Current.Response;
                string FileName = Path.GetFileName(AddressSourceFile);
                string Extension = Path.GetExtension(FileName);

                Context.Response.ClearContent();
                Context.Response.Clear();
                Context.Response.ContentType = ReturnExtension(Extension);
                Context.Response.AddHeader("content-disposition", "attachment; filename=" + FileName);
                Context.Response.BufferOutput = true;
                Context.Response.OutputStream.Write(ContentByte, 0, ContentByte.Length);
                Context.Response.Flush();
                Context.ApplicationInstance.CompleteRequest();
                //Context.Response.End();
            }
            catch (System.Threading.ThreadAbortException abrtEX)
            {
                throw abrtEX;
            }
        }

        public static string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }

        public static List<KeyPair> GetKeyValues(string keyName)
        {
            var result = new List<KeyPair>();

            var param = SQLAccessHelper.NewParam;
            param.Add("@KeyName", keyName);

            var ds = SQLAccessHelper.PopulateDataSetByQuery(CommandType.StoredProcedure, "USP_KEY_VALUE_GET_BY_KEYNAME", param);

            result.FillFromDataTable(ds.Tables[0]);

            return result;

        }

        public static class InitializeArrayHelper
        {
            /*Source: https://stackoverflow.com/questions/3301678/how-to-declare-an-array-of-objects-in-c-sharp */
            public static T[] InitializeArray<T>(int length) where T : new()
            {
                T[] array = new T[length];
                for (int i = 0; i < length; ++i)
                {
                    array[i] = new T();
                }

                return array;
            }
        }

        public static DataTable DBHashTable
        {
            get
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("Key");
                dt.Columns.Add("Value");
                dt.Columns.Add("Other");

                return dt.Clone();
            }
        }

        public static string RandomName
        {
            get
            {
                string[] namas = {
                                     "Amy Delia",
                                     "Andi Zainal A. Dulung",
                                     "Andre S Prijono",
                                     "Edi Firmansyah",
                                     "Eliani Johan",
                                     "Era Helvani",
                                     "Jeannie Widjaja",
                                     "Jo Andreson Wiharjo",
                                     "Juliana Kusnandar",
                                     "Jusuf Tanuwidjaja",
                                     "Maria Karmila",
                                     "Markun",
                                     "Marten Liu",
                                     "Melina Jonas",
                                     "Merry",
                                     "Michael Goenawan",
                                     "Mintardjo Halim",
                                     "Mustofa"
                                 };
                Random rnd = new Random();
                return namas[rnd.Next() % namas.Length];
            }
        }

        public static string RandomAddress
        {
            get
            {
                string[] namas = {
                                    "Jl. KH Agus Salim 16, Sabang, Menteng Jakarta Pusat",
                                    "Jl. Taman Margasatwa No. 12, Warung Buncit, Jakarta Selatan",
                                    "JL. Tebet Raya No. 84, Tebet, Jakarta Selatan",
                                    "Jl. Metro Pondok Indah Kav. IV, Kebayoran Lama, Jakarta Selatan",
                                    "Jl. KH. Agus Salim No. 29A Jakarta Pusat",
                                    "Jl. Hos Cokroaminoto, No. 84, Menteng Jakarta Pusat",
                                    "Jl. Ahmad Dahlan/ Jl. Bacang I No.2 Jakarta Selatan",
                                    "Jl. Benda No. 20D, Kemang Jakarta Selatan",
                                    "Jl. Alam Segar 3 No. 8, Pondok Indah Jakarta Selatan",
                                    "Jl. Kebon Jeruk Raya No. 44 (depan SMPN 75) Jakarta Barat. Telepon: 021-5483990",
                                    "Jl. KH Asahari, Pinang Ciledug Tangerang",
                                    "Jl. Arya Putra, Kedaung Ciputat Tangerang",
                                    "Jl. Buaran Raya Blok D No. 1 Duren Sawit Jakarta Timur",
                                    "Jl. Tebet Barat 1 No. 24 (Samping SMA 26) Jakarta Selatan"
                                 };
                Random rnd = new Random();
                return namas[rnd.Next(0, namas.Length)];
            }
        }


        #region terbilang

        /// <summary>
        /// method untuk konversi angke menjadi terbilang dalam bahasa indonesia
        /// </summary>
        /// <param name="number">nomor dengan format string. titik akan dibaca sebagai koma</param>
        /// <returns>string dengan hasil terbilang</returns>
        public static string Terbilang(string number)
        {
            string terbilang = "";

            number = number.Replace(",", ".");

            var split = number.Split('.');

            string sebelumkoma = split[0];
            string setelahKoma;

            if (number.Contains("."))
            {
                setelahKoma = split[1];
            }
            else
            {
                setelahKoma = "";
            }

            string terbilangSebelumKoma = PreTerbilang(sebelumkoma);



            string terbilangSetelahKoma = "";// PreTerbilang(setelahKoma);
            bool findpos = false;

            for (int k = setelahKoma.Length; k > 0; k--)
            {
                var nowchar = setelahKoma[k - 1].ToString();
                if (nowchar != "0" || findpos)
                {
                    terbilangSetelahKoma = BacaSatuAngka(nowchar) + " " + terbilangSetelahKoma;

                    if (nowchar != "0") findpos = true;
                }

            }

            terbilangSetelahKoma = terbilangSetelahKoma.Trim();

            terbilang += terbilangSebelumKoma;

            if (!string.IsNullOrEmpty(terbilangSetelahKoma) || !string.IsNullOrWhiteSpace(terbilangSetelahKoma))
            {
                terbilang += " Koma " + terbilangSetelahKoma;
            }

            return terbilang;


        }

        private static string PreTerbilang(string number)
        {
            List<string> sebutan = new List<string>();
            sebutan.Add("");
            sebutan.Add(" Ribu"); //10^3
            sebutan.Add(" Juta"); //10^6
            sebutan.Add(" Miliar"); //10^9
            sebutan.Add(" Triliun"); //10^12
            sebutan.Add(" Kuadriliun"); //10^15
            sebutan.Add(" Kuintiliun"); //10^18
            sebutan.Add(" Sekstiliun"); //10^21
            sebutan.Add(" Septiliun"); //10^24
            sebutan.Add(" Oktiliun"); //10^27
            sebutan.Add(" Noniliun"); //10^30
            sebutan.Add(" Desiliun"); //10^33

            string terbilang = "";
            number = number.Trim();
            if (number.All(char.IsDigit))
            {

                try
                {

                    int i = number.Length - 1;
                    int counterSbeutan = 0;
                    int counter3angka = 0;
                    string toTigaAngka = "";


                    while (i >= 0)
                    {
                        if (counter3angka < 3)
                        {
                            toTigaAngka = toTigaAngka.Insert(0, number[i].ToString());
                            counter3angka++;
                        }

                        if (counter3angka >= 3 || i == 0)
                        {
                            if (toTigaAngka != "000")
                            {
                                terbilang = terbilang.Insert(0, BacaTigaAngka(toTigaAngka) + sebutan[counterSbeutan]);
                            }
                            counter3angka = 0;
                            counterSbeutan++;
                            toTigaAngka = "";
                        }
                        i--;
                    }

                    terbilang = terbilang.Replace("Satu Ribu", "Seribu");
                    terbilang = terbilang.Replace("  ", " ");
                    return terbilang.Trim();
                }
                catch (Exception)
                {
                    terbilang = "";
                }
            }
            else
            {

                terbilang = "";
            }

            return terbilang.Trim();
        }

        private static string BacaTigaAngka(string number)
        {
            string terbilang = "";
            try
            {

                if (number == "0")
                {
                    terbilang = "Nol";
                }
                else
                {
                    number = Convert.ToInt32(number).ToString();
                    terbilang = " " + BacaSatuAngka(number[number.Length - 1].ToString());
                    if (number != "0")
                    {
                        if (number.Length >= 2 && number[number.Length - 2].ToString() != "0")
                        {
                            if (number[number.Length - 2].ToString() == "1" && number[number.Length - 1].ToString() != "0")
                            {
                                terbilang = terbilang.Insert(terbilang.Length, " Belas");
                            }
                            else //if(number[number.Length - 2].ToString() != "1")
                            {
                                terbilang = terbilang.Insert(0, " " + BacaSatuAngka(number[number.Length - 2].ToString()) + " Puluh");
                            }
                        }

                        if (number.Length == 3)
                        {
                            terbilang = terbilang.Insert(0, " " + BacaSatuAngka(number[number.Length - 3].ToString()) + " Ratus");
                        }
                    }
                }


                terbilang = terbilang.Replace("Satu Puluh", "Sepuluh");
                terbilang = terbilang.Replace("Satu Belas", "Sebelas");
                terbilang = terbilang.Replace("Satu Ratus", "Seratus");

            }
            catch (Exception e)
            {
                return "";
            }
            return terbilang;

        }

        private static string BacaSatuAngka(string number)
        {
            number = number.Trim();
            string terbilang = "";
            int i = Convert.ToInt32(number);

            switch (i)
            {
                case 0:
                    terbilang = "Nol";
                    break;
                case 1:
                    terbilang = "Satu";
                    break;
                case 2:
                    terbilang = "Dua";
                    break;
                case 3:
                    terbilang = "Tiga";
                    break;
                case 4:
                    terbilang = "Empat";
                    break;
                case 5:
                    terbilang = "Lima";
                    break;
                case 6:
                    terbilang = "Enam";
                    break;
                case 7:
                    terbilang = "Tujuh";
                    break;
                case 8:
                    terbilang = "Delapan";
                    break;
                case 9:
                    terbilang = "Sembilan";
                    break;

                default:
                    break;
            }

            return terbilang;
        }



        #endregion terbilang


        #region download


        /// <summary>
        /// method untuk membuat respon file di asp web form
        /// </summary>
        /// <param name="response">input properti Response milih page yang sedang dikerjakan</param>
        /// <param name="binaryData">binary data file yang akan didownload</param>
        /// <param name="fileName">nama file lengkap dengan extensionnya, contoh: image.jpg</param>
        public static void ToDownload(System.Web.HttpResponse response, byte[] binaryData, string fileName)
        {
            var mime = System.Web.MimeMapping.GetMimeMapping(fileName);

            fileName = System.IO.Path.GetFileName(fileName);

            response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            response.ContentType = mime;
            response.BinaryWrite(binaryData);
            response.Flush();
            response.End();
        }

        /// <summary>
        /// method untuk membuat respon file di asp web form, dengan opsi untuk menentukan akhir respon
        /// </summary>
        /// <param name="response">input properti Response milih page yang sedang dikerjakan</param>
        /// <param name="binaryData">binary data file yang akan didownload</param>
        /// <param name="fileName">nama file lengkap dengan extensionnya, contoh: image.jpg</param>
        /// <param name="isEnd">menentukan apakah respon diakhir atau tidak</param>
        public static void ToDownload(System.Web.HttpResponse response, byte[] binaryData, string fileName, bool isEnd)
        {
            var mime = System.Web.MimeMapping.GetMimeMapping(fileName);

            fileName = System.IO.Path.GetFileName(fileName);

            response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            response.ContentType = mime;
            response.BinaryWrite(binaryData);
            response.Flush();

            if (isEnd)
            {
                response.End();
            }

        }

        public static string GetMime(string filename)
        {
            return System.Web.MimeMapping.GetMimeMapping(filename);
        }

        #endregion


        #region to roman
        private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        /// <summary>
        /// konversi nomor integer menjadi string nomor romawi
        /// </summary>
        /// <param name="number">nilai integer yang akan di konversi</param>
        /// <returns>string nilai romawi</returns>
        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }


        /// <summary>
        /// konversi nilai romawi ke integer
        /// </summary>
        /// <param name="roman">nilai romawi yang akan di konversi</param>
        /// <returns>int nilai hasil koversi</returns>
        public static int RomanToInteger(string roman)
        {
            int number = 0;
            char previousChar = roman[0];
            foreach (char currentChar in roman)
            {
                number += RomanMap[currentChar];
                if (RomanMap[previousChar] < RomanMap[currentChar])
                {
                    number -= RomanMap[previousChar] * 2;
                }
                previousChar = currentChar;
            }
            return number;
        }

        #endregion to roman


        #region dataTableToJson

        public static string DataTable2JSON(DataTable data)
        {

            var xml = DataTable2XML(data.Copy());

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml);

            return JsonConvert.SerializeXmlNode(xmldoc);

        }



        #endregion dataTableToJson


        #region dataTable2XML
        public static string DataTable2XML(DataTable data)
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            var dt = (DataTable)data;

            if (dt.TableName.Trim() == string.Empty)
            {
                dt.TableName = "DataTable";
            }

            DataSet ds = new DataSet("DataSet");

            ds.Tables.Add(data);

            ds.WriteXml(sw);

            return sw.ToString();
        }
        #endregion

        #region Dataset2JSON
        public static string Dataset2JSON(DataSet data)
        {
            var xml = Dataset2XML(data.Copy());

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml);

            return JsonConvert.SerializeXmlNode(xmldoc);
        }

        public static string Dataset2XML(DataSet data)
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            var dt = (DataSet)data;

            int i = 1;
            foreach (DataTable item in data.Tables)
            {
                var tblName = item.TableName ?? string.Empty;
                if (tblName == string.Empty)
                {
                    item.TableName = "Table" + i;
                }
                i++;
            }


            data.WriteXml(sw);

            return sw.ToString();
        }
        #endregion

        #region JSON2Datatable

        public static DataTable Json2DataTable(string jsonArray)
        {
            return (DataTable)JsonConvert.DeserializeObject(jsonArray, (typeof(DataTable)));
        }


        #endregion


        #region JSONSerialization

        public static T Json2Class<T>(string data)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return JsonConvert.DeserializeObject<T>(data, settings);
        }

        #endregion

        #region listToDataTable

        public static DataTable ListToDataTable<T>(List<T> data) where T : new()
        {
            DataTable dt = new DataTable();

            var proplist = typeof(T).GetProperties();

            foreach (var item in proplist)
            {
                if (item.CanRead)
                {
                    dt.Columns.Add(item.Name);
                }
            }

            foreach (var item in data)
            {
                var nr = dt.NewRow();

                foreach (DataColumn col in dt.Columns)
                {
                    var theProp = proplist.FirstOrDefault(t => t.Name == col.ColumnName);
                    nr[col] = theProp.GetValue(item);
                }

                dt.Rows.Add(nr);
            }

            return dt;
        }

        #endregion

        #region dataTableToList

        public static List<T> DataTableToList<T>(DataTable data) where T : new()
        {
            List<T> list = new List<T>();

            foreach (DataRow item in data.Rows)
            {
                var newrow = new T();
                var proplist = newrow.GetType().GetProperties();
                foreach (DataColumn col in data.Columns)
                {
                    var theprop = proplist.FirstOrDefault(x => x.Name == col.ColumnName);

                    if (theprop != null)
                    {
                        var setter = theprop.GetSetMethod(true);

                        if (setter != null)
                        {
                            var theType = theprop.PropertyType;
                            if (item[col] != DBNull.Value)
                            {
                                if (!theType.IsEnum)
                                {
                                    setter.Invoke(newrow, new object[] { Convert.ChangeType(item[col], theprop.PropertyType) });
                                }
                                else
                                {
                                    setter.Invoke(newrow, new object[] { Enum.Parse(theType, item[col].ToString(), true) });
                                }
                            }
                        }
                    }


                }

                list.Add(newrow);

            }


            return list;
        }


        #endregion


        #region Excel to Database

        #endregion


        #region Excel to Datatable

        #endregion
    }
}
