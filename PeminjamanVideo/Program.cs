using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeminjamanVideo
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (PeminjamanEntities context = new PeminjamanEntities())
            //{
            //    MsVideo video = context.MsVideos.FirstOrDefault(r => r.NmVideo == "Mission Impossible");
            //    Console.WriteLine(video.KdVideo);
            //    Console.Read();
            //}

            System.Console.WriteLine("=====================");
            System.Console.WriteLine("1. Video");
            System.Console.WriteLine("2. Pelanggan");
            System.Console.WriteLine("3. Transaksi");
            System.Console.WriteLine("=====================");
            System.Console.Write("pilihan kalian : ");
            int choice = Convert.ToInt32(System.Console.ReadLine());
            switch (choice)
            {
                case 1:
                    VideosController video = new VideosController();
                    video.Menu();
                    break;
                case 2:
                    PelangganController pelanggan = new PelangganController();
                    pelanggan.Menu();
                    break;
                case 3:
                    TrPinjamController trans = new TrPinjamController();
                    trans.Menu();
                    break;
                default:
                    System.Console.Write("Periksa kembali");
                    System.Console.Read();
                    break;
            }
        }
    }
}
