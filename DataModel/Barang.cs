using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [Table("tbl_Barang")]
    public class Barang
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int barang_id { get; set; }
        
        public int kode_barang { get; set; }

        [Required, StringLength(30)]
        public string nama_barang { get; set; }
        public int satuan { get; set; }
        public int harga { get; set; }
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
