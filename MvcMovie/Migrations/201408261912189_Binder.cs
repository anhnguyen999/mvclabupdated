namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Binder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Binders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BinderNumber = c.Int(nullable: false),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Movies", "BinderId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "BinderId");
            DropTable("dbo.Binders");
        }
    }
}
