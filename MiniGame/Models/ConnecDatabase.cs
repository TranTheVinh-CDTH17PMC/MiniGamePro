namespace MiniGame
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ConnecDatabase : DbContext
    {
        public ConnecDatabase()
            : base("name=ConnecDatabase")
        {
        }

        public virtual DbSet<Cauhoi> Cauhois { get; set; }
        public virtual DbSet<GoiCauHoi> GoiCauHois { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<XepHang> XepHangs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
