namespace TcNoSorgulaWebApi_03_03_22.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "TcNumberHash", c => c.Binary());
            AddColumn("dbo.People", "TcNumberSalt", c => c.Binary());
            DropColumn("dbo.People", "TcNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "TcNo", c => c.Int(nullable: false));
            DropColumn("dbo.People", "TcNumberSalt");
            DropColumn("dbo.People", "TcNumberHash");
        }
    }
}
