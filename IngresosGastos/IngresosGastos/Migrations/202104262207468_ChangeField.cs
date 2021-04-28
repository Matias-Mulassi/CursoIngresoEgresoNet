namespace IngresosGastos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IngresosGastosMMus", "EsIngreso", c => c.Boolean(nullable: false));
            DropColumn("dbo.IngresosGastosMMus", "Ingreso");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IngresosGastosMMus", "Ingreso", c => c.Boolean(nullable: false));
            DropColumn("dbo.IngresosGastosMMus", "EsIngreso");
        }
    }
}
