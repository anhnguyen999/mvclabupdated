namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Binder_PageCapacity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Binders", "PageCapacity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Binders", "PageCapacity");
        }
    }
}
