namespace MiniGame
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cauhoi")]
    public partial class Cauhoi
    {
        public int Id { get; set; }

        public string Mota { get; set; }

        [StringLength(50)]
        public string CauA { get; set; }

        [StringLength(50)]
        public string CauB { get; set; }

        [StringLength(50)]
        public string CauC { get; set; }

        [StringLength(50)]
        public string CauD { get; set; }

        [StringLength(50)]
        public string DAn { get; set; }

        public string Hinhmota { get; set; }

        public string Id_Tengoi { get; set; }
        public int? Id_Goicauhoi { get; set; }
        public int? IdNguoidung { get; set; }

        public bool? Trangthai { get; set; }
    }
}
