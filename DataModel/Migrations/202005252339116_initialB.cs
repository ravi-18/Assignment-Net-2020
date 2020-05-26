namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Barang",
                c => new
                    {
                        barang_id = c.Int(nullable: false, identity: true),
                        kode_barang = c.Int(nullable: false),
                        nama_barang = c.String(nullable: false, maxLength: 30),
                        satuan = c.Int(nullable: false),
                        harga = c.Int(nullable: false),
                        stock = c.Int(nullable: false),
                        is_delete = c.Boolean(nullable: false),
                        deleted_at = c.DateTime(),
                        deleted_by = c.Long(),
                        created_at = c.DateTime(nullable: false),
                        created_by = c.Long(nullable: false),
                        modified_at = c.DateTime(),
                        modified_by = c.Long(),
                    })
                .PrimaryKey(t => t.barang_id);
            
            CreateTable(
                "dbo.tbl_DetailPenjualan",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        no_nota = c.String(nullable: false, maxLength: 12),
                        kode_barang = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        subtotal = c.Int(nullable: false),
                        is_delete = c.Boolean(nullable: false),
                        deleted_at = c.DateTime(),
                        deleted_by = c.Long(),
                        created_at = c.DateTime(nullable: false),
                        created_by = c.Long(nullable: false),
                        modified_at = c.DateTime(),
                        modified_by = c.Long(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_Penjualan",
                c => new
                    {
                        nota_id = c.Int(nullable: false, identity: true),
                        no_nota = c.String(nullable: false, maxLength: 12),
                        date = c.DateTime(nullable: false),
                        nama_konsumen = c.String(nullable: false, maxLength: 30),
                        is_delete = c.Boolean(nullable: false),
                        delete_at = c.DateTime(),
                        deleted_by = c.Long(),
                        created_at = c.DateTime(nullable: false),
                        created_by = c.Long(nullable: false),
                        modified_at = c.DateTime(),
                        modified_by = c.Long(),
                    })
                .PrimaryKey(t => t.nota_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_Penjualan");
            DropTable("dbo.tbl_DetailPenjualan");
            DropTable("dbo.tbl_Barang");
        }
    }
}
