namespace ABC_University.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlocationcolum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "location");
        }
    }
}
