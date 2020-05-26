using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PenjualanViewModel
    {
        public int nota_id { get; set; }
        public DateTime date { get; set; }

        [Required, StringLength(12)]
        public string kode_nota { get; set; }

        [Required, StringLength(30)]
        public string nama_konsumen { get; set; }
        public Boolean is_delete { get; set; }
        public DateTime? deleted_at { get; set; }
        public long? deleted_by { get; set; }
        public DateTime created_at { get; set; }
        public long created_by { get; set; }
        public DateTime? modified_at { get; set; }
        public long? modified_by { get; set; }
    }
}
