using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace DataAccess
{
    public class BarangRepo
    {
        //Get All
        public static List<BarangViewModel> All()
        {
            List<BarangViewModel> result = new List<BarangViewModel>();
            using (var db = new Context())
            {
                result = (from c in db.Barangs
                          select new BarangViewModel
                          {
                              barang_id = c.barang_id,
                              kode_barang = c.kode_barang,
                              nama_barang = c.nama_barang,
                              satuan = c.satuan,
                              stock = c.stock,
                              harga = c.harga,
                              
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

        //Create New & Edit
        public static ResponseResult Update(BarangViewModel entity)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                using (var db = new Context())
                {
                    #region Create New / Insert
                    if (entity.barang_id == 0)
                    {
                        Barang barang = new Barang();

                        barang.barang_id = entity.barang_id;
                        barang.kode_barang = entity.kode_barang;
                        barang.nama_barang = entity.nama_barang;
                        barang.satuan = entity.satuan;
                        barang.stock = entity.stock;
                        barang.harga = entity.harga;

                        barang.created_at = DateTime.Now;
                        barang.created_by = 123;

                        db.Barangs.Add(barang);
                        db.SaveChanges();

                        result.Entity = entity;
                    }
                    #endregion
                    //Edit
                    //Create New / Insert
                    #region Edit
                    else
                    {
                        Barang barang = db.Barangs
                        .Where(o => o.barang_id == entity.barang_id).FirstOrDefault();

                        if (barang != null)
                        {
                            barang.barang_id = entity.barang_id;
                            barang.kode_barang = entity.kode_barang;
                            barang.nama_barang = entity.nama_barang;
                            barang.satuan = entity.satuan;
                            barang.stock = entity.stock;
                            barang.harga = entity.harga;

                            barang.modified_at = DateTime.Now;
                            barang.modified_by = 123;

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

        //Get By Id
        public static BarangViewModel ById(int id)
        {
            BarangViewModel result = new BarangViewModel();
            using (var db = new Context())
            {
                result = (from c in db.Barangs
                              //join d in db.Barangs on c.kode_barang equals d.kode_barang
                              //join e in db.Penjualans on c.no_nota equals e.no_nota
                          where c.barang_id == id
                          select new BarangViewModel
                          {
                              barang_id = c.barang_id,
                              kode_barang = c.kode_barang,
                              nama_barang = c.nama_barang,
                              satuan = c.satuan,
                              stock = c.stock,
                              harga = c.harga,

                              created_at = c.created_at,
                              created_by = c.created_by,
                              modified_at = c.modified_at,
                              modified_by = c.modified_by,
                              is_delete = c.is_delete,
                              deleted_at = c.deleted_at,
                              deleted_by = c.deleted_by
                          }).FirstOrDefault();
            }
            return result != null ? result : new BarangViewModel();
        }
    }
}
