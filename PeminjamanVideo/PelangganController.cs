using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeminjamanVideo
{
    public class PelangganController
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
                    System.Console.Write("Masukkan Kode Pelanggan yang ingin di cari : ");
                    input = Convert.ToString(System.Console.ReadLine());
                    GetById(input);
                    System.Console.Read();
                    break;
                case 3:
                    Insert();
                    System.Console.Read();
                    break;
                case 4:
                    System.Console.Write("Masukkan kode pelanggan yang ingin di ubah : ");
                    input = Convert.ToString(System.Console.ReadLine());
                    Update(input);
                    System.Console.Read();
                    break;
                case 5:
                    System.Console.Write("Masukkan kode pelanggan yang ingin di hapus : ");
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
            System.Console.Write("Masukkan Kode Pelanggan : ");
            string kode_pelanggan = System.Console.ReadLine();
            System.Console.Write("Masukkan Nama Pelanggan : ");
            string nama_pelanggan = System.Console.ReadLine();
            System.Console.Write("Alamat : ");
            string alamat = System.Console.ReadLine();
            System.Console.Write("Telepon : ");
            string telp = System.Console.ReadLine();
            System.Console.Write("Jaminan : ");
            decimal jaminan = Convert.ToDecimal(System.Console.ReadLine());
            MsPelanggan pelanggan = new MsPelanggan()
            {
                KdPelanggan = kode_pelanggan,
                NmPelanggan = nama_pelanggan,
                Alamat = alamat,
                Telp = telp,
                Jaminan = jaminan
            };
            try
            {
                _context.MsPelanggans.Add(pelanggan);
                var result = _context.SaveChanges();
                System.Console.WriteLine("Insert data berhasil!");
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.InnerException);
            }
        }

        public string Update(string input)
        {
            System.Console.Write("Masukkan Nama Pelanggan : ");
            string nama_pelanggan = System.Console.ReadLine();
            MsPelanggan pelanggan = GetById(input);
            pelanggan.NmPelanggan = nama_pelanggan;
            _context.Entry(pelanggan).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return input;
        }

        public void Delete(string input)
        {
            var pelanggan = _context.MsPelanggans.FirstOrDefault(x => x.KdPelanggan == input);
            try
            {
                if (pelanggan == null)
                {
                    System.Console.WriteLine("Id tersebut tidak ada");
                }
                else
                {
                    var x = (from y in _context.MsPelanggans
                             where y.KdPelanggan == input
                             select y).FirstOrDefault();
                    _context.MsPelanggans.Remove(x);
                    _context.SaveChanges();
                    System.Console.WriteLine("Delete data berhasil!");
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.InnerException);
            }

        }

        public List<MsPelanggan> GetAll()
        {
            var getall = _context.MsPelanggans.ToList();
            foreach (MsPelanggan pelanggan in getall)
            {
                System.Console.WriteLine("================");
                System.Console.WriteLine("Kode Pelanggan : " + pelanggan.KdPelanggan);
                System.Console.WriteLine("Nama Pelanggan : " + pelanggan.NmPelanggan);
                System.Console.WriteLine("================");
            }
            return getall;
        }

        public MsPelanggan GetById(string input)
        {
            var pelanggan = _context.MsPelanggans.FirstOrDefault(x => x.KdPelanggan == input);
            if (pelanggan == null)
            {
                System.Console.WriteLine("Id tersebut tidak ada");
            }
            else if (pelanggan.KdPelanggan == input)
            {
                Console.WriteLine("Kode Pelanggan : " + pelanggan.KdPelanggan);
                Console.WriteLine("Nama Pelanggan : " + pelanggan.NmPelanggan);
            }
            return pelanggan;
        }
    }
}
