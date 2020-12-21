namespace Doan_QLHTGT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NguoiDangKyXes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        IdentityCard = c.String(),
                        TaiKhoan_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaiKhoans", t => t.TaiKhoan_Id)
                .Index(t => t.TaiKhoan_Id);
            
            CreateTable(
                "dbo.TaiKhoans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ViPhams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoiDung = c.String(),
                        TienPhat = c.Int(nullable: false),
                        NgayViPham = c.DateTime(nullable: false),
                        NguoiDangKyXe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NguoiDangKyXes", t => t.NguoiDangKyXe_Id)
                .Index(t => t.NguoiDangKyXe_Id);
            
            CreateTable(
                "dbo.Xes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoaiXe = c.String(),
                        BienSo = c.String(),
                        ChuSoHuuId = c.Int(nullable: false),
                        NguoiDangKyXe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NguoiDangKyXes", t => t.NguoiDangKyXe_Id)
                .Index(t => t.NguoiDangKyXe_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Xes", "NguoiDangKyXe_Id", "dbo.NguoiDangKyXes");
            DropForeignKey("dbo.ViPhams", "NguoiDangKyXe_Id", "dbo.NguoiDangKyXes");
            DropForeignKey("dbo.NguoiDangKyXes", "TaiKhoan_Id", "dbo.TaiKhoans");
            DropIndex("dbo.Xes", new[] { "NguoiDangKyXe_Id" });
            DropIndex("dbo.ViPhams", new[] { "NguoiDangKyXe_Id" });
            DropIndex("dbo.NguoiDangKyXes", new[] { "TaiKhoan_Id" });
            DropTable("dbo.Xes");
            DropTable("dbo.ViPhams");
            DropTable("dbo.TaiKhoans");
            DropTable("dbo.NguoiDangKyXes");
        }
    }
}
