using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [Table("tbl_DetailPenjualan")]
    public class DetailPenjualan
    {        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        
        [Required,StringLength(12)]
        public string no_nota { get; set; }        
        public int kode_barang { get; set; }               
        public int quantity { get; set; }        
        public int subtotal { get; set; }
        public Boolean is_delete { get; set; }
        public DateTime? deleted_at { get; set; }        
        public long? deleted_by { get; set; }
        public DateTime created_at { get; set; }
        public long created_by { get; set; }
        public DateTime? modified_at { get; set; }
        public long? modified_by { get; set; }
        //public virtual List<tbl_Penjualan> tbl_Penjualan { get; set; }
    }
}
