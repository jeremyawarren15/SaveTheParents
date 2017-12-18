namespace SaveTheParents.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedFloatToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Review", "ParentRating", c => c.Int(nullable: false));
            AlterColumn("dbo.Review", "ChildRating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Review", "ChildRating", c => c.Single(nullable: false));
            AlterColumn("dbo.Review", "ParentRating", c => c.Single(nullable: false));
        }
    }
}
