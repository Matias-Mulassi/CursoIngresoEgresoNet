namespace IngresosGastos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTimeIngresoEgreso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IngresosGastosMMus", "FechaIngreso", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IngresosGastosMMus", "FechaIngreso");
        }
    }
}
