using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeminjamanVideo
{
    public class TrPinjamController
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
                    System.Console.Write("Masukkan kode transaksi yang ingin di cari : ");
                    input = Convert.ToString(System.Console.ReadLine());
                    GetById(input);
                    System.Console.Read();
                    break;
                case 3:
                    Insert();
                    System.Console.Read();
                    break;
                case 4:
                    System.Console.Write("Masukkan kode transaksi yang ingin di ubah : ");
                    input = Convert.ToString(System.Console.ReadLine());
                    Update(input);
                    System.Console.Read();
                    break;
                case 5:
                    System.Console.Write("Masukkan kode transaksi yang ingin di hapus : ");
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
            System.Console.Write("Kode Transaksi : ");
            string kode_trans = System.Console.ReadLine();
            System.Console.Write("Tanggal Pinjam : ");
            DateTime tgl_pinjam = Convert.ToDateTime(System.Console.ReadLine());
            System.Console.Write("Kode Pelanggan : ");
            string kode_pelanggan = System.Console.ReadLine();
            System.Console.Write("Kode Video : ");
            string kode_video = System.Console.ReadLine();
            System.Console.Write("Lama Pinjam : ");
            int lama_pinjam = Convert.ToInt16(System.Console.ReadLine());
            TrPinjam trans = new TrPinjam()
            {
                KdTransaksi = kode_trans,
                TglPinjam = tgl_pinjam,
                KdPelanggan = kode_pelanggan,
                KdVideo = kode_video,
                LamaPinjam = lama_pinjam
            };
            try
            {
                _context.TrPinjams.Add(trans);
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
            System.Console.Write("Tanggal Kembali : ");
            DateTime tgl_kembali = Convert.ToDateTime(System.Console.ReadLine());
            TrPinjam trans = GetById(input);
            trans.TglKembali = tgl_kembali;   
            try
            {
                _context.Entry(trans).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                System.Console.WriteLine("Update data berhasil!");
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.InnerException);
            }
            return input;
        }

        public void Delete(string input)
        {
            var trans = _context.TrPinjams.FirstOrDefault(x => x.KdTransaksi == input);
            try
            {
                if (trans == null)
                {
                    System.Console.WriteLine("Id tersebut tidak ada");
                }
                else
                {
                    var x = (from y in _context.TrPinjams
                             where y.KdTransaksi == input
                             select y).FirstOrDefault();
                    _context.TrPinjams.Remove(x);
                    _context.SaveChanges();
                    System.Console.WriteLine("Delete data berhasil!");
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.InnerException);
            }

        }

        public void GetAll()
        {
            var x = (from trans in _context.TrPinjams
                     join pelanggan in _context.MsPelanggans on trans.KdPelanggan equals pelanggan.KdPelanggan
                     select new { trans.KdTransaksi, trans.TglPinjam, pelanggan.NmPelanggan }).ToList();
            for(int i = 0; i < x.Count(); i++)
            {
                System.Console.WriteLine("================");
                System.Console.WriteLine("Kode Transaksi : " + x[i].KdTransaksi);
                System.Console.WriteLine("Tanggal Pinjam : " + x[i].TglPinjam);
                System.Console.WriteLine("Nama Pelanggan : " + x[i].NmPelanggan);
                System.Console.WriteLine("================");
            }
        }

        public TrPinjam GetById(string input)
        {
            var trans_pinjam = _context.TrPinjams.FirstOrDefault(j => j.KdTransaksi == input);
            var x = (from trans in _context.TrPinjams
                     join pelanggan in _context.MsPelanggans on trans.KdPelanggan equals pelanggan.KdPelanggan
                     where trans.KdTransaksi == input
                     select new { trans.KdTransaksi, trans.TglPinjam, pelanggan.NmPelanggan }).ToList();
            if (x == null)
            {
                System.Console.WriteLine("Id tersebut tidak ada");
            }
            else
            {
                for (int i = 0; i < x.Count(); i++)
                {
                    System.Console.WriteLine("================");
                    System.Console.WriteLine("Kode Transaksi : " + x[i].KdTransaksi);
                    System.Console.WriteLine("Tanggal Pinjam : " + x[i].TglPinjam);
                    System.Console.WriteLine("Nama Pelanggan : " + x[i].NmPelanggan);
                    System.Console.WriteLine("================");
                }
            }
            return trans_pinjam;
        }
    }
}
