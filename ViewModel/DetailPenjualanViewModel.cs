using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class DetailPenjualanViewModel
    {
        [DisplayName("ID Detail Penjualan")]
        public int id { get; set; }

        [Display(Name = "Nomor Nota")]
        [Required, StringLength(12)]
        public string no_nota { get; set; }        

        [DisplayName("Kode Barang")]
        public int kode_barang { get; set; }

        [DisplayName("Jumlah")]
        public int quantity { get; set; }

        [DisplayName("Total Harga")]
        public int subtotal { get; set; }
        public Boolean is_delete { get; set; }
        public DateTime? deleted_at { get; set; }
        public long? deleted_by { get; set; }
        public DateTime created_at { get; set; }
        public long created_by { get; set; }
        public DateTime? modified_at { get; set; }
        public long? modified_by { get; set; }


        ////join dari barang
        /// 
        [DisplayName("Nama Barang")]
        public string nama_barang { get; set; }

        [DisplayName("Stock")]
        public int stock { get; set; }

        [DisplayName("Satuan pcs / Kg")]
        public int satuan { get; set; }

        [DisplayName("Harga")]
        public int harga { get; set; }

        ////join dari penjualan
        /// 
        [DisplayName("Nama Konsumen")]
        public string nama_konsumen { get; set; }
        
        [DisplayName("Tanggal Pembelian")]
        public DateTime date { get; set; }
    }
}
