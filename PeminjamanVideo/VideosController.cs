using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeminjamanVideo
{
    public class VideosController
    {
        PeminjamanEntities _context = new PeminjamanEntities();
        string input;
        public void Menu()
        {
            System.Console.WriteLine("=====================");
            System.Console.WriteLine("1. Get All");
            System.Console.WriteLine("2. Get By Id");
            System.Console.WriteLine("3. Insert");
            System.Console.WriteLine("4. Update");
            System.Console.WriteLine("5. Delete");
            System.Console.WriteLine("=====================");
            System.Console.Write("pilihan kalian : ");
            int choice = Convert.ToInt32(System.Console.ReadLine());
            switch (choice)
            {
                case 1:
                    GetAll();
                    System.Console.Read();
                    break;
                case 2:
                    System.Console.Write("Masukkan Id Video yang ingin di cari : ");
                    input = Convert.ToString(System.Console.ReadLine());
                    GetById(input);
                    System.Console.Read();
                    break;
                case 3:
                    Insert();
                    System.Console.Read();
                    break;
                case 4:
                    System.Console.Write("Masukkan Id yang ingin di ubah : ");
                    input = Convert.ToString(System.Console.ReadLine());
                    Update(input);
                    System.Console.Read();
                    break;
                case 5:
                    System.Console.Write("Masukkan Id yang ingin di hapus : ");
                    input = Convert.ToString(System.Console.ReadLine());
                    Delete(input);
                    System.Console.Read();
                    break;
                default:
                    System.Console.Write("Periksa kembali");
                    System.Console.Read();
                    break;
            }
        }

        public void Insert()
        {
            System.Console.Write("Masukkan Kode Video : ");
            string kode_video = System.Console.ReadLine();
            System.Console.Write("Masukkan Nama Video : ");
            string nama_video = System.Console.ReadLine();
            System.Console.Write("Produksi : ");
            string produksi = System.Console.ReadLine();
            System.Console.Write("Jenis Video : ");
            int kode_jenis = Convert.ToInt16(System.Console.ReadLine());
            System.Console.Write("Stok : ");
            int stok = Convert.ToInt16(System.Console.ReadLine());
            System.Console.Write("Bahasa : ");
            string bahasa = System.Console.ReadLine();
            MsVideo video = new MsVideo()
            {
                KdVideo = kode_video,
                NmVideo = nama_video,
                Produksi = produksi,
                JenisVideo = kode_jenis,
                Stok = stok,
                Bahasa = bahasa
            };
            try
            {
                _context.MsVideos.Add(video);
                var result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.InnerException);
            }
        }

        public string Update(string input)
        {
            System.Console.WriteLine("Masukkan Nama Video : ");
            string nama_video = System.Console.ReadLine();
            MsVideo video = GetById(input);
            video.NmVideo = nama_video;
            _context.Entry(video).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return input;
        }

        public void Delete(string input)
        {
            var video = _context.MsVideos.FirstOrDefault(x => x.KdVideo == input);
            try
            {
                if (video == null)
                {
                    System.Console.WriteLine("Id tersebut tidak ada");
                }
                else
                {
                    var x = (from y in _context.MsVideos
                             where y.KdVideo == input
                             select y).FirstOrDefault();
                    _context.MsVideos.Remove(x);
                    _context.SaveChanges();
                }
            } catch (Exception ex)
            {
                System.Console.Write(ex.InnerException);
            }
            
        }

        public List<MsJenis> GetAll()
        {
            var getall = _context.MsJenis1.ToList();
            foreach (MsJenis video in getall)
            {
                System.Console.WriteLine("================");
                System.Console.WriteLine("Kode Video : " + video.KdJenis);
                System.Console.WriteLine("Genre : " + video.NamaJenis);
                System.Console.WriteLine("================");
            }
            return getall;
        }

        public MsVideo GetById(string input)
        {
            var video = _context.MsVideos.FirstOrDefault(x => x.KdVideo == input);
            if (video == null)
            {
                System.Console.WriteLine("Id tersebut tidak ada");
            } else if (video.KdVideo == input)
            {
                Console.WriteLine("Kode Video : " + video.KdVideo);
                Console.WriteLine("Nama Video : " + video.NmVideo);
            }

            return video;
        }
    }
}
