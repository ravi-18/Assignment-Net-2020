using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace DataAccess
{
    public class DetailPenjualanRepo
    {
        //Get All
        public static List<DetailPenjualanViewModel> All()
        {
            List<DetailPenjualanViewModel> result = new List<DetailPenjualanViewModel>();
            using (var db = new Context())
            {
                result = (from c in db.DetailPenjualans
                          select new DetailPenjualanViewModel
                          {
                              id = c.id,
                              no_nota = c.no_nota,
                              kode_barang = c.kode_barang,
                              quantity = c.quantity,
                              subtotal = c.subtotal,

                              created_at = c.created_at,
                              created_by = c.created_by,
                              modified_at = c.modified_at,
                              modified_by = c.modified_by,
                              is_delete = c.is_delete,
                              deleted_at = c.deleted_at,
                              deleted_by = c.deleted_by
                          }).ToList();
            }
            return result;
        }

        //Get By Id
        public static DetailPenjualanViewModel ById(int id)
        {            
            DetailPenjualanViewModel result = new DetailPenjualanViewModel();
            using (var db = new Context())
            {                
                result = (from c in db.DetailPenjualans
                          //join d in db.Barangs on c.kode_barang equals d.kode_barang
                          //join e in db.Penjualans on c.no_nota equals e.no_nota
                          where c.id == id
                          select new DetailPenjualanViewModel
                          {
                              id = c.id,
                              no_nota = c.no_nota,
                              kode_barang = c.kode_barang,
                              quantity = c.quantity,
                              subtotal = c.subtotal,
                              //nama_barang = d.nama_barang,
                              //harga = d.harga,
                              //satuan = d.satuan,
                              //nama_konsumen = e.nama_konsumen,
                              //date = e.date,

                              created_at = c.created_at,
                              created_by = c.created_by,
                              modified_at = c.modified_at,
                              modified_by = c.modified_by,
                              is_delete = c.is_delete,
                              deleted_at = c.deleted_at,
                              deleted_by = c.deleted_by
                          }).FirstOrDefault();
            }
            return result != null ? result : new DetailPenjualanViewModel();
        }

        //Create New & Edit
        public static ResponseResult Update(DetailPenjualanViewModel entity)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                using (var db = new Context())
                {
                    #region Create New / Insert
                    if (entity.id == 0)
                    {
                        DetailPenjualan detailPenjualan = new DetailPenjualan();

                        detailPenjualan.id = entity.id;
                        detailPenjualan.no_nota = entity.no_nota;
                        detailPenjualan.kode_barang = entity.kode_barang;
                        detailPenjualan.quantity = entity.quantity;
                        detailPenjualan.subtotal = entity.subtotal;

                        detailPenjualan.created_at = DateTime.Now;
                        detailPenjualan.created_by = 123;

                        db.DetailPenjualans.Add(detailPenjualan);
                        db.SaveChanges();

                        result.Entity = entity;
                    }
                    #endregion
                    //Edit
                    //Create New / Insert
                    #region Edit
                    else
                    {
                        DetailPenjualan detailPenjualan = db.DetailPenjualans
                        .Where(o => o.id == entity.id).FirstOrDefault();

                        if (detailPenjualan != null)
                        {
                            detailPenjualan.id = entity.id;
                            detailPenjualan.no_nota = entity.no_nota;
                            detailPenjualan.kode_barang = entity.kode_barang;
                            detailPenjualan.quantity = entity.quantity;
                            detailPenjualan.subtotal = entity.subtotal;

                            detailPenjualan.modified_at = DateTime.Now;
                            detailPenjualan.modified_by = 123;
                                                       
                            db.SaveChanges();

                            result.Entity = entity;
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Data not found!";
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }



        //Delete
        public static ResponseResult Delete(DetailPenjualanViewModel entity)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                using (var db = new Context())
                {
                    DetailPenjualan detailPenjualan = db.DetailPenjualans
                        .Where(o => o.id == entity.id)
                        .FirstOrDefault();
                    if (detailPenjualan != null)
                    {
                        db.DetailPenjualans.Remove(detailPenjualan);
                        db.SaveChanges();

                        result.Entity = entity;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Data not found!";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static string NoNota()
        {
            // Suf-YYMM-Incr
            // SLS-1910-0123
            string yearMonth = DateTime.Now.ToString("yy") + DateTime.Now.Month.ToString("D2");
            string result = "DN-" + yearMonth + "-";
            using (var db = new Context())
            {
                var maxRef = db.DetailPenjualans
                    .Where(oh => oh.no_nota.Contains(result))
                    .Select(oh => new { noNota = oh.no_nota })
                    .OrderByDescending(oh => oh.noNota)
                    .FirstOrDefault();
                if (maxRef != null)
                {
                    string[] oldNoNota = maxRef.noNota.Split('-');
                    int newInc = int.Parse(oldNoNota[2]) + 1;
                    result += newInc.ToString("D4");
                }
                else
                {
                    result += "0001";
                }
            }
            return result;
        }

        public static List<DetailPenjualanViewModel> DetailNota(int id)
        {
            List<DetailPenjualanViewModel> result = new List<DetailPenjualanViewModel>();
            using (var db = new Context())
            {
                result = (from c in db.DetailPenjualans
                          join d in db.Barangs on c.kode_barang equals d.kode_barang
                          join e in db.Penjualans on c.no_nota equals e.no_nota
                          where c.id == id
                          select new DetailPenjualanViewModel
                          {
                              id = c.id,
                              no_nota = c.no_nota,
                              kode_barang = c.kode_barang,
                              quantity = c.quantity,
                              subtotal = c.subtotal,
                              nama_barang = d.nama_barang,
                              harga = d.harga,
                              satuan = d.satuan,
                              nama_konsumen = e.nama_konsumen,
                              date = e.date,                              
                          }).ToList();
            }            
            return result;
        }
    }
}
