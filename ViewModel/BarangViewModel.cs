using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BarangViewModel
    {
        public int barang_id { get; set; }

        [DisplayName("Kode Barang")]        
        public int kode_barang { get; set; }

        [DisplayName("Nama Barang")]
        [Required, StringLength(30)]        
        public string nama_barang { get; set; }

        [DisplayName("Satuan PCS / Kg")]
        public int satuan { get; set; }

        [DisplayName("Harga")]
        public int harga { get; set; }

        [DisplayName("Stock")]
        public int stock { get; set; }
        public Boolean is_delete { get; set; }
        public DateTime? deleted_at { get; set; }
        public long? deleted_by { get; set; }
        public DateTime created_at { get; set; }
        public long created_by { get; set; }
        public DateTime? modified_at { get; set; }
        public long? modified_by { get; set; }
    }
}
